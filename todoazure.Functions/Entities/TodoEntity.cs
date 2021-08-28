using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace todoazure.Functions.Entities
{
    public class TodoEntity : TableEntity
    {
        public string IdEmployee { get; set; }

        public DateTime DateTimeEmployee { get; set; }

        public int Type { get; set; }

        public bool Consolidated { get; set; }
    }
}
