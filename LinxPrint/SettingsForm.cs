/*
    See LICENSE in the project root for license information.
*/

namespace LinxPrint
{
    using System.Windows.Forms;

    public partial class SettingsForm : Form
    {
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
