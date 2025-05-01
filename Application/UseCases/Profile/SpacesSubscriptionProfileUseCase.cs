

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class SpacesSubscriptionProfileUseCase : ITBaseUseCase {

    private readonly IProfileRepository _repository;
    public SpacesSubscriptionProfileUseCase(IProfileRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<SpaceResponse>> ExecuteAsync(string subscriptionId, CancellationToken cancellationToken)
   {

    
         return    await _repository.SpacesSubscriptionAsync(subscriptionId, cancellationToken);
        

   }


}
