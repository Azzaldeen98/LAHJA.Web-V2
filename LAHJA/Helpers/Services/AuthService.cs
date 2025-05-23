﻿using ApexCharts;
using Blazorise.Extensions;
using Domain.Entities.Auth.Request;
using Domain.Entities.Auth.Response;
using LAHJA.Helpers.Enum;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.JSInterop;
using Shared.Enums;
using Shared.Helpers;

namespace LAHJA.Helpers.Services
{

 



    ////TODO: 8-2
    public class AuthService
    {
        private readonly ITokenService tokenService;

        public AuthService(ITokenService tokenService)
        {

            this.tokenService = tokenService;
            //this.PSession = pSession;

        }

    
        public async Task<bool> isAuth()
        {
            try
            {
                var token = await tokenService.GetTokenAsync();
                return !token.IsNullOrEmpty();
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public async Task<bool> isMyself()
        {
            try
            {
                var token = await tokenService.GetTokenAsync();
                return !token.IsNullOrEmpty();
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public void DeleteLogin()
        {
            tokenService.DeleteToken();
            tokenService.DeleteRefreshToken();
        }
        public async Task RemoveCookiesAsync() {

            await tokenService.RemoveCookiesAsync();
        }

        public async Task DeleteLoginAsync()
        {
            try
            {
                await tokenService.RemoveAllTokensAsync();
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }
            finally
            {
                await tokenService.DeleteTokenFromSessionAsync();
            }
        }

        public async Task SaveLoginTypeAsync(LoginType type)
        {
           await tokenService.SaveLoginTypeAsync(type);
        }
        public async Task DeleteLoginTypeAsync()
        {
            await tokenService.DeleteLoginTypeAsync();
        }
        public  void SetToken(string token)
        {
             tokenService.SetToken(token);
        }
        public async Task SaveLoginAsync(LoginResponse response)
        {
            if (response != null)
            {
               
                await tokenService.SaveAllTokensAsync(response.accessToken,
                                                     response.refreshToken,
                                                    response.expiresIn,
                                                    response.tokenType);

                await tokenService.SaveTokenInSessionAsync(response.accessToken);
               
            }
        }

        public async Task SaveAccessTokenInCookiesAsync(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                await tokenService.SaveTokenAsync(token);

            }
        }
        public async Task SaveAccessTokenInSessionAsync(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                await tokenService.SaveTokenInSessionAsync(token);

            }
        }

        public async Task<string> GetAccessTokenAsync()
        {
   
              return  await tokenService.GetTokenAsync();

            
        }

    }
}
