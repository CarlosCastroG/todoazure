﻿using System;

namespace todoazure.Common.Models
{
    public class Todo
    {
        public string IdEmployee { get; set; }

        public DateTime DateTimeEmployee { get; set; }

        public int Type { get; set; }

        public bool Consolidated { get; set; }
    }
}
