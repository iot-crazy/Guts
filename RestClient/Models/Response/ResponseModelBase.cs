﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RestClient.Models.Response
{
    public abstract class ResponseModelBase
    {
        public int StatusCode { get; set; }
    }
}
