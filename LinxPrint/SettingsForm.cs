/*
    See LICENSE in the project root for license information.
*/

namespace LinxPrint
{
    using System;
    using System.IO.Ports;
    using System.Configuration;
    using System.Windows.Forms;

    public partial class SettingsForm : Form
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            string[] ports = SerialPort.GetPortNames();

            cbxPortNames.Items.AddRange(ports);

            var comPortName = ConfigurationManager.AppSettings.Get("ComPortName");

            if (string.IsNullOrWhiteSpace(comPortName))
            {
                if (cbxPortNames.Items.Count > 0)
                    cbxPortNames.SelectedIndex = 0;
            }
            else
            {
                var index = cbxPortNames.Items.IndexOf(comPortName);

                if (index > -1)
                    cbxPortNames.SelectedIndex = index;
            }
         }

        public SettingsForm()
        {
            InitializeComponent();
        }

        public string PortName
        {
            get { return cbxPortNames.Text; }
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings.Remove("ComPortName");
                configuration.AppSettings.Settings.Add(new KeyValueConfigurationElement("ComPortName", cbxPortNames.Text));
                configuration.Save();
                ConfigurationManager.RefreshSection("AppSettings");
            }
        }
    }
}
