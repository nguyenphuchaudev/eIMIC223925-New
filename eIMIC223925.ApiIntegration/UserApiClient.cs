﻿using eIMIC223925.Utilities.Constants;
using eIMIC223925.ViewModels.Common;
using eIMIC223925.ViewModels.System.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace eIMIC223925.ApiIntegration
{
    public class UserApiClient : IUserApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ApiResult<string>> Authenticate(LoginRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);



            var reponse = await client.PostAsync($"/api/users/authenticate", httpContent);

            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<string>>(await reponse.Content.ReadAsStringAsync());
            }

            return JsonConvert.DeserializeObject<ApiErrorResult<string>>(await reponse.Content.ReadAsStringAsync());
        }

        public async Task<ApiResult<PagedResult<UserVm>>> GetUsersPagings(GetUserPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var session = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session);
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            var reponse = await client.GetAsync($"api/users/paging?pageIndex={request.PageIndex}&pageSize={request.PageSize}&keyword={request.Keyword}");

            var body = await reponse.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<ApiSuccessResult<PagedResult<UserVm>>>(body);
            return users;

        }

        public async Task<ApiResult<bool>> RegisterUser(RegisterRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"/api/users", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(result);
        }

    }
}