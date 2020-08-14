using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace YandexTest.Core.RestBase.Repository
{
    public abstract class RestRepositoryBase
    {
        protected readonly JsonSerializerSettings JsonSerializerSettings;

        protected readonly string ContentType;

        protected readonly string GetMethod;
        protected readonly string PostMethod;
        protected readonly string PutMethod;

        protected RestRepositoryBase(JsonSerializerSettings jsonSerializerSettings = null)
        {
            ContentType = "application/json";

            GetMethod = "GET";
            PostMethod = "POST";
            PutMethod = "PUT";

            JsonSerializerSettings = jsonSerializerSettings ?? new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };
        }
        public async Task<T> Get<T>(string baseUrl, string method, Dictionary<string, string> headers)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(baseUrl + method);
            httpWebRequest.ContentType = ContentType;
            httpWebRequest.Method = GetMethod;

            foreach (var h in headers)
                httpWebRequest.Headers.Add(h.Key, h.Value);

            try
            {
                T answer;
                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream() ?? throw new InvalidOperationException()))
                {
                    var response = streamReader.ReadToEnd();
                    answer = JsonConvert.DeserializeObject<T>(response);
                }

                return answer;
            }
            catch (WebException ex)
            {
                using (var streamReader =
                    new StreamReader(ex.Response.GetResponseStream() ?? throw new InvalidOperationException()))
                {
                    var error = streamReader.ReadToEnd();
                    throw new Exception(error);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> Post<T, TK>(TK body, string baseUrl, string method, Dictionary<string, string> headers)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(baseUrl + method);
            httpWebRequest.ContentType = ContentType;
            httpWebRequest.Method = PostMethod;

            foreach (var h in headers)
                httpWebRequest.Headers.Add(h.Key, h.Value);

            var streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync());

            var json = JsonConvert.SerializeObject(body, JsonSerializerSettings);

            streamWriter.Write(json);
            streamWriter.Flush();

            try
            {
                T answer;
                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream() ?? throw new InvalidOperationException()))
                {
                    var response = streamReader.ReadToEnd();
                    answer = JsonConvert.DeserializeObject<T>(response);
                }

                return answer;
            }
            catch (WebException ex)
            {
                using (var streamReader =
                    new StreamReader(ex.Response.GetResponseStream() ?? throw new InvalidOperationException()))
                {
                    var error = streamReader.ReadToEnd();
                    throw new Exception(error);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> Put<T, TK>(TK body, string baseUrl, string method, Dictionary<string, string> headers)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(baseUrl + method);
            httpWebRequest.ContentType = ContentType;
            httpWebRequest.Method = PutMethod;

            foreach (var h in headers)
                httpWebRequest.Headers.Add(h.Key, h.Value);

            var streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync());

            var json = JsonConvert.SerializeObject(body, JsonSerializerSettings);

            streamWriter.Write(json);
            streamWriter.Flush();

            try
            {
                T answer;
                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream() ?? throw new InvalidOperationException()))
                {
                    var response = streamReader.ReadToEnd();
                    answer = JsonConvert.DeserializeObject<T>(response);
                }

                return answer;
            }
            catch (WebException ex)
            {
                using (var streamReader =
                    new StreamReader(ex.Response.GetResponseStream() ?? throw new InvalidOperationException()))
                {
                    var error = streamReader.ReadToEnd();
                    throw new Exception(error);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
