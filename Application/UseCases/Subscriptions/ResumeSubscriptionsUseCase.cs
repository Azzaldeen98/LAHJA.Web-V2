

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class ResumeSubscriptionsUseCase : ITBaseUseCase {

    private readonly ISubscriptionsRepository _repository;
    public ResumeSubscriptionsUseCase(ISubscriptionsRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(string id, SubscriptionResumeRequest body, CancellationToken cancellationToken)
   {

    
          await _repository.ResumeAsync(id, body, cancellationToken);
        

   }


}
