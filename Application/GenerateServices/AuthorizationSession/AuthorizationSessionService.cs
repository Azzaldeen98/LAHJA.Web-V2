
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public class AuthorizationSessionService : IAuthorizationSessionService {


            
 private readonly AuthorizationSessionUseCase _authorizationSessionUseCase;
 private readonly CreateAuthorizationSessionUseCase _createAuthorizationSessionUseCase;
 private readonly CreateForAllServicesAuthorizationSessionUseCase _createForAllServicesAuthorizationSessionUseCase;
 private readonly CreateForDashboardAuthorizationSessionUseCase _createForDashboardAuthorizationSessionUseCase;
 private readonly CreateForListServicesAuthorizationSessionUseCase _createForListServicesAuthorizationSessionUseCase;
 private readonly DeleteAuthorizationSessionUseCase _deleteAuthorizationSessionUseCase;
 private readonly EncryptFromCore2AuthorizationSessionUseCase _encryptFromCore2AuthorizationSessionUseCase;
 private readonly EncryptFromCoreAuthorizationSessionUseCase _encryptFromCoreAuthorizationSessionUseCase;
 private readonly EncryptFromWebAuthorizationSessionUseCase _encryptFromWebAuthorizationSessionUseCase;
 private readonly GetActiveSessionAuthorizationSessionUseCase _getActiveSessionAuthorizationSessionUseCase;
 private readonly GetSessionAuthorizationSessionUseCase _getSessionAuthorizationSessionUseCase;
 private readonly GetSessionByTokenAuthorizationSessionUseCase _getSessionByTokenAuthorizationSessionUseCase;
 private readonly GetSessionsAuthorizationSessionUseCase _getSessionsAuthorizationSessionUseCase;
 private readonly PauseAuthorizationSessionUseCase _pauseAuthorizationSessionUseCase;
 private readonly ResumeAuthorizationSessionUseCase _resumeAuthorizationSessionUseCase;
 private readonly ValidateCoreTokenAuthorizationSessionUseCase _validateCoreTokenAuthorizationSessionUseCase;
 private readonly ValidateCreateTokenAuthorizationSessionUseCase _validateCreateTokenAuthorizationSessionUseCase;
 private readonly ValidateWebTokenAuthorizationSessionUseCase _validateWebTokenAuthorizationSessionUseCase;


            public AuthorizationSessionService(
AuthorizationSessionUseCase authorizationSessionUseCase,
CreateAuthorizationSessionUseCase createAuthorizationSessionUseCase,
CreateForAllServicesAuthorizationSessionUseCase createForAllServicesAuthorizationSessionUseCase,
CreateForDashboardAuthorizationSessionUseCase createForDashboardAuthorizationSessionUseCase,
CreateForListServicesAuthorizationSessionUseCase createForListServicesAuthorizationSessionUseCase,
DeleteAuthorizationSessionUseCase deleteAuthorizationSessionUseCase,
EncryptFromCore2AuthorizationSessionUseCase encryptFromCore2AuthorizationSessionUseCase,
EncryptFromCoreAuthorizationSessionUseCase encryptFromCoreAuthorizationSessionUseCase,
EncryptFromWebAuthorizationSessionUseCase encryptFromWebAuthorizationSessionUseCase,
GetActiveSessionAuthorizationSessionUseCase getActiveSessionAuthorizationSessionUseCase,
GetSessionAuthorizationSessionUseCase getSessionAuthorizationSessionUseCase,
GetSessionByTokenAuthorizationSessionUseCase getSessionByTokenAuthorizationSessionUseCase,
GetSessionsAuthorizationSessionUseCase getSessionsAuthorizationSessionUseCase,
PauseAuthorizationSessionUseCase pauseAuthorizationSessionUseCase,
ResumeAuthorizationSessionUseCase resumeAuthorizationSessionUseCase,
ValidateCoreTokenAuthorizationSessionUseCase validateCoreTokenAuthorizationSessionUseCase,
ValidateCreateTokenAuthorizationSessionUseCase validateCreateTokenAuthorizationSessionUseCase,
ValidateWebTokenAuthorizationSessionUseCase validateWebTokenAuthorizationSessionUseCase){
                
      _authorizationSessionUseCase=authorizationSessionUseCase;
      _createAuthorizationSessionUseCase=createAuthorizationSessionUseCase;
      _createForAllServicesAuthorizationSessionUseCase=createForAllServicesAuthorizationSessionUseCase;
      _createForDashboardAuthorizationSessionUseCase=createForDashboardAuthorizationSessionUseCase;
      _createForListServicesAuthorizationSessionUseCase=createForListServicesAuthorizationSessionUseCase;
      _deleteAuthorizationSessionUseCase=deleteAuthorizationSessionUseCase;
      _encryptFromCore2AuthorizationSessionUseCase=encryptFromCore2AuthorizationSessionUseCase;
      _encryptFromCoreAuthorizationSessionUseCase=encryptFromCoreAuthorizationSessionUseCase;
      _encryptFromWebAuthorizationSessionUseCase=encryptFromWebAuthorizationSessionUseCase;
      _getActiveSessionAuthorizationSessionUseCase=getActiveSessionAuthorizationSessionUseCase;
      _getSessionAuthorizationSessionUseCase=getSessionAuthorizationSessionUseCase;
      _getSessionByTokenAuthorizationSessionUseCase=getSessionByTokenAuthorizationSessionUseCase;
      _getSessionsAuthorizationSessionUseCase=getSessionsAuthorizationSessionUseCase;
      _pauseAuthorizationSessionUseCase=pauseAuthorizationSessionUseCase;
      _resumeAuthorizationSessionUseCase=resumeAuthorizationSessionUseCase;
      _validateCoreTokenAuthorizationSessionUseCase=validateCoreTokenAuthorizationSessionUseCase;
      _validateCreateTokenAuthorizationSessionUseCase=validateCreateTokenAuthorizationSessionUseCase;
      _validateWebTokenAuthorizationSessionUseCase=validateWebTokenAuthorizationSessionUseCase;


            }

                

    public async Task<AuthorizationSessionCoreResponse> authorizationSessionAsync(ValidateTokenRequest body, CancellationToken cancellationToken)
   {

    

         return    await _authorizationSessionUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<AuthorizationSessionWebResponse> createAuthorizationSessionAsync(CreateAuthorizationWebRequest body, CancellationToken cancellationToken)
   {

    

         return    await _createAuthorizationSessionUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<AuthorizationSessionWebResponse> createForAllServicesAuthorizationSessionAsync(CreateAuthorizationForServices body, CancellationToken cancellationToken)
   {

    

         return    await _createForAllServicesAuthorizationSessionUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<AuthorizationSessionWebResponse> createForDashboardAuthorizationSessionAsync(CreateAuthorizationForDashboard body, CancellationToken cancellationToken)
   {

    

         return    await _createForDashboardAuthorizationSessionUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<AuthorizationSessionWebResponse> createForListServicesAuthorizationSessionAsync(CreateAuthorizationForListServices body, CancellationToken cancellationToken)
   {

    

         return    await _createForListServicesAuthorizationSessionUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<DeletedResponse> deleteAuthorizationSessionAsync(string id, CancellationToken cancellationToken)
   {

    

         return    await _deleteAuthorizationSessionUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task<TokenVm> encryptFromCore2AuthorizationSessionAsync(string encrptedToken, string coreToken, CancellationToken cancellationToken)
   {

    

         return    await _encryptFromCore2AuthorizationSessionUseCase.ExecuteAsync(encrptedToken, coreToken, cancellationToken);
        

   }



    public async Task<TokenVm> encryptFromCoreAuthorizationSessionAsync(string sesstionToken, CancellationToken cancellationToken)
   {

    

         return    await _encryptFromCoreAuthorizationSessionUseCase.ExecuteAsync(sesstionToken, cancellationToken);
        

   }



    public async Task<TokenVm> encryptFromWebAuthorizationSessionAsync(EncryptTokenRequest body, CancellationToken cancellationToken)
   {

    

         return    await _encryptFromWebAuthorizationSessionUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<SessionVm> getActiveSessionAuthorizationSessionAsync(string userId, string type, CancellationToken cancellationToken)
   {

    

         return    await _getActiveSessionAuthorizationSessionUseCase.ExecuteAsync(userId, type, cancellationToken);
        

   }



    public async Task<SessionVm> getSessionAuthorizationSessionAsync(string id, CancellationToken cancellationToken)
   {

    

         return    await _getSessionAuthorizationSessionUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task<SessionVm> getSessionByTokenAuthorizationSessionAsync(string token, CancellationToken cancellationToken)
   {

    

         return    await _getSessionByTokenAuthorizationSessionUseCase.ExecuteAsync(token, cancellationToken);
        

   }



    public async Task<ICollection<SessionVm>> getSessionsAuthorizationSessionAsync(CancellationToken cancellationToken)
   {

    

         return    await _getSessionsAuthorizationSessionUseCase.ExecuteAsync(cancellationToken);
        

   }



    public async Task<DeletedResponse> pauseAuthorizationSessionAsync(string id, CancellationToken cancellationToken)
   {

    

         return    await _pauseAuthorizationSessionUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task<DeletedResponse> resumeAuthorizationSessionAsync(string id, CancellationToken cancellationToken)
   {

    

         return    await _resumeAuthorizationSessionUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task validateCoreTokenAuthorizationSessionAsync(string token, string coreToken, CancellationToken cancellationToken)
   {

    

          await _validateCoreTokenAuthorizationSessionUseCase.ExecuteAsync(token, coreToken, cancellationToken);
        

   }



    public async Task validateCreateTokenAuthorizationSessionAsync(string token, string coreToken, CancellationToken cancellationToken)
   {

    

          await _validateCreateTokenAuthorizationSessionUseCase.ExecuteAsync(token, coreToken, cancellationToken);
        

   }



    public async Task validateWebTokenAuthorizationSessionAsync(string token, CancellationToken cancellationToken)
   {

    

          await _validateWebTokenAuthorizationSessionUseCase.ExecuteAsync(token, cancellationToken);
        

   }





}
