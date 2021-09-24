using Opc.Ua;
using Opc.Ua.Server;
using OPCUA_MethodOfCoding.Classes.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Xml;
using ToConnectOPCUA.Enum;

namespace ToConnectOPCUA.Classes
{
    public class ReferenceNodeManager<T> : CustomNodeManager2, INotifyPropertyChanged where T : OpcuaNode
    {
        #region Private Fields
        private int cfgCount = -1;
        private ReferenceServerConfiguration m_configuration;
        private Opc.Ua.Test.DataGenerator m_generator;
        // private Timer m_simulationTimer;
        private UInt16 m_simulationInterval = 1000;
        private bool m_simulationEnabled = true;
        private List<T> nodes;
        public Func<Dictionary<string, BaseDataVariableState>, bool> _actonDelegate;
        public Thread CycleUpdateVal;
        private Dictionary<string, BaseDataVariableState> _nodeDic = new Dictionary<string, BaseDataVariableState>();
        private Dictionary<string, FolderState> _folderDic = new Dictionary<string, FolderState>();
        public Dictionary<string, object> _GotDictionary = new Dictionary<string, object>();
        private ObservableCollection<ValueDictionaryClass> _myDict;

        public ObservableCollection<ValueDictionaryClass> MyDict
        {
            get { return _myDict; }
            set
            {
                _myDict = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region CTOR
        public ReferenceNodeManager(IServerInternal server, ApplicationConfiguration configuration, List<T> nodeClass) : base(server, configuration, GP_NameSpace.ReferenceApplications)
        {
            SystemContext.NodeIdFactory = this;
            m_configuration = configuration.ParseExtension<ReferenceServerConfiguration>();
            if (m_configuration == null)
            {
                m_configuration = new ReferenceServerConfiguration();
            }
            nodes = nodeClass;
            CycleUpdateVal = new Thread(UpdateVariableValue);
        }
        #endregion

        #region IDisposable Members
        /// <summary>
        /// An overrideable version of the Dispose.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // TBD
            }
        }
        #endregion

        #region INodeIdFactory Members
        /// <summary>
        /// Creates the NodeId for the specified node.
        /// </summary>
        public override NodeId New(ISystemContext context, NodeState node)
        {
            BaseInstanceState instance = node as BaseInstanceState;

            if (instance != null && instance.Parent != null)
            {
                string id = instance.Parent.NodeId.Identifier as string;

                if (id != null)
                {
                    return new NodeId(id + "_" + instance.SymbolicName, instance.Parent.NodeId.NamespaceIndex);
                }
            }

            return node.NodeId;
        }
        #endregion

        #region 創建基礎目錄       
        /// <summary>
        /// overrride 創建基礎目錄
        /// </summary>
        /// <param name="externalReferences"></param>
        public override void CreateAddressSpace(IDictionary<NodeId, IList<IReference>> externalReferences)
        {
            lock (Lock)
            {
                IList<IReference> references = null;
                if (!externalReferences.TryGetValue(ObjectIds.ObjectsFolder, out references))
                {
                    externalReferences[ObjectIds.ObjectsFolder] = references = new List<IReference>();
                }

                try
                {
                    CreateRoot(nodes, references);
                    // UpdateVariableValue();
                }
                catch (Exception e)
                {
                    Utils.Trace(e, "Error creating the address space.");
                }
            }
        }
        #endregion

        #region Looping Updating Values

        private void UpdateVariableValue()
        {
            while (true)
            {
                try
                {
                    int count = 0;
                    if (count > 0 && count != cfgCount)
                    {
                        cfgCount = count;
                        List<OpcuaNode> nodes = new List<OpcuaNode>();
                        /*  
                         *  UpdateNodesAttribute(nodes);                     
                         */
                    }
                    //模擬獲取實時數據
                    BaseDataVariableState node = null;
                    Application.Current.Dispatcher.Invoke((Action)delegate
                    {
                        MyDict?.Clear();
                        MyDict = new ObservableCollection<ValueDictionaryClass>();
                    });                  

                    if (_GotDictionary.Count != 0 && _nodeDic.Count != 0)
                    {
                        bool flag = false;
                        foreach (var item in _GotDictionary)
                        {
                            if (_GotDictionary[item.Key] == null)
                            {
                                flag = true;
                            }  
                        }
                        if (!flag)
                        {
                            var dict3 = _nodeDic.Where(entry =>
                                                         !_GotDictionary[entry.Key].Equals(entry.Value.Value) && (entry.Value.Value != null))
                                                        .ToDictionary(entry => entry.Key, entry => entry.Value);
                            if (dict3.Count > 0) 
                                SpinWait.SpinUntil(() => _actonDelegate(dict3));
                        }                        
                    }
                    /*                    
                   * 在實際業務中應該是根據對應的標識來更新固定節點的數據
                   * 全部測點都更新為一個新的隨機數
                   */
                    foreach (var item in _nodeDic)
                    {
                        node = item.Value;
                        node.Timestamp = DateTime.Now;
                        node.ClearChangeMasks(SystemContext, false);//變更標識  只有執行了這一步,訂閱的客戶端才會收到新的數據                            
                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            MyDict.Add(new ValueDictionaryClass() { Identifier = node.NodeId.Identifier.ToString(), FieldsName = node.SymbolicName, FieldsValue = node.Value });

                        });
                    }
                    _GotDictionary?.Clear();
                    foreach (var key in MyDict)
                    {
                        _GotDictionary.Add(string.Format("{0}", key.FieldsName), key.FieldsValue);
                    }
                    //1秒更新一次
                    SpinWait.SpinUntil(() => false, 1000);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("更新OPC-UA節點數據觸發異常:" + ex.Message);
                    Console.ResetColor();
                }
            }
        }
        /// <summary>
        /// 設定指定Node之值
        /// </summary>
        /// <param name="target">NodeName</param>
        /// <param name="dataType">資料型態</param>
        /// <param name="value">值</param>
        public void SetValue(string target, DataType dataType, object value)
        {
            BaseDataVariableState node = null;
            var TargetGotten = _nodeDic.Where(x => target == x.Key);
            var targetResult = TargetGotten.ToList();
            targetResult.ForEach(o =>
            {
                node = o.Value;
            });
            var convertedType = Convert.ToInt32(node.DataType.Identifier);
            var type = (DataType)convertedType;
            try
            {
                if (targetResult.Count > 0)
                {
                    switch (dataType)
                    {
                        case DataType.DateTime:
                            if (type == dataType) node.Value = (DateTime)value;
                            break;
                        case DataType.String:
                            if (type == dataType) node.Value = (string)value;
                            break;
                        case DataType.Double:
                            if (type == dataType) node.Value = (double)value;
                            break;
                        case DataType.Float:
                            if (type == dataType) node.Value = (float)value;
                            break;
                        case DataType.UInt64:
                            if (type == dataType) node.Value = (UInt64)value;
                            break;
                        case DataType.Int64:
                            if (type == dataType) node.Value = (Int64)value;
                            break;
                        case DataType.UInt32:
                            if (type == dataType) node.Value = (UInt32)value;
                            break;
                        case DataType.Int32:
                            if (type == dataType) node.Value = (Int32)value;
                            break;
                        case DataType.UInt16:
                            if (type == dataType) node.Value = (UInt16)value;
                            break;
                        case DataType.Int16:
                            if (type == dataType) node.Value = (Int16)value;
                            break;
                        case DataType.Byte:
                            if (type == dataType) node.Value = (byte)value;
                            break;
                        case DataType.SByte:
                            if (type == dataType) node.Value = (sbyte)value;
                            break;
                        case DataType.Boolean:
                            if (type == dataType) node.Value = (bool)value;
                            break;
                        case DataType.UInteger:
                            if (type == dataType) node.Value = (uint)value;
                            break;
                        case DataType.Integer:
                            if (type == dataType) node.Value = (int)value;
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("{0}{1}"), "An error occured during setting value process", e.Message);
            }
        }
        #endregion

        #region 產生根目錄


        /// <summary>
        /// 產生根目錄
        /// </summary>
        /// <param name="references"></param>
        /// <param name="rootNodeID"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private void CreateRoot(List<T> nodes, IList<IReference> references)
        {
            var list = nodes.Where(d => d.NodeType == NodeType.GRC).ToList();
            list.ForEach(x =>
            {
                try
                {
                    FolderState root = CreateFolder(null, x.NodePath, x.NodeName);
                    root.AddReference(ReferenceTypes.Organizes, true, ObjectIds.ObjectsFolder);
                    references.Add(new NodeStateReference(ReferenceTypes.Organizes, false, root.NodeId));
                    root.EventNotifier = EventNotifiers.SubscribeToEvents;
                    AddRootNotifier(root);
                    CreateNodes(nodes, root, x.NodePath);
                    _folderDic.Add(x.NodePath, root);
                    AddPredefinedNode(SystemContext, root);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("創建OPC-UA根節點觸發異常:" + ex.Message);
                    Console.ResetColor();
                }
            });
        }
        private void CreateNodes(List<T> nodes, FolderState parent, string parentPath)
        {
            var list = nodes.Where(d => d.ParentPath == parentPath).ToList();
            list.ForEach(node =>
            {
                try
                {
                    if (!node.IsTerminal)
                    {
                        /// 如果是資料夾
                        FolderState folder = CreateFolder(parent, node.NodePath, node.NodeName);
                        _folderDic.Add(node.NodePath, folder);
                        CreateNodes(nodes, folder, node.NodePath);
                    }
                    else
                    {
                        /// 如果不是資料夾
                        BaseDataVariableState variable = CreateVariable(parent, node.NodePath, node.NodeName, node.DataType, ValueRanks.Scalar);
                        //此處需要注意  目錄字典是以目錄路徑作為KEY 而 測點字典是以測點ID作為KEY  為了方便更新實時數據
                        _nodeDic.Add(string.Format("{0}", variable.SymbolicName), variable);
                        //_nodeDic.Add(node.NodeId.ToString(), variable);

                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("創建OPC-UA子節點觸發異常:" + ex.Message);
                    Console.ResetColor();
                }
            });

        }
        /// <summary>
        /// Creates a new variable.
        /// </summary>
        private BaseDataVariableState CreateVariable(NodeState parent, string path, string name, NodeId dataType, int valueRank)
        {
            BaseDataVariableState variable = new BaseDataVariableState(parent);

            variable.SymbolicName = name;
            variable.ReferenceTypeId = ReferenceTypes.Organizes;
            variable.TypeDefinitionId = VariableTypeIds.BaseDataVariableType;
            variable.NodeId = new NodeId(path, NamespaceIndex);
            variable.BrowseName = new QualifiedName(path, NamespaceIndex);
            variable.DisplayName = new LocalizedText("en", name);
            variable.WriteMask = AttributeWriteMask.DisplayName | AttributeWriteMask.Description;
            variable.UserWriteMask = AttributeWriteMask.DisplayName | AttributeWriteMask.Description;
            variable.DataType = dataType;
            variable.ValueRank = valueRank;
            variable.AccessLevel = AccessLevels.CurrentReadOrWrite;
            variable.UserAccessLevel = AccessLevels.CurrentReadOrWrite;
            variable.Historizing = false;
            // variable.Value = GetNewValue(variable);
            variable.StatusCode = StatusCodes.Good;
            variable.Timestamp = DateTime.UtcNow;
            variable.OnWriteValue = OnWriteDataValue;

            if (valueRank == ValueRanks.OneDimension)
            {
                variable.ArrayDimensions = new ReadOnlyList<uint>(new List<uint> { 0 });
            }
            else if (valueRank == ValueRanks.TwoDimensions)
            {
                variable.ArrayDimensions = new ReadOnlyList<uint>(new List<uint> { 0, 0 });
            }

            if (parent != null)
            {
                parent.AddChild(variable);
            }

            return variable;
        }

        /// <summary>
        /// 產生一個folder一個數值
        /// </summary>
        /// <param name="root"></param>
        /// <param name="nodePath"> FOLDER NODE ID [CANNOT BE REPEATED] </param>
        /// <param name="nodeName"></param>
        /// <param name="node_NodePath"> VARIABLE NODE ID [CANNOT BE REPEATED] </param>
        /// <param name="nameOfVariable"></param>
        /// <param name="nodeIdTypeDefine"></param>
        /// <param name="valueRanks"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        private FolderState CreateFolderSubNodesWithVariable(NodeState root, string nodePath, string nodeName, string node_NodePath, string nameOfVariable, NodeId nodeIdTypeDefine, int valueRanks, object val)
        {
            FolderState subFolder = CreateFolder(root, nodePath, nodeName);
            BaseDataVariableState subNodeVal = CreateVariable(subFolder, node_NodePath, nameOfVariable, nodeIdTypeDefine, valueRanks);
            subNodeVal.Value = val;
            return subFolder;
        }


        /// <summary>
        /// Creates a new folder.
        /// </summary>
        private FolderState CreateFolder(NodeState parent, string path, string name)
        {
            FolderState folder = new FolderState(parent);

            folder.SymbolicName = name;
            folder.ReferenceTypeId = ReferenceTypes.Organizes;
            folder.TypeDefinitionId = ObjectTypeIds.FolderType;
            folder.NodeId = new NodeId(path, NamespaceIndex);
            folder.BrowseName = new QualifiedName(path, NamespaceIndex);
            folder.DisplayName = new LocalizedText("en", name);
            folder.WriteMask = AttributeWriteMask.None;
            folder.UserWriteMask = AttributeWriteMask.None;
            folder.EventNotifier = EventNotifiers.None;

            if (parent != null)
            {
                parent.AddChild(folder);
            }

            return folder;
        }
        /// <summary>
        /// 產生單個變數
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="node_NodePath"></param>
        /// <param name="nameOfVariable"></param>
        /// <param name="dataType"></param>
        /// <param name="valueRank"></param>
        /// <returns></returns>
        private BaseDataVariableState CreateVariableAndSetValue(NodeState parent, string node_NodePath, string nameOfVariable, NodeId dataType, int valueRank, object val)
        {
            var variableCreated = CreateVariable(parent, node_NodePath, nameOfVariable, dataType, valueRank);
            variableCreated.Value = val;
            return variableCreated;
        }

        private FolderState ToCreateSubFolder(NodeState root, string nodePath, string nodeName)
        {
            FolderState subFolder = CreateFolder(root, nodePath, nodeName);
            return subFolder;
        }

        #endregion
        private ServiceResult OnWriteInterval(ISystemContext context, NodeState node, ref object value)
        {
            try
            {
                m_simulationInterval = (UInt16)value;

                if (m_simulationEnabled)
                {
                    //    m_simulationTimer.Change(100, (int)m_simulationInterval);
                }

                return ServiceResult.Good;
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Error writing Interval variable.");
                return ServiceResult.Create(e, StatusCodes.Bad, "Error writing Interval variable.");
            }
        }

        private ServiceResult OnWriteEnabled(ISystemContext context, NodeState node, ref object value)
        {
            try
            {
                m_simulationEnabled = (bool)value;

                if (m_simulationEnabled)
                {
                    //   m_simulationTimer.Change(100, (int)m_simulationInterval);
                }
                else
                {
                    //    m_simulationTimer.Change(100, 0);
                }

                return ServiceResult.Good;
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Error writing Enabled variable.");
                return ServiceResult.Create(e, StatusCodes.Bad, "Error writing Enabled variable.");
            }
        }

        /// <summary>
        /// Creates a new variable.
        /// </summary>
        private DataItemState CreateDataItemVariable(NodeState parent, string path, string name, BuiltInType dataType, int valueRank)
        {
            DataItemState variable = new DataItemState(parent);
            variable.ValuePrecision = new PropertyState<double>(variable);
            variable.Definition = new PropertyState<string>(variable);

            variable.Create(
                SystemContext,
                null,
                variable.BrowseName,
                null,
                true);

            variable.SymbolicName = name;
            variable.ReferenceTypeId = ReferenceTypes.Organizes;
            variable.NodeId = new NodeId(path, NamespaceIndex);
            variable.BrowseName = new QualifiedName(path, NamespaceIndex);
            variable.DisplayName = new LocalizedText("en", name);
            variable.WriteMask = AttributeWriteMask.None;
            variable.UserWriteMask = AttributeWriteMask.None;
            variable.DataType = (uint)dataType;
            variable.ValueRank = valueRank;
            variable.AccessLevel = AccessLevels.CurrentReadOrWrite;
            variable.UserAccessLevel = AccessLevels.CurrentReadOrWrite;
            variable.Historizing = false;
            variable.Value = Opc.Ua.TypeInfo.GetDefaultValue((uint)dataType, valueRank, Server.TypeTree);
            variable.StatusCode = StatusCodes.Good;
            variable.Timestamp = DateTime.UtcNow;

            if (valueRank == ValueRanks.OneDimension)
            {
                variable.ArrayDimensions = new ReadOnlyList<uint>(new List<uint> { 0 });
            }
            else if (valueRank == ValueRanks.TwoDimensions)
            {
                variable.ArrayDimensions = new ReadOnlyList<uint>(new List<uint> { 0, 0 });
            }

            variable.ValuePrecision.Value = 2;
            variable.ValuePrecision.AccessLevel = AccessLevels.CurrentReadOrWrite;
            variable.ValuePrecision.UserAccessLevel = AccessLevels.CurrentReadOrWrite;
            variable.Definition.Value = String.Empty;
            variable.Definition.AccessLevel = AccessLevels.CurrentReadOrWrite;
            variable.Definition.UserAccessLevel = AccessLevels.CurrentReadOrWrite;

            if (parent != null)
            {
                parent.AddChild(variable);
            }

            return variable;
        }

        private DataItemState[] CreateDataItemVariables(NodeState parent, string path, string name, BuiltInType dataType, int valueRank, UInt16 numVariables)
        {
            List<DataItemState> itemsCreated = new List<DataItemState>();
            // create the default name first:
            itemsCreated.Add(CreateDataItemVariable(parent, path, name, dataType, valueRank));
            // now to create the remaining NUMBERED items
            for (uint i = 0; i < numVariables; i++)
            {
                string newName = string.Format("{0}{1}", name, i.ToString("000"));
                string newPath = string.Format("{0}/Mass/{1}", path, newName);
                itemsCreated.Add(CreateDataItemVariable(parent, newPath, newName, dataType, valueRank));
            }//for i
            return (itemsCreated.ToArray());
        }
        /// <summary>
        /// Creates a new object.
        /// </summary>
        private BaseObjectState CreateObject(NodeState parent, string path, string name)
        {
            BaseObjectState folder = new BaseObjectState(parent);

            folder.SymbolicName = name;
            folder.ReferenceTypeId = ReferenceTypes.Organizes;
            folder.TypeDefinitionId = ObjectTypeIds.BaseObjectType;
            folder.NodeId = new NodeId(path, NamespaceIndex);
            folder.BrowseName = new QualifiedName(name, NamespaceIndex);
            folder.DisplayName = folder.BrowseName.Name;
            folder.WriteMask = AttributeWriteMask.None;
            folder.UserWriteMask = AttributeWriteMask.None;
            folder.EventNotifier = EventNotifiers.None;

            if (parent != null)
            {
                parent.AddChild(folder);
            }

            return folder;
        }

        /// <summary>
        /// Creates a new object type.
        /// </summary>
        private BaseObjectTypeState CreateObjectType(NodeState parent, IDictionary<NodeId, IList<IReference>> externalReferences, string path, string name)
        {
            BaseObjectTypeState type = new BaseObjectTypeState();

            type.SymbolicName = name;
            type.SuperTypeId = ObjectTypeIds.BaseObjectType;
            type.NodeId = new NodeId(path, NamespaceIndex);
            type.BrowseName = new QualifiedName(name, NamespaceIndex);
            type.DisplayName = type.BrowseName.Name;
            type.WriteMask = AttributeWriteMask.None;
            type.UserWriteMask = AttributeWriteMask.None;
            type.IsAbstract = false;

            IList<IReference> references = null;

            if (!externalReferences.TryGetValue(ObjectTypeIds.BaseObjectType, out references))
            {
                externalReferences[ObjectTypeIds.BaseObjectType] = references = new List<IReference>();
            }

            references.Add(new NodeStateReference(ReferenceTypes.HasSubtype, false, type.NodeId));

            if (parent != null)
            {
                parent.AddReference(ReferenceTypes.Organizes, false, type.NodeId);
                type.AddReference(ReferenceTypes.Organizes, true, parent.NodeId);
            }

            AddPredefinedNode(SystemContext, type);
            return type;
        }

        /// <summary>
        /// Creates a new variable.
        /// </summary>
        private BaseDataVariableState CreateVariable(NodeState parent, string path, string name, BuiltInType dataType, int valueRank)
        {
            return CreateVariable(parent, path, name, (uint)dataType, valueRank);
        }

        /// <summary>
        /// 客戶端寫值時觸發
        /// </summary>
        /// <param name="context"></param>
        /// <param name="node"></param>
        /// <param name="indexRange"></param>
        /// <param name="dataEncoding"></param>
        /// <param name="value"></param>
        /// <param name="statusCode"></param>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        private ServiceResult OnWriteDataValue(ISystemContext context, NodeState node, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref StatusCode statusCode, ref DateTime timestamp)
        {
            BaseDataVariableState variable = node as BaseDataVariableState;
            try
            {
                TypeInfo typeInfo = TypeInfo.IsInstanceOfDataType(
                    value,
                    variable.DataType,
                    variable.ValueRank,
                    context.NamespaceUris,
                    context.TypeTable);

                if (typeInfo == null || typeInfo == TypeInfo.Unknown)
                {
                    return StatusCodes.BadTypeMismatch;
                }
                if (typeInfo.BuiltInType == BuiltInType.Double)
                {
                    double number = Convert.ToDouble(value);
                    value = TypeInfo.Cast(number, typeInfo.BuiltInType);
                }
                return ServiceResult.Good;
            }
            catch (Exception)
            {
                return StatusCodes.BadTypeMismatch;
            }
        }

        private List<BaseDataVariableState> CreateVariables(NodeState parent, string node_NodePath, string folderName, string varaibleName, BuiltInType dataType, int valueRank, UInt16 numVariables)
        {
            return CreateVariables(parent, node_NodePath, folderName, varaibleName, (uint)dataType, valueRank, numVariables);
        }

        private List<BaseDataVariableState> CreateVariables(NodeState parent, string node_NodePath, string nodeName, string varaibleName, NodeId dataType, int valueRank, UInt16 numVariables)
        {
            // first, create a new Parent folder for this data-type
            FolderState newParentFolder = CreateFolder(parent, node_NodePath, nodeName);
            // 可單一控制每一個變數
            List<BaseDataVariableState> itemsCreated = new List<BaseDataVariableState>();
            // now to create the remaining NUMBERED items
            for (uint i = 0; i < numVariables; i++)
            {
                var trimedVal = Convert.ToInt32(varaibleName.Trim('D'));
                string newName = string.Format("D{0}", (trimedVal + i));
                string newPath = string.Format("{0}_{1}", node_NodePath, newName);
                itemsCreated.Add(CreateVariable(newParentFolder, newPath, newName, dataType, valueRank));
            }
            return itemsCreated;
        }
        private object GetNewValue(BaseVariableState variable)
        {
            if (m_generator == null)
            {
                m_generator = new Opc.Ua.Test.DataGenerator(null);
                m_generator.BoundaryValueFrequency = 0;
            }

            object value = null;
            int retryCount = 0;

            while (value == null && retryCount < 10)
            {
                value = m_generator.GetRandom(variable.DataType, variable.ValueRank, new uint[] { 10 }, Server.TypeTree);
                retryCount++;
            }

            return value;
        }

        /// <summary>
        /// Creates a new method.
        /// </summary>
        private MethodState CreateMethod(NodeState parent, string path, string name)
        {
            MethodState method = new MethodState(parent);

            method.SymbolicName = name;
            method.ReferenceTypeId = ReferenceTypeIds.HasComponent;
            method.NodeId = new NodeId(path, NamespaceIndex);
            method.BrowseName = new QualifiedName(path, NamespaceIndex);
            method.DisplayName = new LocalizedText("en", name);
            method.WriteMask = AttributeWriteMask.None;
            method.UserWriteMask = AttributeWriteMask.None;
            method.Executable = true;
            method.UserExecutable = true;

            if (parent != null)
            {
                parent.AddChild(method);
            }

            return method;
        }
        #region 驗證node
        /// <summary>
        /// Verifies that the specified node exists.
        /// </summary>
        protected override NodeState ValidateNode(
           ServerSystemContext context,
           NodeHandle handle,
           IDictionary<NodeId, NodeState> cache)
        {
            // not valid if no root.
            if (handle == null)
            {
                return null;
            }

            // check if previously validated.
            if (handle.Validated)
            {
                return handle.Node;
            }

            // TBD

            return null;
        }
        #endregion

        #region PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion PropertyChangedEventHandler
    }
}
