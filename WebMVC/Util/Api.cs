using Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebMVC.Util
{
    public class Api
    {
        public async Task<List<Cliente>> GetClientes()
        {
            WebResponse response;
            string endPoint = $"http://localhost:51456/api/Cadastro";
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
        private async Task<T> ProcessResponse<T>(WebResponse response)
        {
            if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                var data = readStream.ReadToEnd();
                receiveStream.Dispose();
                readStream.Dispose();
                //ExportJsonToExcel(data);
                var JsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
                return await Task.FromResult(JsonConvert.DeserializeObject<T>(data, JsonSettings)).ConfigureAwait(false);
            }
            throw new Exception("Não foi possível fazer a consulta. Tente novamente.");
        }
    }
}