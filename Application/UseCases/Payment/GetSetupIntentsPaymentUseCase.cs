

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetSetupIntentsPaymentUseCase : ITBaseUseCase {

    private readonly IPaymentRepository _repository;
    public GetSetupIntentsPaymentUseCase(IPaymentRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(CancellationToken cancellationToken)
   {

    
          await _repository.GetSetupIntentsAsync(cancellationToken);
        

   }


}
