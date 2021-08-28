using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace todoazure.Common.Models
{
    public class Todo
    {
        public string IdEmployee { get; set; }

        public DateTime DateTimeEmployee { get; set; }

        public int Type { get; set; }

        public Boolean Consolidated { get; set; }
    }
}
