using RestClient.Models.Request;
using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestClient
{
    public class RestClient
    {
        private readonly Uri _baseUri;

        public RestClient(Uri baseUri)
        {
            _baseUri = baseUri;
        }

        public async Task<T> Request<T>(RequestModelBase requestModel)
        {
            // combine base URL with the URL for the specific request
            WebRequest request = WebRequest.Create(requestModel.ToUri(_baseUri));

            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Display the status.
            Console.WriteLine(response.StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            // StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            ////  string responseFromServer = reader.ReadToEnd();
            // Display the content.
            //  Console.WriteLine(responseFromServer);
            // Cleanup the streams and the response.
            //  reader.Close();

            T result = await JsonSerializer.DeserializeAsync<T>(dataStream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            dataStream.Close();
            response.Close();
            return result;
        }




    }
}
