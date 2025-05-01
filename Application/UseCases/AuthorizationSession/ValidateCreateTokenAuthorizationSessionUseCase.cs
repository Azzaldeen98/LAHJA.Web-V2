

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class ValidateCreateTokenAuthorizationSessionUseCase : ITBaseUseCase {

    private readonly IAuthorizationSessionRepository _repository;
    public ValidateCreateTokenAuthorizationSessionUseCase(IAuthorizationSessionRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(string token, string coreToken, CancellationToken cancellationToken)
   {

    
          await _repository.ValidateCreateTokenAsync(token, coreToken, cancellationToken);
        

   }


}
