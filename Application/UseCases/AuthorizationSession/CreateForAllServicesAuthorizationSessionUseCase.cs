

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class CreateForAllServicesAuthorizationSessionUseCase : ITBaseUseCase {

    private readonly IAuthorizationSessionRepository _repository;
    public CreateForAllServicesAuthorizationSessionUseCase(IAuthorizationSessionRepository repository){
        _repository=repository;
    }

                
    public async Task<AuthorizationSessionWebResponse> ExecuteAsync(CreateAuthorizationForServices body, CancellationToken cancellationToken)
   {

    
         return    await _repository.CreateForAllServicesAsync(body, cancellationToken);
        

   }


}
