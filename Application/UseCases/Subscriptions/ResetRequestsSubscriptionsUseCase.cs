

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class ResetRequestsSubscriptionsUseCase : ITBaseUseCase {

    private readonly ISubscriptionsRepository _repository;
    public ResetRequestsSubscriptionsUseCase(ISubscriptionsRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
          await _repository.ResetRequestsAsync(id, cancellationToken);
        

   }


}
