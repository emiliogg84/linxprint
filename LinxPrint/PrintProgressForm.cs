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
        private readonly string _portName;
        private readonly string _machineName;
        private IList<Item> _items;
        private string _currentCode = string.Empty;
        private int _currentRecNo = 0;
        private int _index = 0;
        private bool _printing = false;
        private bool _paused = false;
        private bool _printSimulation = false;
        private System.Timers.Timer _timer;

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
            _currentRecNo = _items[0].RecNo;
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
                    _currentRecNo = _items[_index].RecNo;
                    ShowPrintingInfo();
                    Print(_currentCode);
                }
                else
                {
                    _printing = false;
                    _currentCode = string.Empty;
                    _currentRecNo = 0;
                    if (_serialPort.IsOpen) _serialPort.Close();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }

            if (_index < _items.Count)
            {
                _currentCode = _items[_index].Code;
                _currentRecNo = _items[_index].RecNo;
                ShowPrintingInfo();
            }
            else
            {
                _timer.Enabled = false;
                _printing = false;
                _currentCode = string.Empty;
                _currentRecNo = 0;
                if (_serialPort.IsOpen) _serialPort.Close();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void SimulatePrintNextCode()
        {
            if (_index < _items.Count)
            {
                _currentCode = _items[_index].Code;
                _currentRecNo = _items[_index].RecNo;
                ShowPrintingInfo();
            }
            else
            {
                _timer.Enabled = false;
                _printing = false;
                _currentCode = string.Empty;
                _currentRecNo = 0;
                _printSimulation = false;
                btnPrint.Enabled = true;
                HidePrintingInfo();
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
            lbProgress.Text = string.Format("Imprimiendo pincode {0} de {1}, por favor espere...", _index + 1, _items.Count);
            lbCurrentCode.Text = string.Format("{0} - No.: {1}", _currentCode, _currentRecNo);
            progressBar.Enabled = true;
            progressBar.Visible = true;
        }

        private void HidePrintingInfo()
        {
            label2.Visible = false;
            lbCurrentCode.Visible = false;
            lbProgress.Visible = false;
            progressBar.Enabled = false;
            progressBar.Visible = false;
        }


        public PrintProgressForm()
        {
            InitializeComponent();
        }

        public PrintProgressForm(string portName, IList<Item> items)
        {
            InitializeComponent();

            _items = items;
            _portName = portName;
            _machineName = Environment.MachineName;
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

            //Timer
            _timer = new System.Timers.Timer();
            _timer.Interval = 2000;
            _timer.AutoReset = true;
            _timer.Enabled = false;
            _timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //Go to next item
            _index++;
            //Check status
            if (_paused) return;
            //Fire the next step
            var callback = new PrintNextCodeCallBack(SimulatePrintNextCode);
            this.Invoke(callback);
        }

        private void ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            if (_serialPort.IsOpen) _serialPort.Close();
            LogFactory.CreateLog().LogError(string.Format("Error received for text: {0}", _currentCode), null);
            //Fire the next step
            var callback = new PrintNextCodeCallBack(PrintNextCode);
            this.Invoke(callback);
        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (_index >= _items.Count)
            {
                _printing = false;
                return;
            }

            if (e.EventType == SerialData.Eof)
                return;

            var received = _serialPort.ReadExisting();

            if (received.Contains(1.ToString()))
            {
                LogFactory.CreateLog().LogInfo(string.Format("Successfully printed text: {0}", _currentCode));
                //Set printed values
                var item = _items[_index];
                item.Printed = true;
                item.PrintedOn = DateTime.Now;
                item.PrintedDetails = string.Format("PC: {0}, Puerto: {1}", _machineName, _portName);
                //Go to next item
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

            _index = 0;
            _paused = false;
            _printing = true;
            _currentCode = string.Empty;
            _currentRecNo = 0;
            _printSimulation = false;
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
                lbProgress.Text = "Impresión detenida, presione resumir para continuar";
                progressBar.Enabled = false;
            }
            else
            {
                _paused = false;
                btnPrintPause.Text = "Pausar";

                if (_printSimulation)
                    SimulatePrintNextCode();
                else
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

        private void btnSimulatePrinting_Click(object sender, EventArgs e)
        {
            _index = 0;
            _paused = false;
            _printing = true;
            _currentCode = string.Empty;
            _currentRecNo = 0;
            _printSimulation = true;
            btnPrintPause.Enabled = true;
            btnPrint.Enabled = false;
            _timer.Enabled = true;

            SimulatePrintNextCode();
        }
    }
}
