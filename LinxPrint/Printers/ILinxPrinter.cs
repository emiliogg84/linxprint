/*
    See LICENSE in the project root for license information.
*/

namespace LinxPrint.Printers
{
    public interface ILinxPrinter
    {
        bool Connect();
        bool Print(string text);
        void Disconect();
    }
}
