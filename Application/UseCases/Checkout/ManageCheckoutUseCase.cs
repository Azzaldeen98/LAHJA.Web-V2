

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class ManageCheckoutUseCase : ITBaseUseCase {

    private readonly ICheckoutRepository _repository;
    public ManageCheckoutUseCase(ICheckoutRepository repository){
        _repository=repository;
    }

                
    public async Task<CheckoutResponse> ExecuteAsync(SessionCreate body, CancellationToken cancellationToken)
   {

    
         return    await _repository.ManageAsync(body, cancellationToken);
        

   }


}
