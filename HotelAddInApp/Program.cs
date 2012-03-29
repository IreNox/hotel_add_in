using System;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using HotelAddIn;

namespace HotelAddInApp
{
    static class Program
    {
        #region Vars
        private static formMain _form;

        private static LodgitAddIn _addIn;
        #endregion

        #region Private Member - IPC
        private static void _registerIpcServer()
        {
            IDictionary props = new Hashtable();
            BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();

            props["portName"] = "hotel";
            props["authorizedGroup"] = "Jeder";

            provider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

            ChannelServices.RegisterChannel(new IpcServerChannel(props, provider), false);

            try
            {
                RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
                RemotingConfiguration.RegisterWellKnownServiceType(
                    typeof(HotelAddInIPC),
                    "HotelAddInIPC.rem",
                    WellKnownObjectMode.SingleCall
                );                
            }
            catch (Exception ex)
            {
                MessageBox.Show("IPC konnte nicht registiert weden. Fehler: " + ex.Message, "HotelAddIn");
            }
        }

        private static void _registerIpcClient()
        {
            IDictionary props = new Hashtable();
            BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();

            props["port"] = 0;
            props["portName"] = Guid.NewGuid().ToString();
            props["name"] = Guid.NewGuid().ToString();
            props["authorizedGroup"] = "Jeder";

            provider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

            ChannelServices.RegisterChannel(new IpcChannel(props, null, provider), false);

            try
            {
                RemotingConfiguration.RegisterWellKnownClientType(
                    typeof(HotelAddInIPC),
                    "ipc://hotel/HotelAddInIPC.rem"
                );
            }
            catch
            {
            }
        }
        #endregion

        #region Main
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Process.GetProcessesByName("HotelAddInApp").Length == 1)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                _registerIpcServer();

                _form = new formMain();
                _addIn = _form.AddIn;

                Application.Run(_form);

                _addIn.Dispose();
            }
            else
            {
                _registerIpcClient();

                var ipcClient = new HotelAddInIPC();

                ipcClient.ShowForm();
            }
        }
        #endregion

        #region Fields
        public static formMain Form
        {
            get { return _form; }
        }

        public static LodgitAddIn AddIn
        {
            get { return _addIn; }
            set { _addIn = value; }
        }
        #endregion
    }

    #region Class - HotelAddInIPC
    public class HotelAddInIPC : MarshalByRefObject
    {
        public void ShowForm()
        {
            if (Program.Form.InvokeRequired)
            {
                Program.Form.Invoke(
                    new Action(this.ShowForm)
                );
                return;
            }

            Program.Form.Show();
        }
    }
    #endregion
}
