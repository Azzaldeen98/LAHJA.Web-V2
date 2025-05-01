

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class ConfirmPaymentUseCase : ITBaseUseCase {

    private readonly IPaymentRepository _repository;
    public ConfirmPaymentUseCase(IPaymentRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
          await _repository.ConfirmAsync(id, cancellationToken);
        

   }


}
