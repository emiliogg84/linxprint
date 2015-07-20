/*
    See LICENSE in the project root for license information.
*/

namespace LinxPrint
{
    using System;
    using System.Windows.Forms;
    using LinxPrint.Model;
    using LinxPrint.Printers;

    public partial class MainForm : Form
    {
        private readonly ItemsManager _itemsManager;
        private string _portName = "COM1";

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            dateToolStripTextBox.Text = DateTime.Now.ToShortDateString();
        }

        public MainForm()
        {
            InitializeComponent();

            _itemsManager = new ItemsManager();
        }

        private void editModeToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView.ReadOnly = !editModeToolStripMenuItem.Checked;
        }

        private void dataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (e.Row.IsNewRow)
                _itemsManager.AddItem(e.Row.DataBoundItem as Item);
            else
                _itemsManager.UpdateItem(e.Row.DataBoundItem as Item);
        }

        private void dataGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            _itemsManager.DeleteItem(e.Row.DataBoundItem as Item);
        }

        private void dateToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            string dateStr = dateToolStripTextBox.Text;
            DateTime date = DateTime.Now;

            if (DateTime.TryParse(dateStr, out date))
            {
                var items = _itemsManager.GetByCreated(dateToolStripTextBox.Text);
                bindingSource.DataSource = items;
                bindingSource.ResetBindings(false);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource.RemoveCurrent();
        }

        private void printAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ILinxPrinter printer = new SerialPortPrinter(_portName);

            var items = bindingSource.List;

            this.Cursor = Cursors.WaitCursor;
            ShowPrintingProgress();

            try
            {
                foreach (var item in items)
                {
                    var typedItem = item as Item;
                    printer.Print(typedItem.Code);
                    //Set post print values
                    typedItem.Printed = true;
                    typedItem.PrintedOn = DateTime.Now;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
                HidePrintingProgress();
            }
        }

        private void HidePrintingProgress()
        {
            progressBarToolStrip.Enabled = false;
            progressBarToolStrip.Visible = false;
            progressLabelToolStrip.Visible = false;
        }

        private void ShowPrintingProgress()
        {
            progressBarToolStrip.Enabled = true;
            progressBarToolStrip.Visible = true;
            progressLabelToolStrip.Visible = true;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var settingsForm = new SettingsForm())
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    _portName = settingsForm.PortName;
                }
            }
        }
    }
}
