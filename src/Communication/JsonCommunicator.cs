using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Communication
{
    public static class JsonCommunicator
    {
        public static T GetSync<T>(string server, string urlToCall)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(server, UriKind.Absolute);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var task = client.GetStringAsync(urlToCall);
                task.Wait();
                return JsonConvert.DeserializeObject<T>(task.Result);
            }
        }
    }
}
