/*
    See LICENSE in the project root for license information.
*/

namespace LinxPrint
{
    using System;
    using System.IO;
    using System.Configuration;
    using System.Windows.Forms;
    using LinxPrint.Model;
    using LinxPrint.Printers;
    using System.Collections.Generic;

    public partial class MainForm : Form
    {
        private readonly ItemsManager _itemsManager;
        private string _portName = "COM1";

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _portName = ConfigurationManager.AppSettings.Get("ComPortName");

            dateToolStripTextBox.Text = DateTime.Now.ToShortDateString();

            UpdateComponentStatus();
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
                var items = _itemsManager.GetByCreated(date);
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

            var printed = true;
            var items = bindingSource.List;

            this.Cursor = Cursors.WaitCursor;
            ShowPrintingProgress();

            try
            {
                foreach (var item in items)
                {
                    var typedItem = item as Item;
                    if (printer.Print(typedItem.Code))
                    {
                        //Set post print values
                        typedItem.Printed = true;
                        typedItem.PrintedOn = DateTime.Now;
                        _itemsManager.UpdateItem(typedItem);
                    }
                    else
                        printed = false;

                    Application.DoEvents(); //Simulate asynchronous processing
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, string.Format("{0} - ERROR!", this.Text));
            }
            finally
            {
                this.Cursor = Cursors.Default;
                HidePrintingProgress();
            }

            bindingSource.ResetBindings(false);

            if (!printed)
                MessageBox.Show("Algunos códigos no se imprimieron debido a problemas con el dispositivo, revise la lista!!");
        }

        private void HidePrintingProgress()
        {
            progressBarToolStrip.Enabled = false;
            progressBarToolStrip.Visible = false;
            progressLabelToolStrip.Visible = false;
        }

        private void ShowPrintingProgress()
        {
            progressLabelToolStrip.Text = "Imprimiendo...";
            progressLabelToolStrip.Visible = true;
            progressBarToolStrip.Enabled = true;
            progressBarToolStrip.Visible = true;
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

            UpdateComponentStatus();
        }

        private void UpdateComponentStatus()
        {
            portNameToolStrip.Text = string.Format("Puerto: {0}", _portName);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> codes = new List<string>();

            using (var openFileDlg = new OpenFileDialog() { Title = "Importar", Filter = "TXT|*.txt"})
            {
                if (openFileDlg.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    ShowImportingProgress();
                    try
                    {
                        using (var sr = new StreamReader(openFileDlg.FileName))
                        {
                            while (!sr.EndOfStream)
                            {
                                var text = sr.ReadLine();
                                codes.Add(text);
                            }

                            _itemsManager.AddItemCodes(codes.ToArray());
                            dateToolStripTextBox_TextChanged(dateToolStripTextBox, null);
                        }
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                        HideImportingProgess();
                    }
                }
            }
        }

        private void HideImportingProgess()
        {
            progressBarToolStrip.Enabled = false;
            progressBarToolStrip.Visible = false;
            progressLabelToolStrip.Visible = false;
        }

        private void ShowImportingProgress()
        {
            progressLabelToolStrip.Text = "Importando...";
            progressLabelToolStrip.Visible = true;
            progressBarToolStrip.Enabled = true;
            progressBarToolStrip.Visible = true;
        }

        private void bindingSource_AddingNew(object sender, System.ComponentModel.AddingNewEventArgs e)
        {
            e.NewObject = new Item();
        }

        private void dataGridView_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            var item = dataGridView.Rows[e.RowIndex].DataBoundItem as Item;

            if (item == null) return;

            if (item.Id <= 0)
                _itemsManager.AddItem(item);
            else
                _itemsManager.UpdateItem(item);
        }

        private void printSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedRows = dataGridView.SelectedRows;

            ILinxPrinter printer = new SerialPortPrinter(_portName);

            var printed = true;
            var items = bindingSource.List;

            this.Cursor = Cursors.WaitCursor;
            ShowPrintingProgress();

            try
            {
                foreach (DataGridViewRow selectedRow in selectedRows)
                {
                    var typedItem = selectedRow.DataBoundItem as Item;
                    if (printer.Print(typedItem.Code))
                    {
                        //Set post print values
                        typedItem.Printed = true;
                        typedItem.PrintedOn = DateTime.Now;
                        _itemsManager.UpdateItem(typedItem);
                    }
                    else
                        printed = false;

                    Application.DoEvents(); //Simulate asynchronous processing
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, string.Format("{0} - ERROR!", this.Text));
            }
            finally
            {
                this.Cursor = Cursors.Default;
                HidePrintingProgress();
            }

            bindingSource.ResetBindings(false);

            if (!printed)
                MessageBox.Show("Algunos códigos no se imprimieron debido a problemas con el dispositivo, revise la lista!!");
        }

        private void serialPortConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("PortName: {0} \n BaudRate: 9600\n Parity: None\n DataBits: 8\n StopBits: One\n Handshake: None", _portName),
                "SerialPort");
        }

        private void editModeToolStripButton_Click(object sender, EventArgs e)
        {
            editModeToolStripMenuItem.PerformClick();
        }

        private void editModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView.ReadOnly = !editModeToolStripMenuItem.Checked;
            editModeToolStripButton.Checked = editModeToolStripMenuItem.Checked;
        }
    }
}
