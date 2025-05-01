

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class CreateSubscriptionUseCase : ITBaseUseCase {

    private readonly ISubscriptionsRepository _repository;
    public CreateSubscriptionUseCase(ISubscriptionsRepository repository){
        _repository=repository;
    }

                
    public async Task<SubscriptionCreateResponse> ExecuteAsync(SubscriptionCreateRequest body, CancellationToken cancellationToken)
   {

    
         return    await _repository.CreateSubscriptionAsync(body, cancellationToken);
        

   }


}
