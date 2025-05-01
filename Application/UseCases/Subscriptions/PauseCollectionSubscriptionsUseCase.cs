

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class PauseCollectionSubscriptionsUseCase : ITBaseUseCase {

    private readonly ISubscriptionsRepository _repository;
    public PauseCollectionSubscriptionsUseCase(ISubscriptionsRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(string id, SubscriptionUpdateRequest body, CancellationToken cancellationToken)
   {

    
          await _repository.PauseCollectionAsync(id, body, cancellationToken);
        

   }


}
