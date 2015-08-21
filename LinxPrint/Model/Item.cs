/*
    See LICENSE in the project root for license information.
*/

namespace LinxPrint.Model
{
    using System;

    public class Item
    {
        public int Id { get; set; }
        public int RecNo { get; set; }
        public string Code { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public bool Printed { get; set; }
        public DateTime PrintedOn { get; set; }
        public string PrintedDetails { get; set; }
    }
}
