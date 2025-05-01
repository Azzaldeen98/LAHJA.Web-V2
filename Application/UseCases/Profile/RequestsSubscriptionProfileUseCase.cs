

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class RequestsSubscriptionProfileUseCase : ITBaseUseCase {

    private readonly IProfileRepository _repository;
    public RequestsSubscriptionProfileUseCase(IProfileRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<RequestResponse>> ExecuteAsync(string subscriptionId, CancellationToken cancellationToken)
   {

    
         return    await _repository.RequestsSubscriptionAsync(subscriptionId, cancellationToken);
        

   }


}
