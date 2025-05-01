

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetSubscriptionsUseCase : ITBaseUseCase {

    private readonly ISubscriptionsRepository _repository;
    public GetSubscriptionsUseCase(ISubscriptionsRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<SubscriptionResponse>> ExecuteAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.GetSubscriptionsAsync(cancellationToken);
        

   }


}
