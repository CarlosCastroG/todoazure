using System;

namespace todoazure.Functions.Entities
{
    public class ConsolidatedEntity
    {
        public string IdEmployee { get; set; }

        public DateTime DateTimeNow { get; set; }

        public int WorkedMinutes { get; set; }
    }
}
