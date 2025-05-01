

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class SubscriptionsProfileUseCase : ITBaseUseCase {

    private readonly IProfileRepository _repository;
    public SubscriptionsProfileUseCase(IProfileRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<SubscriptionResponse>> ExecuteAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.SubscriptionsAsync(cancellationToken);
        

   }


}
