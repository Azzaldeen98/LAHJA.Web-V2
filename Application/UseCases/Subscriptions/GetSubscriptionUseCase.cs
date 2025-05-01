

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetSubscriptionUseCase : ITBaseUseCase {

    private readonly ISubscriptionsRepository _repository;
    public GetSubscriptionUseCase(ISubscriptionsRepository repository){
        _repository=repository;
    }

                
    public async Task<SubscriptionResponse> ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetSubscriptionAsync(id, cancellationToken);
        

   }


}
