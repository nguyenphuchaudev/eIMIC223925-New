﻿using eIMIC223925.ViewModels.Common;
using eIMIC223925.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eIMIC223925.ApiIntegration
{
    public interface IUserApiClient
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);
        Task<ApiResult<PagedResult<UserVm>>> GetUsersPagings(GetUserPagingRequest request);
        Task<ApiResult<bool>> RegisterUser(RegisterRequest request);
        Task<ApiResult<UserVm>> GetById(Guid Id);
        Task<ApiResult<bool>> UpdateUser(Guid Id, UserUpdateRequest request);
        Task<ApiResult<bool>> Delete(Guid id);
    }
}
