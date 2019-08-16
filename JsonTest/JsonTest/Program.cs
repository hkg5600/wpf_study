using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = "Hi";
            string code = "F";
            var client = new RestClient("http://127.0.0.1:8000/");
            var request = new RestRequest("rest/api/", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new Data()
            {
                title = title,
                code = code
            });
            client.Execute(request);
            Console.WriteLine("Hello World!");

            request = new RestRequest("rest/api/", Method.GET);
            var queryResult = client.Execute(request).Content;
            Console.WriteLine(queryResult);
            //var t = queryResult["title"].ToString();
            //Console.WriteLine(t);
            
        }

        class Data
        {
            public string title { get; set; }
            public string code { get; set; }

        }
    }
}
