using Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebMVC.Util
{
    public class Api
    {
        private readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        private readonly string ApiUrl = System.Configuration.ConfigurationManager.AppSettings["api"];


        public async Task<Cliente> GetCliente(int id)
        {
            WebResponse response;
            string endPoint = ApiUrl + id;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                response = await request.GetResponseAsync();
            }
            catch (Exception)
            {
                throw;
            }

            if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
            {
                var end = await ProcessResponse<Cliente>(response);
                return end;
            }
            else
            {
                throw new Exception("Não foi possivel buscar o cep.");
            }
        }

        public async Task<List<Cliente>> GetClientes()
        {
            WebResponse response;
            string endPoint = ApiUrl;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                response = await request.GetResponseAsync();
            }
            catch (Exception)
            {
                throw;
            }

            if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
            {
                var end = await ProcessResponse<List<Cliente>>(response);
                return end;
            }
            else
            {
                throw new Exception("Não foi possivel buscar o cep.");
            }
        }
        public async Task<Cliente> PostCliente(Cliente data, HttpMethod method)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders
                 .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (var requestMessage = new HttpRequestMessage(method, ApiUrl))
            {
                await SetContent(data, requestMessage);

                var response = await client.SendAsync(requestMessage).ConfigureAwait(false);
                var obj = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(JsonConvert.DeserializeObject<Cliente>(obj, JsonSettings)).ConfigureAwait(false);
                }
                else { return null; }
            }
        }

        public async Task<Cliente> PutCliente(int id, Cliente data, HttpMethod method)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders
                 .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (var requestMessage = new HttpRequestMessage(method, $"{ApiUrl}{id}"))
            {
                await SetContent(data, requestMessage);

                var response = await client.SendAsync(requestMessage).ConfigureAwait(false);
                var obj = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(JsonConvert.DeserializeObject<Cliente>(obj, JsonSettings)).ConfigureAwait(false);
                }
                else { return null; }
            }
        }

        public async Task<Cliente> DeleteCliente(int id, HttpMethod method)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders
                 .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (var requestMessage = new HttpRequestMessage(method, $"{ApiUrl}{id}"))
            {
                var response = await client.SendAsync(requestMessage).ConfigureAwait(false);
                var obj = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(JsonConvert.DeserializeObject<Cliente>(obj, JsonSettings)).ConfigureAwait(false);
                }
                else { return null; }
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

        private async Task<T> ProcessResponse<T>(WebResponse response)
        {
            if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                var data = readStream.ReadToEnd();
                receiveStream.Dispose();
                readStream.Dispose();
                return await Task.FromResult(JsonConvert.DeserializeObject<T>(data, JsonSettings)).ConfigureAwait(false);
            }
            throw new Exception("Não foi possível fazer a consulta. Tente novamente.");
        }
    }
}