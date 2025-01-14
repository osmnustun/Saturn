using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.Logic.RemoteApi
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        // POST isteği gönderme
        public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest requestData)
        {
            var jsonContent = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(responseContent);
            }

            throw new Exception($"API request failed with status code {response.StatusCode}");
        }

        // GET isteği gönderme
        public async Task<TResponse> GetAsync<TResponse>(string url, string queryParams)
        {
            string fullUrl = "";
            if (queryParams != null)
                fullUrl = $"{url}?{queryParams}";
            else
                fullUrl = url;
            var response = await _httpClient.GetAsync(fullUrl);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(responseContent);
            }

            throw new Exception($"API request failed with status code {response.StatusCode}");
        }
    }
}
