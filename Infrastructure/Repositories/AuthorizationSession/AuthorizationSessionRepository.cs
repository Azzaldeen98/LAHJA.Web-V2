
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.AutoGenerator.Interfaces;
using Infrastructure.DataSource.ApiClient2.Base;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public class AuthorizationSessionRepository : IAuthorizationSessionRepository {

    private readonly IAuthorizationSessionApiClient _apiClient;
    public AuthorizationSessionRepository(IAuthorizationSessionApiClient apiClient){
        _apiClient=apiClient;
    }
                

    public async Task<ICollection<SessionVm>> GetSessionsAsync(CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetSessionsAsync(cancellationToken);
                

   }


    public async Task<AuthorizationSessionWebResponse> CreateAuthorizationSessionAsync(CreateAuthorizationWebRequest body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.CreateAuthorizationSessionAsync(body, cancellationToken);
                

   }


    public async Task<SessionVm> GetSessionAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetSessionAsync(id, cancellationToken);
                

   }


    public async Task<DeletedResponse> DeleteAuthorizationSessionAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.DeleteAuthorizationSessionAsync(id, cancellationToken);
                

   }


    public async Task<SessionVm> GetSessionByTokenAsync(string token, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetSessionByTokenAsync(token, cancellationToken);
                

   }


    public async Task<SessionVm> GetActiveSessionAsync(string userId, string type, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetActiveSessionAsync(userId, type, cancellationToken);
                

   }


    public async Task<AuthorizationSessionCoreResponse> AuthorizationSessionAsync(ValidateTokenRequest body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.AuthorizationSessionAsync(body, cancellationToken);
                

   }


    public async Task<AuthorizationSessionWebResponse> CreateForDashboardAsync(CreateAuthorizationForDashboard body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.CreateForDashboardAsync(body, cancellationToken);
                

   }


    public async Task<AuthorizationSessionWebResponse> CreateForListServicesAsync(CreateAuthorizationForListServices body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.CreateForListServicesAsync(body, cancellationToken);
                

   }


    public async Task<AuthorizationSessionWebResponse> CreateForAllServicesAsync(CreateAuthorizationForServices body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.CreateForAllServicesAsync(body, cancellationToken);
                

   }


    public async Task<TokenVm> EncryptFromWebAsync(EncryptTokenRequest body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.EncryptFromWebAsync(body, cancellationToken);
                

   }


    public async Task<TokenVm> EncryptFromCoreAsync(string sesstionToken, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.EncryptFromCoreAsync(sesstionToken, cancellationToken);
                

   }


    public async Task<TokenVm> EncryptFromCore2Async(string encrptedToken, string coreToken, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.EncryptFromCore2Async(encrptedToken, coreToken, cancellationToken);
                

   }


    public async Task ValidateWebTokenAsync(string token, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.ValidateWebTokenAsync(token, cancellationToken);
                

   }


    public async Task ValidateCreateTokenAsync(string token, string coreToken, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.ValidateCreateTokenAsync(token, coreToken, cancellationToken);
                

   }


    public async Task ValidateCoreTokenAsync(string token, string coreToken, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.ValidateCoreTokenAsync(token, coreToken, cancellationToken);
                

   }


    public async Task<DeletedResponse> PauseAuthorizationSessionAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.PauseAuthorizationSessionAsync(id, cancellationToken);
                

   }


    public async Task<DeletedResponse> ResumeAuthorizationSessionAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.ResumeAuthorizationSessionAsync(id, cancellationToken);
                

   }


}

