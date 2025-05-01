
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public interface IAuthRepository :  ITBaseRepository ,  ITScope  
{
    public Task LogoutAsync(object body, CancellationToken cancellationToken);

    public Task RegisterAsync(RegisterRequest body, CancellationToken cancellationToken);

    public Task<AccessTokenResponse> LoginAsync(bool? useCookies, bool? useSessionCookies, LoginRequest body, CancellationToken cancellationToken);

    public Task<AccessTokenResponse> RefreshAsync(RefreshRequest body, CancellationToken cancellationToken);

    public Task ConfirmEmailAsync(ConfirmEmailRequest body, CancellationToken cancellationToken);

    public Task<string> ResendConfirmationEmailAsync(ResendConfirmationEmailRequest body, CancellationToken cancellationToken);

    public Task ForgotPasswordAsync(ForgotPasswordRequest body, CancellationToken cancellationToken);

    public Task ResetPasswordAsync(ResetPasswordRequest body, CancellationToken cancellationToken);

    public Task ExternalLoginAsync(string provider, string returnUrl, CancellationToken cancellationToken);

    public Task ExternalLoginCallbackAsync(string returnUrl, CancellationToken cancellationToken);

}

