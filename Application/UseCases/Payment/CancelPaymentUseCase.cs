

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class CancelPaymentUseCase : ITBaseUseCase {

    private readonly IPaymentRepository _repository;
    public CancelPaymentUseCase(IPaymentRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
          await _repository.CancelAsync(id, cancellationToken);
        

   }


}
