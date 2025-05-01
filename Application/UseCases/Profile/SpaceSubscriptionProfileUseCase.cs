

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class SpaceSubscriptionProfileUseCase : ITBaseUseCase {

    private readonly IProfileRepository _repository;
    public SpaceSubscriptionProfileUseCase(IProfileRepository repository){
        _repository=repository;
    }

                
    public async Task<SpaceResponse> ExecuteAsync(string subscriptionId, string spaceId, CancellationToken cancellationToken)
   {

    
         return    await _repository.SpaceSubscriptionAsync(subscriptionId, spaceId, cancellationToken);
        

   }


}
