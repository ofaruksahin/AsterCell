using AsterCell.Application.Common.Contracts;
using AsterCell.Application.Common.Exceptions;
using AsterCell.Application.Common.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace AsterCell.Application.Common.Services
{
    public class UserInfo : IUserInfo
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpClient _httpClient;

        private UserInfoResponse _userInfoResponse;
        private User _user;

        public UserInfo(
            IHttpContextAccessor httpContextAccessor,
            HttpClient httpClient)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClient = httpClient;
        }

        public int Id
        {
            get
            {
                if (_user is null)
                    throw new UserIsNotAuthenticatedException();
                return _user.Id;
            }
        }

        public string TenantId
        {
            get
            {
                if (_user is null)
                    throw new UserIsNotAuthenticatedException();
                return _user.TenantId;
            }
        }

        public string PhoneNumber
        {
            get
            {
                if (_user is null)
                    throw new UserIsNotAuthenticatedException();
                return _user.PhoneNumber;
            }
        }

        public string Email
        {
            get
            {
                if (_user is null)
                    throw new UserIsNotAuthenticatedException();
                return _user.Email;
            }
        }

        public List<string> Roles
        {
            get
            {
                if (_user is null)
                    throw new UserIsNotAuthenticatedException();
                return _user.Roles;
            }
        }

        public async Task<bool> IsAuthenticated()
        {
            if (_user != null)
                return true;

            var token = GetToken();

            if (string.IsNullOrEmpty(token))
                return false;

            var disco = await _httpClient.GetDiscoveryDocumentAsync();

            if (disco.IsError)
                return false;

            _userInfoResponse = await _httpClient.GetUserInfoAsync(new UserInfoRequest { Token = token,Address = disco.UserInfoEndpoint });

            if (!_userInfoResponse.IsError)
                _user = new User(_userInfoResponse);

            return !_userInfoResponse.IsError;
        }

        private string GetToken()
        {
            var hasToken = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (!hasToken)
                return string.Empty;
            return token.ToString().Split(' ').LastOrDefault();
        }
    }
}
