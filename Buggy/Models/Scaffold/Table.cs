using System;
using System.Collections.Generic;

namespace Buggy.Models.Scaffold
{
    public partial class Table
    {
        public int TableId { get; set; }
        public int AnotherTableId { get; set; }

        public virtual AnotherTable AnotherTable { get; set; } = null!;
    }
}
