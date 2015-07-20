/*
    See LICENSE in the project root for license information.
*/

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace LinxPrint.Log
{
    using System;
    using System.Reflection;
    using System.Globalization;

    public class Log4NetLog : ILog
    {
        // Create a logger for use in this class
        private readonly log4net.ILog _log;

        public Log4NetLog()
        {
            _log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
        /*
        /// <summary>
        /// <see cref="DokuFlex.Windows.Common.Log.ILog"/>
        /// </summary>
        /// <param name="message"><see cref="DokuFlex.Windows.Common.Log.ILog"/></param>
        /// <param name="args"><see cref="DokuFlex.Windows.Common.Log.ILog"/></param>
        public void LogError(string message, params object[] args)
        {
            Exception exception = args[0] as Exception;

            if (!String.IsNullOrWhiteSpace(message))
            {
                var messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                _log.Error(messageToTrace);
            }
        }*/

        /// <summary>
        /// <see cref="DokuFlex.Windows.Common.Log.ILog"/>
        /// </summary>
        /// <param name="message"><see cref="DokuFlex.Windows.Common.Log.ILog"/></param>
        /// <param name="exception"><see cref="DokuFlex.Windows.Common.Log.ILog"/></param>
        /// <param name="args"><see cref="DokuFlex.Windows.Common.Log.ILog"/></param>
        public void LogError(string message, Exception exception, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(message) && exception != null)
            {
                var messageToTrace = string.Format(CultureInfo.InvariantCulture, message, args);

                var exceptionData = exception.ToString(); // The ToString() create a string representation of the current exception

                _log.Error(String.Format(CultureInfo.InvariantCulture, "{0} Exception:{1}", messageToTrace, exceptionData));

                //Enviar al server
                Assembly asm = exception.TargetSite.Module.Assembly;
                AssemblyName name = asm.GetName();
            }
        }

        public void LogError(Exception exception)
        {
            if (exception != null)
            {
                var messageToTrace = string.Format(CultureInfo.InvariantCulture, exception.Message);

                var exceptionData = exception.ToString(); // The ToString() create a string representation of the current exception

                _log.Error(String.Format(CultureInfo.InvariantCulture, "{0} Exception:{1}", messageToTrace, exceptionData));

                //Enviar al server
                Assembly asm = exception.TargetSite.Module.Assembly;
                AssemblyName name = asm.GetName();
            }
        }
    }
}
