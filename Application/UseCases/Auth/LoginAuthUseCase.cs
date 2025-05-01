

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class LoginAuthUseCase : ITBaseUseCase {

    private readonly IAuthRepository _repository;
    public LoginAuthUseCase(IAuthRepository repository){
        _repository=repository;
    }

                
    public async Task<AccessTokenResponse> ExecuteAsync(bool? useCookies, bool? useSessionCookies, LoginRequest body, CancellationToken cancellationToken)
   {

    
         return    await _repository.LoginAsync(useCookies, useSessionCookies, body, cancellationToken);
        

   }


}
