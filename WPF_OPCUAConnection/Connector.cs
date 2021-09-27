using Opc.Ua;
using OPC_UA_Library;
using OPCUA_MethodOfCoding;
using OPCUA_MethodOfCoding.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToConnectOPCUA;
using ToConnectOPCUA.Classes;
using ToConnectOPCUA.Enum;

namespace WPF_OPCUAConnection
{
    public class Connector : INotifyPropertyChanged
    {
        private static List<NodeDataStruct> retrunListOfNodes = new List<NodeDataStruct>();
        private static List<ListNodeStruct> dfg;
        List<ListNodeStruct> h;


        private OPCUA_Server _MyService;

        public OPCUA_Server MyService
        {
            get { return _MyService; }
            set
            {
                _MyService = value;
                NotifyPropertyChanged();
            }
        }
        public ReferenceNodeManager<OpcuaNode> ReferenceNodeManagerObj
        {
            get
            {
                return MyService?.RefServer?.NodeManager;
            }
        }
        public Connector()
        {
            #region XML
            //OPC_UA_Server obj = new OPC_UA_Server(new GPPlantServer());
            //obj.GPPlantServer.GPPlantObj.Coater.PLC1.Connection.Value = false;
            //obj.GPPlantServer.GPPlantObj.StartProcess.OnCallMethod = new GenericMethodCalledEventHandler(OnStartProcess);
            //obj.GPPlantServer.GPPlantObj.StopProcess.OnCallMethod = new GenericMethodCalledEventHandler(OnStopProcess);
            //var a = obj.GPPlantServer.GPPlantNodeManager.CreateTwoStateDiscreteItemVariable(null, "1" + "002", "002", "open", "close") as TwoStateDiscreteState;
            //obj.GPPlantServer.GPPlantObj.StartProcess.OnCallMethod(obj.GPPlantServer.GPPlantNodeManager.SystemContext, new MethodState(a), new List<object> { 1, 2 }, new List<object> { 3, 4 });
            //obj.GPPlantServer.GPPlantObj.StopProcess.OnCallMethod(obj.GPPlantServer.GPPlantNodeManager.SystemContext, new MethodState(a), new List<object> { 1, 2 }, new List<object> { 3, 4 });
            //  OPC_UAServerServices myService = new OPC_UAServerServices(new OPCUA_MethodOfCoding.Classes.ReferenceServer());
            #endregion

            #region↓↓↓↓↓↓↓↓↓ 建立樹狀結構 ↓↓↓↓↓↓↓↓↓
            int idx = 0;
            List<ListNodeStruct> g = new List<ListNodeStruct>();
            for (int i = 0; i < 2; i++)
            {
                g.Add(new ListNodeStruct()
                {
                    NodeID = Convert.ToInt32(string.Format("{0}{1}", 1, i + 1)),
                    MainFolderName = "PLC" + (i + 1),
                    ParentPath = "1",
                    NodeType = NodeType.PLC1 + i,
                    IsRootEnd = false,
                });
                h = new List<ListNodeStruct>();

                h.Add(new ListNodeStruct()
                {
                    NodeID = Convert.ToInt32(string.Format("{0}{1}", g[i].NodeID, idx + 1)),
                    MainFolderName = "PLC" + (idx + 1) + "_Connection",
                    ParentPath = string.Format("{0}", g[i].NodeID),
                    NodeType = NodeType.Point,
                    IsRootEnd = true,
                    DataType = DataTypeIds.Boolean
                });
                h.Add(new ListNodeStruct()
                {
                    NodeID = Convert.ToInt32(string.Format("{0}{1}", g[i].NodeID, idx + 2)),
                    MainFolderName = "PLC" + (idx + 1) + "_Point2",
                    ParentPath = string.Format("{0}", g[i].NodeID),
                    NodeType = NodeType.Point,
                    IsRootEnd = true,
                    DataType = DataTypeIds.Double
                });
                h.Add(new ListNodeStruct()
                {
                    NodeID = Convert.ToInt32(string.Format("{0}{1}", g[i].NodeID, idx + 3)),
                    MainFolderName = "PLC" + (idx + 1) + "_Point3",
                    ParentPath = string.Format("{0}", g[i].NodeID),
                    NodeType = NodeType.Point,
                    IsRootEnd = true,
                    DataType = DataTypeIds.Double
                });
                h.Add(new ListNodeStruct()
                {
                    NodeID = Convert.ToInt32(string.Format("{0}{1}", g[i].NodeID, idx + 4)),
                    MainFolderName = "PLC" + (idx + 1) + "_Point4",
                    ParentPath = string.Format("{0}", g[i].NodeID),
                    NodeType = NodeType.Point,
                    IsRootEnd = true,
                    DataType = DataTypeIds.Double
                });
                h.Add(new ListNodeStruct()
                {
                    NodeID = Convert.ToInt32(string.Format("{0}{1}", g[i].NodeID, idx + 6)),
                    MainFolderName = "PLC" + (idx + 1) + "_Point6",
                    ParentPath = string.Format("{0}", g[i].NodeID),
                    NodeType = NodeType.Point,
                    IsRootEnd = false,
                });

                g[i].SubNodeNames = h;

                idx++;
            }
            for (int i = 0; i < 2; i++)
            {
                dfg = new List<ListNodeStruct>();
                dfg.Add(new ListNodeStruct()
                {
                    NodeID = g[i].SubNodeNames[4].NodeID + i + 1,
                    MainFolderName = "PLC" + (idx + 1) + "_Point" + (7 + idx + 1),
                    ParentPath = string.Format("{0}", g[i].SubNodeNames[4].NodeID),
                    NodeType = NodeType.Point,
                    IsRootEnd = false,
                });
                g[i].SubNodeNames[4].SubNodeNames = dfg;
            }

            List<ListNodeStruct> ListOfMachine = new List<ListNodeStruct>();
            ListOfMachine.Add(new ListNodeStruct()
            {
                NodeID = 1,
                MainFolderName = "GRC",
                ParentPath = string.Empty,
                NodeType = NodeType.GRC,
                IsRootEnd = false,
                SubNodeNames = g
            });
            BuildingTree(ListOfMachine);
            var asdsdafa = ListOfMachine;
            #endregion

            #region 開啟Server與連線
            MyService = new OPCUA_Server(
           new ToConnectOPCUA.Classes.ReferenceServer<OpcuaNode>(
               retrunListOfNodes.ToList<OpcuaNode>()));
            ReferenceNodeManagerObj._actonDelegate = new Func<Dictionary<string, BaseDataVariableState>, bool>(GetNodeValue);
            ReferenceNodeManagerObj.CycleUpdateVal.IsBackground = true;
            ReferenceNodeManagerObj.CycleUpdateVal.Start();
            #endregion

            #region 給予數值
            List<string> a = new List<string>();
            List<DataType> b = new List<DataType>();
            List<object> c = new List<object>();
            a.Add("PLC1_Connection");
            a.Add("PLC1_Point2");
            a.Add("PLC1_Point3");
            a.Add("PLC1_Point4");
            a.Add("PLC2_Connection");
            a.Add("PLC2_Point2");
            b.Add(DataType.Boolean);
            b.Add(DataType.Double);
            b.Add(DataType.Double);
            b.Add(DataType.Double);
            b.Add(DataType.Boolean);
            b.Add(DataType.Double);
            c.Add(false);
            c.Add(2.36);
            c.Add(3.55);
            c.Add(7.36);
            c.Add(true);
            c.Add(3.36);
            ReferenceNodeManagerObj.SetValues(a, b, c);
            new Thread(() =>
            {
                SpinWait.SpinUntil(() => false, 10000);
                List<string> d = new List<string>();
                List<DataType> e = new List<DataType>();
                List<object> f = new List<object>();
                d.Add("PLC1_Connection");
                d.Add("PLC1_Point3");
                d.Add("PLC2_Connection");
                d.Add("PLC2_Point2");
                e.Add(DataType.Boolean);
                e.Add(DataType.Double);
                e.Add(DataType.Boolean);
                e.Add(DataType.Double);
                f.Add(true);
                f.Add(3.36);
                f.Add(false);
                f.Add(2.36);
                ReferenceNodeManagerObj.SetValues(d, e, f);
            }).Start();
            //ReferenceNodeManagerObj.SetValue("PLC1_Connection", DataType.Boolean, false);
            //ReferenceNodeManagerObj.SetValue("PLC1_Point2", DataType.Double, 2.36);
            //ReferenceNodeManagerObj.SetValue("PLC1_Point3", DataType.Double, 3.55);
            //ReferenceNodeManagerObj.SetValue("PLC1_Point4", DataType.Double, 7.36);
            //ReferenceNodeManagerObj.SetValue("PLC2_Connection", DataType.Boolean, false);
            //ReferenceNodeManagerObj.SetValue("PLC2_Point2", DataType.Double, 3.66);
            //new Thread(() =>
            //{
            //    SpinWait.SpinUntil(() => false, 2000);
            //    ReferenceNodeManagerObj.SetValue("PLC1_Connection", DataType.Boolean, true);
            //    ReferenceNodeManagerObj.SetValue("PLC2_Point3", DataType.Double, 6.2);
            //    ReferenceNodeManagerObj.SetValue("PLC2_Point4", DataType.Double, 8.0);
            //}).Start();
            #endregion
        }

        #region 建構樹狀list       
        /// <summary>
        /// 給予定義好的樹狀List 透過此方法會幫忙建構
        /// </summary>
        /// <param name="listNodeStruct"></param>
        public void BuildingTree(List<ListNodeStruct> listNodeStruct)
        {
            listNodeStruct.ForEach(listnode =>
            {
                if (listnode.NodeType == NodeType.GRC) retrunListOfNodes.Add(new NodeDataStruct() { NodeId = listnode.NodeID, NodeName = listnode.MainFolderName, NodePath = listnode.NodeID.ToString(), NodeType = listnode.NodeType, ParentPath = listnode.ParentPath, IsTerminal = listnode.IsRootEnd });

                listnode.SubNodeNames?.ForEach(subNode =>
                {
                    if (!subNode.IsRootEnd)
                    {
                        retrunListOfNodes.Add(new NodeDataStruct() { NodeId = subNode.NodeID, NodeName = subNode.MainFolderName, NodePath = subNode.NodeID.ToString(), NodeType = subNode.NodeType, ParentPath = subNode.ParentPath, IsTerminal = subNode.IsRootEnd });

                        BuildingTree(new List<ListNodeStruct>() {
                        new ListNodeStruct()
                        {
                            NodeID = Convert.ToInt32(string.Format("{0}", subNode.NodeID.ToString())),
                            MainFolderName = subNode.MainFolderName,
                            ParentPath = string.Format("{0}", listnode.NodeID.ToString()),
                            NodeType = subNode.NodeType,
                            IsRootEnd = subNode.IsRootEnd,
                            SubNodeNames = subNode.SubNodeNames
                        }
                        });
                    }
                    else
                    {
                        retrunListOfNodes.Add(new NodeDataStruct()
                        {
                            NodeId = subNode.NodeID,
                            NodeName = subNode.MainFolderName,
                            NodePath = subNode.NodeID.ToString(),
                            NodeType = subNode.NodeType,
                            ParentPath = subNode.ParentPath,
                            IsTerminal = subNode.IsRootEnd,
                            DataType = subNode.DataType
                        });
                    }

                });

            });
        }
        #endregion

        #region 值變時回傳
        /// <summary>
        /// 發生值變時回傳dictionary
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool GetNodeValue(Dictionary<string, BaseDataVariableState> obj)
        {
            return true;
        }

        #endregion

        private ServiceResult OnStopProcess(ISystemContext context, MethodState method, IList<object> inputArguments, IList<object> outputArguments)
        {
            return ServiceResult.Good;
        }

        private ServiceResult OnStartProcess(ISystemContext context, MethodState method, IList<object> inputArguments, IList<object> outputArguments)
        {
            return ServiceResult.Good;
        }

        #region PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion PropertyChangedEventHandler
    }
}

/*
 
            new List<NodeDataStruct>()
            {
               new NodeDataStruct(){NodeId=1,NodeName="GRC",NodePath="1",NodeType=NodeType.GRC,ParentPath="",IsTerminal=false },
               new NodeDataStruct(){NodeId=11,NodeName="PLC1",NodePath="11",NodeType=NodeType.PLC1,ParentPath="1",IsTerminal=false },
               new NodeDataStruct(){NodeId=12,NodeName="PLC2",NodePath="12",NodeType=NodeType.PLC2,ParentPath="1",IsTerminal=false},
               new NodeDataStruct(){NodeId=111,NodeName="PLC1_Connection",NodePath="111",NodeType=NodeType.Point,ParentPath="11", IsTerminal=true ,DataType =DataTypeIds.Boolean},
               new NodeDataStruct(){NodeId=112,NodeName="PLC1_Point2",NodePath="112",NodeType=NodeType.Point,ParentPath="11",IsTerminal=true ,DataType =DataTypeIds.Double},
               new NodeDataStruct(){NodeId=113,NodeName="PLC1_Point3",NodePath="113",NodeType=NodeType.Point,ParentPath="11",IsTerminal=true ,DataType =DataTypeIds.Double},
               new NodeDataStruct(){NodeId=114,NodeName="PLC1_Point4",NodePath="114",NodeType=NodeType.Point,ParentPath="11",IsTerminal=true ,DataType =DataTypeIds.Double},
               new NodeDataStruct(){NodeId=121,NodeName="PLC2_Connection",NodePath="121",NodeType=NodeType.Point,ParentPath="12",IsTerminal=true ,DataType =DataTypeIds.Boolean},
               new NodeDataStruct(){NodeId=122,NodeName="PLC2_Point2",NodePath="122",NodeType=NodeType.Point,ParentPath="12",IsTerminal=true ,DataType =DataTypeIds.Double}
            }
 
 */