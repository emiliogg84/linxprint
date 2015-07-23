/*
    See LICENSE in the project root for license information.
*/

namespace LinxPrint
{
    using System;
    using System.IO.Ports;
    using System.Windows.Forms;

    public partial class SettingsForm : Form
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            string[] ports = SerialPort.GetPortNames();

            cbxPortNames.Items.AddRange(ports);
            
            if (cbxPortNames.Items.Count > 0)
                cbxPortNames.SelectedIndex = 1;
        }

        public SettingsForm()
        {
            InitializeComponent();
        }

        public string PortName
        {
            get { return cbxPortNames.Text; }
        }
    }
}
