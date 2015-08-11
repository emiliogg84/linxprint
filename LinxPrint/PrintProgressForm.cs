/*
    See LICENSE in the project root for license information.
*/

namespace LinxPrint
{
    using System;
    using System.IO.Ports;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using LinxPrint.Model;
    using LinxPrint.Printers;
    using LinxPrint.Log;

    public partial class PrintProgressForm : Form
    {
        private readonly ILinxPrinter _printer;
        private IList<Item> _items;
        private string _currentCode = string.Empty;
        private int _index = 0;
        private bool _printing = false;
        private bool _paused = false;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            lbTotalCodes.Text = _items.Count.ToString();
            label2.Visible = false;
            lbProgress.Visible = false;
            lbCurrentCode.Visible = false;
            progressBar.Visible = false;
            btnPrintPause.Enabled = false;
            btnPrint.Enabled = _items.Count > 0;
            _currentCode = _items[0].Code;
        }

        public PrintProgressForm()
        {
            InitializeComponent();
        }

        public PrintProgressForm(string portName, IList<Item> items)
        {
            InitializeComponent();

            _printer = new SerialPortPrinter(portName);
            _items = items;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintCodes();
        }

        private void PrintCodes()
        {
            if (_printer.Connect())
            {
                label2.Visible = true;
                lbCurrentCode.Visible = true;
                lbProgress.Visible = true;
                progressBar.Enabled = true;
                progressBar.Visible = true;
                btnPrintPause.Enabled = true;
                btnPrint.Enabled = false;

                _printing = true;

                try
                {
                    for (int i = 0; i < _items.Count; i++)
                    {
                        var item = _items[i];

                        if (_paused) break;
                        if (item.Printed) continue;

                        lbProgress.Text = string.Format("Imprimiendo pincode {0} de {1}, por favor espere...", i + 1, _items.Count);
                        lbCurrentCode.Text = item.Code;

                        if (_printer.Print(item.Code))
                        {
                            item.Printed = true;
                            item.PrintedOn = DateTime.Now;
                        }
                        else
                        {
                            MessageBox.Show("Ocurrio un problema durante la impresión, vea el log para más información", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }

                    if (!_paused)
                        MessageBox.Show("Impresión finalizada correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    _printing = false;
                    _printer.Disconect();
                }
            }
            else
            {
                MessageBox.Show("Ocurrio un problema cuando se intentaba conectar con el dispositivo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!_paused)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnPrintPause_Click(object sender, EventArgs e)
        {
            if (btnPrintPause.Text == "Pausar")
            {
                _paused = true;
                btnPrintPause.Text = "Resumir";
                lbProgress.Text = "Impresión detenida, presione Resumir para continuar";
                progressBar.Enabled = false;
            }
            else
            {
                _paused = false;
                progressBar.Enabled = true;
                btnPrintPause.Text = "Pausar";
                PrintCodes();
            }
        }

        private void PrintProgressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_printing)
                if (MessageBox.Show("¿Desea cancelar la impresión?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _paused = true;
                }
        }
    }
}
