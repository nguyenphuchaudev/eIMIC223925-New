using eIMIC223925.Utilities.Constants;
using eIMIC223925.ViewModels.Common;
using eIMIC223925.ViewModels.System.Users;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eIMIC223925.ApiIntegration
{
    public class UserApiClient : IUserApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public UserApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public async Task<ApiResult<string>> Authenticate(LoginRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);



            var reponse = await client.PostAsync("/api/users/authenticate", httpContent);

            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<string>>(await reponse.Content.ReadAsStringAsync());
            }

            return JsonConvert.DeserializeObject<ApiErrorResult<string>>(await reponse.Content.ReadAsStringAsync());
        }
    }
}
