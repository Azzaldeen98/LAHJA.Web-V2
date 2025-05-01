

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class CreateForListServicesAuthorizationSessionUseCase : ITBaseUseCase {

    private readonly IAuthorizationSessionRepository _repository;
    public CreateForListServicesAuthorizationSessionUseCase(IAuthorizationSessionRepository repository){
        _repository=repository;
    }

                
    public async Task<AuthorizationSessionWebResponse> ExecuteAsync(CreateAuthorizationForListServices body, CancellationToken cancellationToken)
   {

    
         return    await _repository.CreateForListServicesAsync(body, cancellationToken);
        

   }


}
