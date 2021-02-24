using System;
using System.Collections.Generic;
using System.Text;

namespace RestClient.Models.Response
{
    public class RandomQuoteResponse : ResponseModelBase
    {
        public Quote Quote { get; set; }
    }
}
