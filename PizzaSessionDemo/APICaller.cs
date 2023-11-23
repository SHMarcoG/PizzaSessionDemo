using Newtonsoft.Json;
using PizzaSessionDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSessionDemo
{
    public class APICaller
    {
        private static string uri;

        public APICaller(string uriInput)
        {
            uri = uriInput;
        }
        public string GetCall(string urlParameters) {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));
            // Get data response
            var response = client.GetAsync(urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                // read the response body
                var data = response.Content.ReadAsStringAsync().Result;
                return data;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode,
                              response.ReasonPhrase);
                return null;
            }

        }
    }
}
