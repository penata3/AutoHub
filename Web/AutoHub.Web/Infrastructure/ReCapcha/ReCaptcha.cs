namespace AutoHub.Web.Infrastructure
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json.Linq;

    public class ReCaptcha
    {
        private readonly HttpClient httpClient;
        private readonly string secretKey;

        public ReCaptcha(
            HttpClient httpClient,
            IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.secretKey = configuration["ReCaptcha:SecretKey"];
        }

        public async Task<bool> IsValid(string captcha)
        {
            try
            {
                var postTask = await this.httpClient
                    .PostAsync($"?secret={this.secretKey}&response={captcha}", new StringContent(string.Empty));
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
