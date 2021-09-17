using GPPlant;
using Opc.Ua;
using Opc.Ua.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPC_UA_Library
{
    public class GPPlantServer : StandardServer
    {
        private List<INodeManager> _nodeManager;

        public List<INodeManager> NodeManager
        {
            get { return _nodeManager; }
            set { _nodeManager = value; }
        }
        private GPPlantState _GPPlantObj;

        public GPPlantState GPPlantObj
        {
            get { return _GPPlantObj; }
            set { _GPPlantObj = value; }
        }
        private GPPlantNodeManager _GPPlantNodeManager;

        public GPPlantNodeManager GPPlantNodeManager
        {
            get { return _GPPlantNodeManager; }
            set { _GPPlantNodeManager = value; }
        }

        public GPPlantServer()
        {
            GPPlantObj = new GPPlantState(null);
        }

        protected override MasterNodeManager CreateMasterNodeManager(IServerInternal server, ApplicationConfiguration configuration)
        {           
            Utils.Trace("Creating the Node Managers.");
            GPPlantNodeManager = new GPPlantNodeManager(server, configuration, GPPlantObj);
            NodeManager = new List<INodeManager>();
            NodeManager.Add(GPPlantNodeManager);           
            return new MasterNodeManager(server, configuration, null, NodeManager.ToArray());
        }

        protected override ServerProperties LoadServerProperties()
        {
            return new ServerProperties()
            {
                ManufacturerName = "GP_GROUP_SOF",
                ProductName = "GPPlant InformationModel Server",
                ProductUri = "http://opcfoundation.org/GPPlant/InformationModelServer/v1.0",
                SoftwareVersion = Utils.GetAssemblySoftwareVersion(),
                BuildNumber = Utils.GetAssemblyBuildNumber(),
                BuildDate = Utils.GetAssemblyTimestamp()
            };
        }
    }
}
