using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MealsPlanned_App.Services
{
    public class HttpClientServiceBase<T>
    {
        readonly string _baseUrl = "http://192.168.1.2/mp/";

        public T Get(string path)
        {
            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(10);
            client.BaseAddress = new Uri(_baseUrl);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(path).Result;

            if (response.IsSuccessStatusCode)
            {
                string serializedResult = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<T>(serializedResult);

                return result;
            }
            else
                throw new Exception(response.Content.ReadAsStringAsync().Result);
        }

        public string Post(string path, T content)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync<T>(path, content).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                return result;
            }
            else
                throw new Exception(response.Content.ReadAsStringAsync().Result);
        }
    }
}
