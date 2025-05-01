

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class CreateCustomerSessionPaymentUseCase : ITBaseUseCase {

    private readonly IPaymentRepository _repository;
    public CreateCustomerSessionPaymentUseCase(IPaymentRepository repository){
        _repository=repository;
    }

                
    public async Task<PaymentResponse> ExecuteAsync(PaymentMethodsRequest body, CancellationToken cancellationToken)
   {

    
         return    await _repository.CreateCustomerSessionAsync(body, cancellationToken);
        

   }


}
