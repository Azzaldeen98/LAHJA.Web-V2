
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public class AuthService : IAuthService {


        
     private readonly ConfirmEmailAuthUseCase _confirmEmailAuthUseCase;
     private readonly ExternalLoginAuthUseCase _externalLoginAuthUseCase;
     private readonly ExternalLoginCallbackAuthUseCase _externalLoginCallbackAuthUseCase;
     private readonly ForgotPasswordAuthUseCase _forgotPasswordAuthUseCase;
     private readonly LoginAuthUseCase _loginAuthUseCase;
     private readonly LogoutAuthUseCase _logoutAuthUseCase;
     private readonly RefreshAuthUseCase _refreshAuthUseCase;
     private readonly RegisterAuthUseCase _registerAuthUseCase;
     private readonly ResendConfirmationEmailAuthUseCase _resendConfirmationEmailAuthUseCase;
     private readonly ResetPasswordAuthUseCase _resetPasswordAuthUseCase;


    public AuthService(   
            ConfirmEmailAuthUseCase confirmEmailAuthUseCase,
            ExternalLoginAuthUseCase externalLoginAuthUseCase,
            ExternalLoginCallbackAuthUseCase externalLoginCallbackAuthUseCase,
            ForgotPasswordAuthUseCase forgotPasswordAuthUseCase,
            LoginAuthUseCase loginAuthUseCase,
            LogoutAuthUseCase logoutAuthUseCase,
            RefreshAuthUseCase refreshAuthUseCase,
            RegisterAuthUseCase registerAuthUseCase,
            ResendConfirmationEmailAuthUseCase resendConfirmationEmailAuthUseCase,
            ResetPasswordAuthUseCase resetPasswordAuthUseCase)
    {
                        
          _confirmEmailAuthUseCase=confirmEmailAuthUseCase;
          _externalLoginAuthUseCase=externalLoginAuthUseCase;
          _externalLoginCallbackAuthUseCase=externalLoginCallbackAuthUseCase;
          _forgotPasswordAuthUseCase=forgotPasswordAuthUseCase;
          _loginAuthUseCase=loginAuthUseCase;
          _logoutAuthUseCase=logoutAuthUseCase;
          _refreshAuthUseCase=refreshAuthUseCase;
          _registerAuthUseCase=registerAuthUseCase;
          _resendConfirmationEmailAuthUseCase=resendConfirmationEmailAuthUseCase;
          _resetPasswordAuthUseCase=resetPasswordAuthUseCase;


    }

                

    public async Task confirmEmailAuthAsync(ConfirmEmailRequest body, CancellationToken cancellationToken)
   {

    

         await _confirmEmailAuthUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task externalLoginAuthAsync(string provider, string returnUrl, CancellationToken cancellationToken)
   {
        

         await _externalLoginAuthUseCase.ExecuteAsync(provider, returnUrl, cancellationToken);
        

   }



    public async Task externalLoginCallbackAuthAsync(string returnUrl, CancellationToken cancellationToken)
   {

    

         await _externalLoginCallbackAuthUseCase.ExecuteAsync(returnUrl, cancellationToken);
        

   }



    public async Task forgotPasswordAuthAsync(ForgotPasswordRequest body, CancellationToken cancellationToken)
   {

    

         await _forgotPasswordAuthUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<AccessTokenResponse> loginAuthAsync(bool? useCookies, bool? useSessionCookies, LoginRequest body, CancellationToken cancellationToken)
   {

    

         return   await _loginAuthUseCase.ExecuteAsync(useCookies, useSessionCookies, body, cancellationToken);
        

   }



    public async Task logoutAuthAsync(object body, CancellationToken cancellationToken)
   {

    

         await _logoutAuthUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<AccessTokenResponse> refreshAuthAsync(RefreshRequest body, CancellationToken cancellationToken)
   {

    

         return   await _refreshAuthUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task registerAuthAsync(RegisterRequest body, CancellationToken cancellationToken)
   {

    

         await _registerAuthUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<string> resendConfirmationEmailAuthAsync(ResendConfirmationEmailRequest body, CancellationToken cancellationToken)
   {

    

         return   await _resendConfirmationEmailAuthUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task resetPasswordAuthAsync(ResetPasswordRequest body, CancellationToken cancellationToken)
   {

    

         await _resetPasswordAuthUseCase.ExecuteAsync(body, cancellationToken);
        

   }





}
