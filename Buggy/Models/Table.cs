using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Buggy.Models.Scaffold
{
    [ModelMetadataType(typeof(TableMetadata))]
    public partial class Table
    {
    }

    public class TableMetadata
    {
        public int TableId { get; set; }

        [DisplayName("HelloWorld")]
        public int AnotherTableId { get; set; }

        public virtual AnotherTable? AnotherTable { get; set; }

    }

}
