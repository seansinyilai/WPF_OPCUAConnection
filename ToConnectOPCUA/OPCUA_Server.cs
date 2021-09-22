using Opc.Ua;
using Opc.Ua.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ToConnectOPCUA.Classes;

namespace ToConnectOPCUA
{
    public class OPCUA_Server : INotifyPropertyChanged
    {
        private ReferenceServer<OpcuaNode> _RefServer;

        public ReferenceServer<OpcuaNode> RefServer
        {
            get { return _RefServer; }
            set
            {
                _RefServer = value;
                NotifyPropertyChanged();
            }
        }

        public OPCUA_Server(ServerBase serverbaseobj)
        {
            RefServer = serverbaseobj as ReferenceServer<OpcuaNode>;
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
                application.LoadApplicationConfiguration(string.Format("{0}{1}", appStartupPath, @"\GPPlantServer.Config.xml"), false).Wait();
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
        #region PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion PropertyChangedEventHandler
    }
}
