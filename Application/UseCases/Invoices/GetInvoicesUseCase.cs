

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetInvoicesUseCase : ITBaseUseCase {

    private readonly IInvoicesRepository _repository;
    public GetInvoicesUseCase(IInvoicesRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<Invoice>> ExecuteAsync(string customerId, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetInvoicesAsync(customerId, cancellationToken);
        

   }


}
