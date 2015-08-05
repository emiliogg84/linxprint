/*
    See LICENSE in the project root for license information.
*/

namespace LinxPrint.Log
{
    using System;

    public interface ILog
    {
        /// <summary>
        /// Log error message
        /// </summary>
        /// <param name="message">The error message to write</param>
        /// <param name="args">The arguments values</param>
        //void LogError(string message, params object[] args);

        /// <summary>
        /// Log error message
        /// </summary>
        /// <param name="message">The error message to write</param>
        /// <param name="exception">The exception associated with this error</param>
        /// <param name="args">The arguments values</param>
        void LogError(string message, Exception exception, params object[] args);

        void LogError(Exception exception);
        void LogInfo(string message);
    }
}
