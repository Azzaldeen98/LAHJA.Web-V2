

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class UpdateBillingInformationPaymentUseCase : ITBaseUseCase {

    private readonly IPaymentRepository _repository;
    public UpdateBillingInformationPaymentUseCase(IPaymentRepository repository){
        _repository=repository;
    }

                
    public async Task<CustomerResponse> ExecuteAsync(BillingInformationRequest body, CancellationToken cancellationToken)
   {

    
         return    await _repository.UpdateBillingInformationAsync(body, cancellationToken);
        

   }


}
