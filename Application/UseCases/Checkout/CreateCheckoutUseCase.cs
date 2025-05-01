

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class CreateCheckoutUseCase : ITBaseUseCase {

    private readonly ICheckoutRepository _repository;
    public CreateCheckoutUseCase(ICheckoutRepository repository){
        _repository=repository;
    }

                
    public async Task<CheckoutResponse> ExecuteAsync(CheckoutOptions body, CancellationToken cancellationToken)
   {

    
         return    await _repository.CreateCheckoutAsync(body, cancellationToken);
        

   }


}
