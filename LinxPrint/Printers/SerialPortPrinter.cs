/*
    See LICENSE in the project root for license information.
*/

namespace LinxPrint.Printers
{
    using System;
    using System.Threading;
    using System.IO.Ports;

    public class SerialPortPrinter : ILinxPrinter
    {
        private readonly SerialPort _serialPort;
        private bool _printed = false;

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
            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;

            // Event handling
            _serialPort.DataReceived += DataReceived;
            _serialPort.ErrorReceived += ErrorReceived;
        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (e.EventType == SerialData.Eof) return;
            var received = _serialPort.ReadExisting();
            if (received.Contains(1.ToString())) _printed = true;
        }

        private void ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            if (_serialPort.IsOpen) _serialPort.Close();
        }

        public bool Print(string text)
        {
            _printed = false;
            _serialPort.Open();

            try
            {
                _serialPort.WriteLine(text);

                var attempt = 0;

                while (!_printed && attempt < 5)
                {
                    Thread.Sleep(100);
                    attempt++;
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
