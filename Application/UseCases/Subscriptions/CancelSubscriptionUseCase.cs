

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class CancelSubscriptionUseCase : ITBaseUseCase {

    private readonly ISubscriptionsRepository _repository;
    public CancelSubscriptionUseCase(ISubscriptionsRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
          await _repository.CancelSubscriptionAsync(id, cancellationToken);
        

   }


}
