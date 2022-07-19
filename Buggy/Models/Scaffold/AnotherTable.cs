using System;
using System.Collections.Generic;

namespace Buggy.Models.Scaffold
{
    public partial class AnotherTable
    {
        public AnotherTable()
        {
            Tables = new HashSet<Table>();
        }

        public int AnotherTableId { get; set; }
        public string Aname { get; set; } = null!;

        public virtual ICollection<Table> Tables { get; set; }
    }
}
