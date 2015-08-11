﻿/*
    See LICENSE in the project root for license information.
*/

namespace LinxPrint.Printers
{
    using System;
    using System.Threading;
    using System.Windows.Forms;
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
                LogFactory.CreateLog().LogInfo(string.Format("Successfully printed code: {0}", _currentText));
            }
        }

        private void ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            if (_serialPort.IsOpen) _serialPort.Close();
            LogFactory.CreateLog().LogError(string.Format("Error received for code: {0}", _currentText), null);
        }

        public bool Print(string text)
        {
            if (!_serialPort.IsOpen) return false;

            _currentText = text;
            _printed = false;

            _serialPort.WriteLine(text);

            while (!_printed && _serialPort.IsOpen)
            {
                Thread.Sleep(100);
                Application.DoEvents();
            }

            return _printed;
        }

        public bool Connect()
        {
            try
            {
                _serialPort.Open();
            }
            catch (Exception ex)
            {
                LogFactory.CreateLog().LogError("Invoke to Connect throw an exception", ex);
            }

            return _serialPort.IsOpen;
        }

        public void Disconect()
        {
            if (_serialPort.IsOpen)
                _serialPort.Close();
        }
    }
}
