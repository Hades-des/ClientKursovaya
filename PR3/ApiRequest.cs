using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Mime;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WinFormsAppKursovaya
{
    internal class ApiRequest
    {
        static string Token = string.Empty;
        static HttpClient Client;
        internal static string URL = "http://localhost:5102/";
        public static HttpResponseMessage response = null;
        public static async Task<string> getJSON(string path)
        {
            RunAsync();
            string responseText = string.Empty;
            try
            {
                response = await Client.GetAsync(path).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return HttpStatusCode.BadRequest.ToString();
            }
            if (response != null && response.IsSuccessStatusCode)
            {
                responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            return responseText;
        }
        public static async Task<string> getJSON(string path, string param)
        {
            RunAsync();
            string responseText = string.Empty;
            if (!string.IsNullOrWhiteSpace(Token))
            {
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            }
            try
            {
                response = await Client.GetAsync(path + param).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;// HttpStatusCode.BadRequest.ToString();
            }
            if (response != null && response.IsSuccessStatusCode)
            {
                responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            return responseText;
        }
        public static async Task<string> sendGetJSON(string path, string json)
        {
            RunAsync();
            string responseText = string.Empty;
            if (!string.IsNullOrWhiteSpace(Token))
            {
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            }
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(URL + path),
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
            };
            try
            {
                response = await Client.SendAsync(request).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return HttpStatusCode.BadRequest.ToString();
            }
            if (response.IsSuccessStatusCode)
            {
                responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            else
            {
                responseText = HttpStatusCode.BadRequest.ToString();
            }
            return responseText;
        }
        public static async Task<string> sendPostJSON(string path, string json)
        {
            RunAsync();
            string responseText = string.Empty;
            if (!string.IsNullOrWhiteSpace(Token))
            {
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            }
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(URL + path),
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
            };
            try
            {
                response = await Client.SendAsync(request).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return HttpStatusCode.BadRequest.ToString();
            }
            if (response.IsSuccessStatusCode)
            {
                responseText = response.StatusCode.ToString();//await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            else
            {
                responseText = HttpStatusCode.BadRequest.ToString(); //await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            return responseText;
        }
        public static void RunAsync()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(URL);
            Client.DefaultRequestHeaders.Accept.Clear();
        }

        internal static object sendPostJSON(string v)
        {
            throw new NotImplementedException();
        }
    }
}
