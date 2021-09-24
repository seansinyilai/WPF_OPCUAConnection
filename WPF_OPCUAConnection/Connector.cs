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

            #endregion

            //  OPC_UAServerServices myService = new OPC_UAServerServices(new OPCUA_MethodOfCoding.Classes.ReferenceServer());

            MyService = new OPCUA_Server(
            new ToConnectOPCUA.Classes.ReferenceServer<OpcuaNode>(
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
            }.ToList<OpcuaNode>()));
            ReferenceNodeManagerObj._actonDelegate = new Func<Dictionary<string, BaseDataVariableState>, bool>(GetNodeValue);
            ReferenceNodeManagerObj.CycleUpdateVal.IsBackground = true;
            ReferenceNodeManagerObj.CycleUpdateVal.Start();
            ReferenceNodeManagerObj.SetValue("PLC1_Connection", DataType.Boolean, false);
            ReferenceNodeManagerObj.SetValue("PLC1_Point2", DataType.Double, 2.36);
            ReferenceNodeManagerObj.SetValue("PLC1_Point3", DataType.Double, 3.55);
            ReferenceNodeManagerObj.SetValue("PLC1_Point4", DataType.Double, 7.36);
            ReferenceNodeManagerObj.SetValue("PLC2_Connection", DataType.Boolean, false);
            ReferenceNodeManagerObj.SetValue("PLC2_Point2", DataType.Double, 3.66);

            new Thread(() =>
            {
                SpinWait.SpinUntil(() => false, 10000);
                ReferenceNodeManagerObj.SetValue("PLC1_Connection", DataType.Boolean, true);
            }).Start();


        }
        /// <summary>
        /// 發生值變時回傳dictionary
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool GetNodeValue(Dictionary<string, BaseDataVariableState> obj)
        {
            return true;
        }

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
