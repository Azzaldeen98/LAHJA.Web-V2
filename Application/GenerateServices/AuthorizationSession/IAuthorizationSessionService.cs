
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public interface IAuthorizationSessionService :  ITBaseShareService  
{

    public Task<AuthorizationSessionCoreResponse> authorizationSessionAsync(ValidateTokenRequest body, CancellationToken cancellationToken);


    public Task<AuthorizationSessionWebResponse> createAuthorizationSessionAsync(CreateAuthorizationWebRequest body, CancellationToken cancellationToken);


    public Task<AuthorizationSessionWebResponse> createForAllServicesAuthorizationSessionAsync(CreateAuthorizationForServices body, CancellationToken cancellationToken);


    public Task<AuthorizationSessionWebResponse> createForDashboardAuthorizationSessionAsync(CreateAuthorizationForDashboard body, CancellationToken cancellationToken);


    public Task<AuthorizationSessionWebResponse> createForListServicesAuthorizationSessionAsync(CreateAuthorizationForListServices body, CancellationToken cancellationToken);


    public Task<DeletedResponse> deleteAuthorizationSessionAsync(string id, CancellationToken cancellationToken);


    public Task<TokenVm> encryptFromCore2AuthorizationSessionAsync(string encrptedToken, string coreToken, CancellationToken cancellationToken);


    public Task<TokenVm> encryptFromCoreAuthorizationSessionAsync(string sesstionToken, CancellationToken cancellationToken);


    public Task<TokenVm> encryptFromWebAuthorizationSessionAsync(EncryptTokenRequest body, CancellationToken cancellationToken);


    public Task<SessionVm> getActiveSessionAuthorizationSessionAsync(string userId, string type, CancellationToken cancellationToken);


    public Task<SessionVm> getSessionAuthorizationSessionAsync(string id, CancellationToken cancellationToken);


    public Task<SessionVm> getSessionByTokenAuthorizationSessionAsync(string token, CancellationToken cancellationToken);


    public Task<ICollection<SessionVm>> getSessionsAuthorizationSessionAsync(CancellationToken cancellationToken);


    public Task<DeletedResponse> pauseAuthorizationSessionAsync(string id, CancellationToken cancellationToken);


    public Task<DeletedResponse> resumeAuthorizationSessionAsync(string id, CancellationToken cancellationToken);


    public Task validateCoreTokenAuthorizationSessionAsync(string token, string coreToken, CancellationToken cancellationToken);


    public Task validateCreateTokenAuthorizationSessionAsync(string token, string coreToken, CancellationToken cancellationToken);


    public Task validateWebTokenAuthorizationSessionAsync(string token, CancellationToken cancellationToken);




}

