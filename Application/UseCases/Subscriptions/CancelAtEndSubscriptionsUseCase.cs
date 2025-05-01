

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class CancelAtEndSubscriptionsUseCase : ITBaseUseCase {

    private readonly ISubscriptionsRepository _repository;
    public CancelAtEndSubscriptionsUseCase(ISubscriptionsRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
          await _repository.CancelAtEndAsync(id, cancellationToken);
        

   }


}
