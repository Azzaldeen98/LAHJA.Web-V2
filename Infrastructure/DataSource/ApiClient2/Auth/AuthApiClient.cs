
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Infrastructure.Shared.ApiInvoker;
using AutoMapper;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Shared.ApiInvoker;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.DataSource.ApiClient2;


public class AuthApiClient : BuildApiClient<AuthClient>  , IAuthApiClient {

  
    public AuthApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, 
    IApiInvoker apiInvoker) : base(clientFactory, mapper, config, apiInvoker){

    }
                

    public   async Task LogoutAsync(object body, CancellationToken cancellationToken)
   {

    
                
     await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
          await client.LogoutAsync(body, cancellationToken);

    });
                

   }


    public   async Task RegisterAsync(RegisterRequest body, CancellationToken cancellationToken)
   {

    
                
         await apiInvoker.InvokeAsync(async () =>
        {
              var client = await GetApiClient();
              await client.RegisterAsync(body, cancellationToken);

        });
                

   }


    public   async Task<AccessTokenResponse> LoginAsync(bool? useCookies, bool? useSessionCookies, LoginRequest body, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.LoginAsync(useCookies, useSessionCookies, body, cancellationToken);

    });
                

   }


    public   async Task<AccessTokenResponse> RefreshAsync(RefreshRequest body, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.RefreshAsync(body, cancellationToken);

    });
                

   }


    public   async Task ConfirmEmailAsync(ConfirmEmailRequest body, CancellationToken cancellationToken)
   {

    
                
     await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
          await client.ConfirmEmailAsync(body, cancellationToken);

    });
                

   }


    public   async Task<string> ResendConfirmationEmailAsync(ResendConfirmationEmailRequest body, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.ResendConfirmationEmailAsync(body, cancellationToken);

    });
                

   }


    public   async Task ForgotPasswordAsync(ForgotPasswordRequest body, CancellationToken cancellationToken)
   {

    
                
     await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
          await client.ForgotPasswordAsync(body, cancellationToken);

    });
                

   }


    public   async Task ResetPasswordAsync(ResetPasswordRequest body, CancellationToken cancellationToken)
   {

    
                
     await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
          await client.ResetPasswordAsync(body, cancellationToken);

    });
                

   }


    public   async Task ExternalLoginAsync(string provider, string returnUrl, CancellationToken cancellationToken)
   {

    
                
     await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
          await client.ExternalLoginAsync(provider, returnUrl, cancellationToken);

    });
                

   }


    public   async Task ExternalLoginCallbackAsync(string returnUrl, CancellationToken cancellationToken)
   {

    
                
     await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
          await client.ExternalLoginCallbackAsync(returnUrl, cancellationToken);

    });
                

   }


}

