

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class MakePaymentMethodDefaultUseCase : ITBaseUseCase {

    private readonly IPaymentRepository _repository;
    public MakePaymentMethodDefaultUseCase(IPaymentRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(string paymentMethodId, CancellationToken cancellationToken)
   {

    
          await _repository.MakePaymentMethodDefaultAsync(paymentMethodId, cancellationToken);
        

   }


}
