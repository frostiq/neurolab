using System;
using System.Windows.Forms;
using System.Configuration;
using System.Collections;
using UDP;
using NeuroUtilities;


namespace UI
{
    public partial class SecurePassMain : Form
    {

        #region Private variables
        private Server _server;
        private NeuroController _neuroController = new NeuroController();
        #endregion

        #region Constructor
        public SecurePassMain()
        {
            InitializeComponent();
        }
        #endregion

        #region SecurePassMain_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SecurePassMain_Load(object sender, EventArgs e)
        {
            btnStopServer.Enabled = false;
            //display values on UI
        }
        #endregion

        #region MainUiDataHandleUpdate
        private object MainUiDataHandleUpdate(object Message)
        {

            if (InvokeRequired)
                Invoke(new Func<object,object>(MainUiDataHandleUpdate), Message);
            else
            {
                var values = (double[]) Message;
                lstDataHandleUpdate.Items.Add(string.Join(",",values));
            }
            return Message;
        }
        #endregion


        #region GetConfigParameters
        /// <summary>
        /// Get config parameters from application parameters 
        /// </summary>
        /// <returns></returns>
        private Hashtable GetConfigParameters()
        {
            Hashtable configParameters = new Hashtable();

            for (int i = 0; i < ConfigurationManager.AppSettings.Count; i++)
            {
                configParameters.Add(ConfigurationManager.AppSettings.Keys[i], ConfigurationManager.AppSettings[i]);
            }
            return configParameters;
        }
        #endregion

        #region btnStartListener_Click
        /// <summary>
        /// start listener event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartListener_Click(object sender, EventArgs e)
        {
            btnStartListener.Enabled = false;
            StartSecurePassServer();
            btnStopServer.Enabled = true;

        }
        #endregion

        /// <summary>
        /// Start Secure Pass Server
        /// </summary>
        private void StartSecurePassServer()
        {
            try
            {
                _server = new Server(int.Parse(ConfigurationManager.AppSettings["ServerPort"]));
                _server.OnProcess += MainUiDataHandleUpdate;
                _server.OnProcess += ServerOnOnProcess;
                _server.Start();
                btnStartListener.Text = "Server Started";
                btnStartListener.Enabled = false;
                btnStopServer.Enabled = true;
            }
            catch (Exception ex)
            {
   
               
            }
        }

        private object ServerOnOnProcess(object obj)
        {
            var values = (double[]) obj;
            return _neuroController.Compute(values[0], values[1]);
        }

        private void cmdClearUI_Click(object sender, EventArgs e)
        {
            lstAlarmData.Items.Clear();
            lstDataHandleUpdate.Items.Clear();
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            btnStopServer.Enabled = false;
            _server.Stop();
            btnStartListener.Enabled = true;
        }

        private void cmdSendCommand_Click(object sender, EventArgs e)
        {
            //_server.SendInformation();
        }

        private void SecurePassMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            _server.Stop();
        }
    }
}
