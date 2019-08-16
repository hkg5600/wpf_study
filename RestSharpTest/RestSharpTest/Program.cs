using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Net;
namespace RestSharpTest
{
    class Program
    {
        static void Main(string[] args) 
        {
            ObservableCollection<Data> data = new ObservableCollection<Data>();
            
            string title = "Hi";
            string code = "A";
            string url = "http://blogfiles.naver.net/MjAxNzA2MDhfMjc2/MDAxNDk2ODc0NzcxOTYy.zljs87kl-PvSzxuUNqBt1SjvEGQVyi_A51bCko-diiMg.jinXFUyaJaDElIsDqjhBTrFdVp4SN8eafUNFuHbyfkIg.JPEG.kjk405/%B0%A8%BB%E7%C7%D4%C0%B8%B7%CE.jpg";
            string path = "d:/a.png";
            var client = new RestClient("http://127.0.0.1:8000/");
            var request = new RestRequest("rest/api/", Method.POST);
            request.RequestFormat = DataFormat.Json;
            //request.AddJsonBody(new Data()
            //{
            //    title = title,
            //    code = code                
            //});
            request.AddParameter("title", title);
            request.AddParameter("code", code);
            DownloadRemoteImageFile(url, path);
            request.AddFile("image", path);
            //request.AddParameter("multipart/form-data", path, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content.ToString());
            Console.WriteLine("Hello World!");

            request = new RestRequest("rest/api/", Method.GET);
            var queryResult = client.Execute(request).Content;
            var j = JArray.Parse(queryResult);
            foreach (JObject jobj in j)
            {
                data.Add(new Data() { title = jobj["title"].ToString(), code = jobj["code"].ToString() });
            }

            foreach(var v in data)
            {
                Console.WriteLine(v.code + " " + v.title);
            }
            Console.WriteLine();

        }

        private static Image WebImageView(string URL)
        {
            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData(URL);
            MemoryStream ms = new MemoryStream(bytes);
            Image img = System.Drawing.Image.FromStream(ms);
            return img;
        }

        private static byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        private static bool DownloadRemoteImageFile(string uri, string fileName)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            bool bImage = response.ContentType.StartsWith("image",
                StringComparison.OrdinalIgnoreCase);
            if ((response.StatusCode == HttpStatusCode.OK ||
                response.StatusCode == HttpStatusCode.Moved ||
                response.StatusCode == HttpStatusCode.Redirect) &&
                bImage)
            {
                using (Stream inputStream = response.GetResponseStream())
                using (Stream outputStream = File.OpenWrite(fileName))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead;
                    do
                    {
                        bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                        outputStream.Write(buffer, 0, bytesRead);
                    } while (bytesRead != 0);
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Data
    {
        public string title { get; set; }
        public string code { get; set; }
    }

}
