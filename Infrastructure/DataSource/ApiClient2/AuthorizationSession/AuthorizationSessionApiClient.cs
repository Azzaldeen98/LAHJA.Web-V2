
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Infrastructure.Share.Invoker;
using AutoMapper;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Share.Invoker;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.DataSource.ApiClient2;


 public  class AuthorizationSessionApiClient : BuildApiClient<AuthorizationSessionClient>  , IAuthorizationSessionApiClient {

  
    public AuthorizationSessionApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, 
    IApiInvoker apiInvoker) : base(clientFactory, mapper, config, apiInvoker){

    }
                

    public   async Task<ICollection<SessionVm>> GetSessionsAsync(CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.GetSessionsAsync(cancellationToken);

    });
                

   }


    public   async Task<AuthorizationSessionWebResponse> CreateAuthorizationSessionAsync(CreateAuthorizationWebRequest body, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.CreateAuthorizationSessionAsync(body, cancellationToken);

    });
                

   }


    public   async Task<SessionVm> GetSessionAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.GetSessionAsync(id, cancellationToken);

    });
                

   }


    public   async Task<DeletedResponse> DeleteAuthorizationSessionAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.DeleteAuthorizationSessionAsync(id, cancellationToken);

    });
                

   }


    public   async Task<SessionVm> GetSessionByTokenAsync(string token, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.GetSessionByTokenAsync(token, cancellationToken);

    });
                

   }


    public   async Task<SessionVm> GetActiveSessionAsync(string userId, string type, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.GetActiveSessionAsync(userId, type, cancellationToken);

    });
                

   }


    public   async Task<AuthorizationSessionCoreResponse> AuthorizationSessionAsync(ValidateTokenRequest body, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.AuthorizationSessionAsync(body, cancellationToken);

    });
                

   }


    public   async Task<AuthorizationSessionWebResponse> CreateForDashboardAsync(CreateAuthorizationForDashboard body, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.CreateForDashboardAsync(body, cancellationToken);

    });
                

   }


    public   async Task<AuthorizationSessionWebResponse> CreateForListServicesAsync(CreateAuthorizationForListServices body, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.CreateForListServicesAsync(body, cancellationToken);

    });
                

   }


    public   async Task<AuthorizationSessionWebResponse> CreateForAllServicesAsync(CreateAuthorizationForServices body, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.CreateForAllServicesAsync(body, cancellationToken);

    });
                

   }


    public   async Task<TokenVm> EncryptFromWebAsync(EncryptTokenRequest body, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.EncryptFromWebAsync(body, cancellationToken);

    });
                

   }


    public   async Task<TokenVm> EncryptFromCoreAsync(string sesstionToken, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.EncryptFromCoreAsync(sesstionToken, cancellationToken);

    });
                

   }


    public   async Task<TokenVm> EncryptFromCore2Async(string encrptedToken, string coreToken, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.EncryptFromCore2Async(encrptedToken, coreToken, cancellationToken);

    });
                

   }


    public   async Task ValidateWebTokenAsync(string token, CancellationToken cancellationToken)
   {

    
                
     await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
          await client.ValidateWebTokenAsync(token, cancellationToken);

    });
                

   }


    public   async Task ValidateCreateTokenAsync(string token, string coreToken, CancellationToken cancellationToken)
   {

    
                
     await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
          await client.ValidateCreateTokenAsync(token, coreToken, cancellationToken);

    });
                

   }


    public   async Task ValidateCoreTokenAsync(string token, string coreToken, CancellationToken cancellationToken)
   {

    
                
     await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
          await client.ValidateCoreTokenAsync(token, coreToken, cancellationToken);

    });
                

   }


    public   async Task<DeletedResponse> PauseAuthorizationSessionAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.PauseAuthorizationSessionAsync(id, cancellationToken);

    });
                

   }


    public   async Task<DeletedResponse> ResumeAuthorizationSessionAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.ResumeAuthorizationSessionAsync(id, cancellationToken);

    });
                

   }


}

