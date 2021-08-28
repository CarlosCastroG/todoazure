﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace todoazure.Common.Responses
{
    public class Response
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }
    }
}
