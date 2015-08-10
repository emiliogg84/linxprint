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
    using LinxPrint.Log;

    public partial class PrintProgressForm : Form
    {
        private readonly SerialPort _serialPort;
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

        private delegate void PrintNextCodeCallBack();

        private void PrintNextCode()
        {
            if (!_serialPort.IsOpen)
            {
                MessageBox.Show("Ocurrio un problema durante la impresión, vea el log para más información", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _printing = false;
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else
            {
                if (_index < _items.Count)
                {
                    _currentCode = _items[_index].Code;
                    Print(_currentCode);
                    ShowPrintingInfo();
                }
                else
                {
                    _printing = false;
                    _currentCode = string.Empty;
                    if (_serialPort.IsOpen) _serialPort.Close();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        public void Print(string text)
        {
            if (_serialPort.IsOpen)
                _serialPort.WriteLine(text);
        }

        private void ShowPrintingInfo()
        {
            label2.Visible = true;
            lbCurrentCode.Visible = true;
            lbProgress.Visible = true;
            lbProgress.Text = string.Format("Imprimiendo pincode {0} de {1}, por favor espere...", _index, _items.Count);
            lbCurrentCode.Text = _currentCode;
            progressBar.Enabled = true;
            progressBar.Visible = true;
        }


        public PrintProgressForm()
        {
            InitializeComponent();
        }

        public PrintProgressForm(string portName, IList<Item> items)
        {
            InitializeComponent();

            _items = items;

            // Create a new SerialPort object with default settings.
            _serialPort = new SerialPort();

            // Allow the user to set the appropriate properties.
            _serialPort.PortName = portName;
            _serialPort.BaudRate = 9600;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Handshake = Handshake.None;
            // Set the read/write timeouts
            _serialPort.ReadTimeout = -1;
            _serialPort.WriteTimeout = -1;

            // Event handling
            _serialPort.DataReceived += DataReceived;
            _serialPort.ErrorReceived += ErrorReceived;
        }

        private void ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            if (_serialPort.IsOpen) _serialPort.Close();
            LogFactory.CreateLog().LogError(string.Format("Error received for text: {0}", _currentCode), null);
        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (e.EventType == SerialData.Eof)
            {
                if (_index >= _items.Count)
                    _printing = false;
                return;
            }

            var received = _serialPort.ReadExisting();
            if (received.Contains(1.ToString()))
            {
                LogFactory.CreateLog().LogInfo(string.Format("Successfully printed text: {0}", _currentCode));
                //Set printed values
                var item = _items[_index];
                item.Printed = true;
                item.PrintedOn = DateTime.Now;
                //Go to the next item
                _index++;
                //Check status
                if (_paused) return;
                //Fire the next step
                var callback = new PrintNextCodeCallBack(PrintNextCode);
                this.Invoke(callback);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                _serialPort.Open();
            }
            catch (Exception ex)
            {
                LogFactory.CreateLog().LogError("Invoke to Connect throw an exception", ex);
                MessageBox.Show("Ocurrio un problema cuando se intentaba conectar con el dispositivo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!_serialPort.IsOpen) return;

            _printing = true;
            btnPrintPause.Enabled = true;
            btnPrint.Enabled = false;

            PrintNextCode();
        }

        private void btnPrintPause_Click(object sender, EventArgs e)
        {
            if (btnPrintPause.Text == "Pausar")
            {
                _paused = true;
                btnPrintPause.Text = "Resumir";
                lbProgress.Text = "Impresión en pausa, presione resumir para continuar";
                progressBar.Enabled = false;
            }
            else
            {
                _paused = false;
                btnPrintPause.Text = "Pausar";
                PrintNextCode();
            }
        }

        private void PrintProgressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_printing)
                if (MessageBox.Show("¿Desea cancelar la impresión?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_serialPort.IsOpen) _serialPort.Close();
                }
        }
    }
}
