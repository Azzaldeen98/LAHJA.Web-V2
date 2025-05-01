

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class AuthorizationSessionUseCase : ITBaseUseCase {

    private readonly IAuthorizationSessionRepository _repository;
    public AuthorizationSessionUseCase(IAuthorizationSessionRepository repository){
        _repository=repository;
    }

                
    public async Task<AuthorizationSessionCoreResponse> ExecuteAsync(ValidateTokenRequest body, CancellationToken cancellationToken)
   {

    
         return    await _repository.AuthorizationSessionAsync(body, cancellationToken);
        

   }


}
