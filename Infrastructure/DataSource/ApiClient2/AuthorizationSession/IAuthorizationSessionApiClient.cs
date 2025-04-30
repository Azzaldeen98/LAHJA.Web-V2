
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Infrastructure.Shared.ApiInvoker;
using AutoMapper;
using Shared.AutoGenerator.Interfaces;
using Infrastructure.DataSource.ApiClient2.Base;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Shared.ApiInvoker;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.DataSource.ApiClient2;

public interface IAuthorizationSessionApiClient
 :  ITBaseApiClient  
{
public Task<ICollection<SessionVm>> GetSessionsAsync(CancellationToken cancellationToken);

public Task<AuthorizationSessionWebResponse> CreateAuthorizationSessionAsync(CreateAuthorizationWebRequest body, CancellationToken cancellationToken);

public Task<SessionVm> GetSessionAsync(string id, CancellationToken cancellationToken);

public Task<DeletedResponse> DeleteAuthorizationSessionAsync(string id, CancellationToken cancellationToken);

public Task<SessionVm> GetSessionByTokenAsync(string token, CancellationToken cancellationToken);

public Task<SessionVm> GetActiveSessionAsync(string userId, string type, CancellationToken cancellationToken);

public Task<AuthorizationSessionCoreResponse> AuthorizationSessionAsync(ValidateTokenRequest body, CancellationToken cancellationToken);

public Task<AuthorizationSessionWebResponse> CreateForDashboardAsync(CreateAuthorizationForDashboard body, CancellationToken cancellationToken);

public Task<AuthorizationSessionWebResponse> CreateForListServicesAsync(CreateAuthorizationForListServices body, CancellationToken cancellationToken);

public Task<AuthorizationSessionWebResponse> CreateForAllServicesAsync(CreateAuthorizationForServices body, CancellationToken cancellationToken);

public Task<TokenVm> EncryptFromWebAsync(EncryptTokenRequest body, CancellationToken cancellationToken);

public Task<TokenVm> EncryptFromCoreAsync(string sesstionToken, CancellationToken cancellationToken);

public Task<TokenVm> EncryptFromCore2Async(string encrptedToken, string coreToken, CancellationToken cancellationToken);

public Task ValidateWebTokenAsync(string token, CancellationToken cancellationToken);

public Task ValidateCreateTokenAsync(string token, string coreToken, CancellationToken cancellationToken);

public Task ValidateCoreTokenAsync(string token, string coreToken, CancellationToken cancellationToken);

public Task<DeletedResponse> PauseAuthorizationSessionAsync(string id, CancellationToken cancellationToken);

public Task<DeletedResponse> ResumeAuthorizationSessionAsync(string id, CancellationToken cancellationToken);

}

