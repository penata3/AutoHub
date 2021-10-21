using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AutoHub.Web.Infrastructure
{
    public class ReCaptcha
    {
        private readonly HttpClient httpClient;

        public ReCaptcha(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> IsValid(string captcha)
        {
            try
            {
                var postTask = await this.httpClient
                    .PostAsync($"?secret=.&response={captcha}", new StringContent(""));
                var result = await postTask.Content.ReadAsStringAsync();
                var resultObject = JObject.Parse(result);
                dynamic success = resultObject["success"];
                return (bool)success;
            }
            catch (Exception e)
            {
                // TODO: log this (in elmah.io maybe?)
                return false;
            }
        }
    }
}
