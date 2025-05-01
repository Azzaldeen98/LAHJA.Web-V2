

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetBySubscriptionIdSpaceUseCase : ITBaseUseCase {

    private readonly ISpaceRepository _repository;
    public GetBySubscriptionIdSpaceUseCase(ISpaceRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<SpaceResponse>> ExecuteAsync(string subscriptionId, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetBySubscriptionIdAsync(subscriptionId, cancellationToken);
        

   }


}
