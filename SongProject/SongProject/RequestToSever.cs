using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SongProject
{
    public class RequestToSever
    {
        public string PostToServer(string title, string code, string url)
        {
            var client = new RestClient("http://127.0.0.1:8000/");
            var request = new RestRequest("song/api/", Method.POST);
            try
            {
                request.RequestFormat = DataFormat.Json;
                request.AddParameter("title", title);
                request.AddParameter("code", code);
                request.AddParameter("url", url);
                IRestResponse response = client.Execute(request);
                return response.StatusCode.ToString();
            }
            catch
            {
                return "fail";
            }
        }

        public JArray GetFromServer()
        {
            try
            {
                var client = new RestClient("http://127.0.0.1:8000/");
                var request = new RestRequest("song/api/", Method.GET);
                var queryResult = client.Execute(request).Content;
                JArray j = JArray.Parse(queryResult);
                return j;
            }
            catch
            {
                return null;
            }
        }

        public string DeleteMothod(string id)
        {
            var client = new RestClient("http://127.0.0.1:8000/");
            var request = new RestRequest("song/api/" + id + "/", Method.DELETE);
            IRestResponse response = client.Execute(request);
            return response.StatusCode.ToString();
        }


    }
}
