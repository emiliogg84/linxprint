/*
    See LICENSE in the project root for license information.
*/

namespace LinxPrint.Log
{
    using System;

    public static class LogFactory
    {
        private static ILog _logger = new Log4NetLog();

        public static ILog CreateLog()
        {
            return _logger;
        }
    }
}
