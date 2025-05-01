
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public interface IAuthService :  ITBaseService ,  ITScope  
{

    public Task confirmEmailAuthAsync(ConfirmEmailRequest body, CancellationToken cancellationToken);


    public Task externalLoginAuthAsync(string provider, string returnUrl, CancellationToken cancellationToken);


    public Task externalLoginCallbackAuthAsync(string returnUrl, CancellationToken cancellationToken);


    public Task forgotPasswordAuthAsync(ForgotPasswordRequest body, CancellationToken cancellationToken);


    public Task<AccessTokenResponse> loginAuthAsync(bool? useCookies, bool? useSessionCookies, LoginRequest body, CancellationToken cancellationToken);


    public Task logoutAuthAsync(object body, CancellationToken cancellationToken);


    public Task<AccessTokenResponse> refreshAuthAsync(RefreshRequest body, CancellationToken cancellationToken);


    public Task registerAuthAsync(RegisterRequest body, CancellationToken cancellationToken);


    public Task<string> resendConfirmationEmailAuthAsync(ResendConfirmationEmailRequest body, CancellationToken cancellationToken);


    public Task resetPasswordAuthAsync(ResetPasswordRequest body, CancellationToken cancellationToken);




}

