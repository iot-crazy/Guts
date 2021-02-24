using System;
using System.Collections.Generic;
using System.Text;

namespace RestClient.Models.Request
{
    public class RandomQuoteRequestModel : RequestModelBase
    {
        const string uriPath = "/quotes/random";

        public RandomQuoteRequestModel() : base(uriPath)
        { }

        public override Uri ToUri(Uri baseURL)
        {
            // This request type has no further properties so we don't pass a parameters dictionary
            return BuildUri(baseURL, null);
        }

    }
}
