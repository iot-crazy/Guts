using System;
using System.Collections.Generic;
using System.Text;

namespace RestClient.Models.Response
{
    public class Quote
    {
        public string _id { get; set; }
        public string QuoteText { get; set; }
        public string QuoteAuthor { get; set; }
        public string QuoteGenre { get; set; }
    }
}
