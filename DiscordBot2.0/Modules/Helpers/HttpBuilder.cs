using DiscordBot2._0.Modules.ResponseClasses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace DiscordBot2._0.Modules
{
    public class HttpBuilder
    {

        public static HttpWebRequest BuildRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.KeepAlive = false;
            request.Headers.Add("Upgrade-Insecure-Requests", @"1");
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, sdch, br");
            request.Headers.Set(HttpRequestHeader.AcceptLanguage, "nl-NL,en-NL;q=0.8,nl;q=0.6,en-US;q=0.4,en;q=0.2");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            return request;
        }

        public static HttpWebResponse MakeRequest(HttpWebRequest request)
        {
            try
            {
                return (HttpWebResponse)request.GetResponse();
            }
            catch(WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                   return (HttpWebResponse)e.Response;

                return null;
            }
        }

        public static Data2 ReadRedditResponse(HttpWebResponse response)
        {
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var html = reader.ReadToEnd();
                try
                {
                    var obj = JsonConvert.DeserializeObject<List<RootObject>>(html);
                    return obj[0].data.children[0].data;
                }
                finally
                {
                    reader.Close();
                    stream.Close();
                }
            }
        }

        public static string ReadYoMamaJokeResponse(HttpWebResponse response)
        {
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var html = reader.ReadToEnd();
                JObject json = JObject.Parse(html);
                var joke = json["joke"].ToString();
                joke = Regex.Replace(json["joke"].ToString(), "{}", "");

                reader.Close();
                stream.Close();
                return joke;
            }
        }

        public static HttpWebRequest BuildJpegRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://morejpeg.com/");
            request.ContentType = "multipart/form-data; boundary=----WebKitFormBoundarycYs1w9QuPLLvowUZ";

            request.Method = "POST";

            string body = @"------WebKitFormBoundarycYs1w9QuPLLvowUZ
Content-Disposition: form-data; name=""__requestverificationtoken""

hCZpQ8SsN9vAZ6x3JGELLadF0oYX2-t9Aw4w5FnSC-NkNI4QvE2-ZwlMcewu_rA7o4T5S1bEfpqorquhomqAjJR_NedtqsMSbqbMQJymoac1
------WebKitFormBoundarycYs1w9QuPLLvowUZ
Content-Disposition: form-data; name=""file""; filename=""""
Content-Type: application/octet-stream


------WebKitFormBoundarycYs1w9QuPLLvowUZ
Content-Disposition: form-data; name=""url""

" + url + @"
------WebKitFormBoundarycYs1w9QuPLLvowUZ--
";
            WriteMultipartBodyToRequest(request, body);

            return request;
        }

        public static void WriteMultipartBodyToRequest(HttpWebRequest request, string body)
        {
            string[] multiparts = Regex.Split(body, @"<!>");
            byte[] bytes;
            using (MemoryStream ms = new MemoryStream())
            {
                foreach (string part in multiparts)
                {
                    if (File.Exists(part))
                    {
                        bytes = File.ReadAllBytes(part);
                    }
                    else
                    {
                        bytes = System.Text.Encoding.UTF8.GetBytes(part.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n"));
                    }

                    ms.Write(bytes, 0, bytes.Length);
                }

                request.ContentLength = ms.Length;
                using (Stream stream = request.GetRequestStream())
                {
                    ms.WriteTo(stream);
                }
            }
        }
    }
}
