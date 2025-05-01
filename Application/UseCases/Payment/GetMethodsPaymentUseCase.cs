

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetMethodsPaymentUseCase : ITBaseUseCase {

    private readonly IPaymentRepository _repository;
    public GetMethodsPaymentUseCase(IPaymentRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<PaymentMethodResponse>> ExecuteAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.GetMethodsAsync(cancellationToken);
        

   }


}
