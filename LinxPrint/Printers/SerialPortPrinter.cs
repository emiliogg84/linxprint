/*
    See LICENSE in the project root for license information.
*/

namespace LinxPrint.Printers
{
    using System.IO.Ports;

    public class SerialPortPrinter : ILinxPrinter
    {
        private readonly SerialPort _serialPort;

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

            //Event handling
            _serialPort.ErrorReceived += ErrorReceived;
        }

        private void ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {

        }

        public void Print(string text)
        {
            _serialPort.Open();
            try
            {
                _serialPort.WriteLine(text);
            }
            finally
            {
                _serialPort.Close();
            }
        }
    }
}
