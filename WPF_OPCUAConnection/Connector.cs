using Opc.Ua;
using OPC_UA_Library;
using OPCUA_MethodOfCoding;
using OPCUA_MethodOfCoding.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToConnectOPCUA;
using ToConnectOPCUA.Classes;

namespace WPF_OPCUAConnection
{
    public class Connector
    {
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
           
            OPCUA_Server myService = new OPCUA_Server(
                new ToConnectOPCUA.Classes.ReferenceServer<NodeDataStruct>(
                new List<NodeDataStruct>()
                {
                  new NodeDataStruct(){NodeId=1,NodeName="GRC",NodePath="1",NodeType=NodeType.GRC,ParentPath="",IsTerminal=false },
                  new NodeDataStruct(){NodeId=11,NodeName="PLC1",NodePath="11",NodeType=NodeType.PLC1,ParentPath="1",IsTerminal=false },
                  new NodeDataStruct(){NodeId=12,NodeName="PLC2",NodePath="12",NodeType=NodeType.PLC2,ParentPath="1",IsTerminal=false},
                  new NodeDataStruct(){NodeId=111,NodeName="Connection",NodePath="111",NodeType=NodeType.Point,ParentPath="11", IsTerminal=true ,DataType =DataTypeIds.Boolean},
                  new NodeDataStruct(){NodeId=112,NodeName="Point2",NodePath="112",NodeType=NodeType.Point,ParentPath="11",IsTerminal=true ,DataType =DataTypeIds.Double},
                  new NodeDataStruct(){NodeId=113,NodeName="Point3",NodePath="113",NodeType=NodeType.Point,ParentPath="11",IsTerminal=true ,DataType =DataTypeIds.Double},
                  new NodeDataStruct(){NodeId=114,NodeName="Point4",NodePath="114",NodeType=NodeType.Point,ParentPath="11",IsTerminal=true ,DataType =DataTypeIds.Double},
                  new NodeDataStruct(){NodeId=121,NodeName="Connection",NodePath="121",NodeType=NodeType.Point,ParentPath="12",IsTerminal=true ,DataType =DataTypeIds.Boolean},
                  new NodeDataStruct(){NodeId=122,NodeName="Point2",NodePath="122",NodeType=NodeType.Point,ParentPath="12",IsTerminal=true ,DataType =DataTypeIds.Double}
                }));
        }

        private ServiceResult OnStopProcess(ISystemContext context, MethodState method, IList<object> inputArguments, IList<object> outputArguments)
        {
            return ServiceResult.Good;
        }

        private ServiceResult OnStartProcess(ISystemContext context, MethodState method, IList<object> inputArguments, IList<object> outputArguments)
        {
            return ServiceResult.Good;
        }
    }
}
