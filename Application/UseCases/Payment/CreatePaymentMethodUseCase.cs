

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class CreatePaymentMethodUseCase : ITBaseUseCase {

    private readonly IPaymentRepository _repository;
    public CreatePaymentMethodUseCase(IPaymentRepository repository){
        _repository=repository;
    }

                
    public async Task<PaymentResponse> ExecuteAsync(PaymentMethodsRequest body, CancellationToken cancellationToken)
   {

    
         return    await _repository.CreatePaymentMethodAsync(body, cancellationToken);
        

   }


}
