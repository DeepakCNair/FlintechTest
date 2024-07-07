using FlintechTest.Server.Interface;
using FlintechTest.Server.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace FlintechTest.Server.Services
{
    public class RestRequest<T> : IRestRequest<T>
    {
        private readonly HttpClient httpClient;
        private readonly ILogger<RestRequest<T>> logger;

        public RestRequest(ILogger<RestRequest<T>> logger)
        {
            this.logger = logger;
            httpClient = new HttpClient();
        }

        public async Task<IEnumerable<T>> Get(RequestParam requestParam)
        {
            try
            {
                if (!string.IsNullOrEmpty(requestParam.Url))
                {
                    var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestParam.Url);

                    if (!string.IsNullOrEmpty(requestParam.ContentType))
                    {
                        httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(requestParam.ContentType));
                    }

                    if (requestParam.CustomHeader != null)
                    {
                        foreach (var headerParam in requestParam.CustomHeader)
                        {
                            httpRequestMessage.Headers.Add(headerParam.Key, headerParam.Value);
                        }
                    }

                    var response = httpClient.SendAsync(httpRequestMessage).Result;
                    string responseBody = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<IEnumerable<T>>(responseBody);
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }

            return null;
        }
    }
}
