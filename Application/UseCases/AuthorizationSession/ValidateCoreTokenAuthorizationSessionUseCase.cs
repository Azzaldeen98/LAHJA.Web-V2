

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class ValidateCoreTokenAuthorizationSessionUseCase : ITBaseUseCase {

    private readonly IAuthorizationSessionRepository _repository;
    public ValidateCoreTokenAuthorizationSessionUseCase(IAuthorizationSessionRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(string token, string coreToken, CancellationToken cancellationToken)
   {

    
          await _repository.ValidateCoreTokenAsync(token, coreToken, cancellationToken);
        

   }


}
