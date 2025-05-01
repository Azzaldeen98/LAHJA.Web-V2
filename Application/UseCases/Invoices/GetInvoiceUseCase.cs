

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetInvoiceUseCase : ITBaseUseCase {

    private readonly IInvoicesRepository _repository;
    public GetInvoiceUseCase(IInvoicesRepository repository){
        _repository=repository;
    }

                
    public async Task<Invoice> ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetInvoiceAsync(id, cancellationToken);
        

   }


}
