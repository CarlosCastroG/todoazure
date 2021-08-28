using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace todoazure.Functions.Entities
{
    public class ConsolidatedEntity : TableEntity
    {
        public string IdEmployee { get; set; }

        public DateTime DateTimeNow { get; set; }

        public int WorkedMinutes { get; set; }
    }
}
