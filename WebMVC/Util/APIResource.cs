using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebMVC.Util
{
    public interface IApiResources : IDisposable
    {
        string BaseURI { get; set; }
        Task<T> GetAsync<T>();
        Task<T> GetAsync<T>(string id);
        Task<T> GetAsync<T>(string id, string partOfUrl, string apiUserToken);
        Task<T> PostAsync<T>(object data);
        Task<T> PostAsync<T>(object data, string partOfUrl);
        Task<T> PostAsync<T>(object data, string partOfUrl, string apiUserToken);
        Task<T> PutAsync<T>(string id, object data);
        Task<T> DeleteAsync<T>(string id);
    }
    public class APIResource : IApiResources
    {
        private readonly IHttpClientWrapper client;
        private readonly JsonSerializerSettings JsonSettings;
        private readonly string _endpoint;
        private readonly string _apiVersion;
        private string _baseURI;

        public string BaseURI
        {
            get { return _baseURI; }
            set { _baseURI = _endpoint + "/" + _apiVersion + value; }
        }

        public APIResource(IHttpClientWrapper customClient, JsonSerializerSettings customJsonSerializerSettings = null)
        {
            client = customClient;
            JsonSettings = customJsonSerializerSettings ?? new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            _endpoint = "http://localhost:51456/api/";


            _baseURI = _endpoint;
        }

        public APIResource() : this(new StandardHttpClient(),
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
        {
        }

        public void Dispose()
        {
            client.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<T> GetAsync<T>()
        {
            var response = await SendRequestAsync(HttpMethod.Get, BaseURI).ConfigureAwait(false);
            return await ProcessResponse<T>(response).ConfigureAwait(false);
        }

        public async Task<T> GetAsync<T>(string id)
        {
            var response = await GetAsync<T>(id, null, null).ConfigureAwait(false);
            return response;
        }

        public async Task<T> GetAsync<T>(string id, string partOfUrl, string apiUserToken)
        {
            var completeUrl = GetCompleteUrl(partOfUrl, id);
            var response = await SendRequestAsync(HttpMethod.Get, completeUrl, null, apiUserToken).ConfigureAwait(false);
            return await ProcessResponse<T>(response).ConfigureAwait(false);
        }

        public async Task<T> PostAsync<T>(object data)
        {
            var response = await PostAsync<T>(data, null, null).ConfigureAwait(false);
            return response;
        }

        public async Task<T> PostAsync<T>(object data, string partOfUrl)
        {
            var response = await PostAsync<T>(data, partOfUrl, null).ConfigureAwait(false);
            return response;
        }

        public async Task<T> PostAsync<T>(object data, string partOfUrl, string customApiToken)
        {
            var completeUrl = GetCompleteUrl(partOfUrl, null);
            var response = await SendRequestAsync(HttpMethod.Post, completeUrl, data, customApiToken).ConfigureAwait(false);
            return await ProcessResponse<T>(response).ConfigureAwait(false);
        }

        public async Task<T> PutAsync<T>(string id, object data)
        {
            return await PutAsync<T>(data, id, null).ConfigureAwait(false);
        }

        public async Task<T> PutAsync<T>(object data, string partOfUrl)
        {
            return await PutAsync<T>(data, partOfUrl, null).ConfigureAwait(false);
        }

        public async Task<T> PutAsync<T>(object data, string partOfUrl, string customApiToken)
        {
            var completeUrl = GetCompleteUrl(partOfUrl, null);
            var response = await SendRequestAsync(HttpMethod.Put, completeUrl, data, customApiToken).ConfigureAwait(false);
            return await ProcessResponse<T>(response).ConfigureAwait(false);
        }

        public async Task<T> DeleteAsync<T>(string id)
        {
            return await DeleteAsync<T>(id, null).ConfigureAwait(false);
        }

        public async Task<T> DeleteAsync<T>(string id, string customApiToken)
        {
            var response = await SendRequestAsync(HttpMethod.Delete, $"{BaseURI}/{id}", null, customApiToken).ConfigureAwait(false);
            return await ProcessResponse<T>(response).ConfigureAwait(false);
        }

        private async Task<T> ProcessResponse<T>(HttpResponseMessage response)
        {
            var data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return await Task.FromResult(JsonConvert.DeserializeObject<T>(data, JsonSettings)).ConfigureAwait(false);
            }

            throw new Exception("");
        }

        private async Task<HttpResponseMessage> SendRequestAsync(HttpMethod method, string url, object data = null, string customToken = null)
        {
            using (var requestMessage = new HttpRequestMessage(method, url))
            {
                await SetContent(data, requestMessage);

                var response = await client.SendAsync(requestMessage).ConfigureAwait(false);
                return response;
            }
        }

        private async Task SetContent(object data, HttpRequestMessage requestMessage)
        {
            if (data != null)
            {
                var content = await Task.FromResult(JsonConvert.SerializeObject(data, JsonSettings)).ConfigureAwait(false);
                requestMessage.Content = new StringContent(content, Encoding.UTF8, "application/json");
            }
        }


        private string GetCompleteUrl(string partOfUrl, string id)
        {
            var url = string.IsNullOrEmpty(partOfUrl) ? $"{BaseURI}/{id}" : $"{BaseURI}/{partOfUrl}/{id}";

            if (url.Last().Equals('/'))
                url = url.Remove(url.Length - 1);

            return url;
        }


    }
}
