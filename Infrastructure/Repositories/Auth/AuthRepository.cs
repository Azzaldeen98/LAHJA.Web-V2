
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.AutoGenerator.Interfaces;
using Infrastructure.DataSource.ApiClient2.Base;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public class AuthRepository : IAuthRepository {

    private readonly IAuthApiClient _apiClient;
    public AuthRepository(IAuthApiClient apiClient){
        _apiClient=apiClient;
    }
                

    public async Task LogoutAsync(object body, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.LogoutAsync(body, cancellationToken);
                

   }


    public async Task RegisterAsync(RegisterRequest body, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.RegisterAsync(body, cancellationToken);
                

   }


    public async Task<AccessTokenResponse> LoginAsync(bool? useCookies, bool? useSessionCookies, LoginRequest body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.LoginAsync(useCookies, useSessionCookies, body, cancellationToken);
                

   }


    public async Task<AccessTokenResponse> RefreshAsync(RefreshRequest body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.RefreshAsync(body, cancellationToken);
                

   }


    public async Task CustomMapIdentityApiApi_confirmEmailAsync(ConfirmEmailRequest body, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.CustomMapIdentityApiApi_confirmEmailAsync(body, cancellationToken);
                

   }


    public async Task<string> ResendConfirmationEmailAsync(ResendConfirmationEmailRequest body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.ResendConfirmationEmailAsync(body, cancellationToken);
                

   }


    public async Task ForgotPasswordAsync(ForgotPasswordRequest body, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.ForgotPasswordAsync(body, cancellationToken);
                

   }


    public async Task ResetPasswordAsync(ResetPasswordRequest body, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.ResetPasswordAsync(body, cancellationToken);
                

   }


    public async Task ExternalLoginAsync(string provider, string returnUrl, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.ExternalLoginAsync(provider, returnUrl, cancellationToken);
                

   }


    public async Task ExternalLoginCallbackAsync(string returnUrl, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.ExternalLoginCallbackAsync(returnUrl, cancellationToken);
                

   }


}

