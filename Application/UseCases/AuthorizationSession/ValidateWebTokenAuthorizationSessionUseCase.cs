

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class ValidateWebTokenAuthorizationSessionUseCase : ITBaseUseCase {

    private readonly IAuthorizationSessionRepository _repository;
    public ValidateWebTokenAuthorizationSessionUseCase(IAuthorizationSessionRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(string token, CancellationToken cancellationToken)
   {

    
          await _repository.ValidateWebTokenAsync(token, cancellationToken);
        

   }


}
