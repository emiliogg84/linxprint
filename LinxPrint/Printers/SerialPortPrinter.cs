/*
    See LICENSE in the project root for license information.
*/

namespace LinxPrint.Printers
{
    using System.Threading;
    using System.IO.Ports;
    using LinxPrint.Log;

    public class SerialPortPrinter : ILinxPrinter
    {
        private readonly SerialPort _serialPort;
        private bool _printed = false;
        private string _currentText;

        public SerialPortPrinter(string portName)
        {
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

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (e.EventType == SerialData.Eof) return;
            var received = _serialPort.ReadExisting();
            if (received.Contains(1.ToString()))
            {
                _printed = true;
                LogFactory.CreateLog().LogInfo(string.Format("Successfully printed text: {0}", _currentText));
            }
        }

        private void ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            if (_serialPort.IsOpen) _serialPort.Close();
            LogFactory.CreateLog().LogError(string.Format("Error received for text: {0}", _currentText), null, null);
        }

        public bool Print(string text)
        {
            _currentText = text;
            _printed = false;
            _serialPort.Open();

            try
            {
                _serialPort.WriteLine(text);

                while (!_printed && _serialPort.IsOpen)
                {
                    Thread.Sleep(100);
                }
            }
            finally
            {
                if (_serialPort.IsOpen) _serialPort.Close();
            }

            return _printed;
        }
    }
}
