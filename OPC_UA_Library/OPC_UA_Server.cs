using Opc.Ua;
using Opc.Ua.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPC_UA_Library
{
    public class OPC_UA_Server
    {
        private GPPlantServer _GPPlantServer;

        public GPPlantServer GPPlantServer
        {
            get { return _GPPlantServer; }
            set { _GPPlantServer = value; }
        }

        public OPC_UA_Server(ServerBase serverbaseobj)
        {
            GPPlantServer = serverbaseobj as GPPlantServer;
            string appStartupPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            ApplicationInstance application = new ApplicationInstance();
            application.ApplicationType = ApplicationType.Server;
            application.ConfigSectionName = "GPPlantServer";
            try
            {
                if (application.ProcessCommandLine())
                {
                    return;
                }
                if (!Environment.UserInteractive)
                {
                    application.StartAsService(serverbaseobj);
                    return;
                }
                application.LoadApplicationConfiguration(string.Format("{0}{1}",appStartupPath, @"\GPPlantServer.Config.xml"),false).Wait();
                application.CheckApplicationInstanceCertificate(false, 0).Wait();
                application.Start(serverbaseobj).Wait();
            }
            catch (Exception e)
            {
                string text = "Exception: " + e.Message;
                if (e.InnerException != null)
                {
                    text += "\r\nInner exception: ";
                    text += e.InnerException.Message;
                }
             //   MessageBox.Show(text, application.ApplicationName);
            }
        }
    }
}
