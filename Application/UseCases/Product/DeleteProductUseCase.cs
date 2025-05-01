

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class DeleteProductUseCase : ITBaseUseCase {

    private readonly IProductRepository _repository;
    public DeleteProductUseCase(IProductRepository repository){
        _repository=repository;
    }

                
    public async Task<DeletedResponse> ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.DeleteProductAsync(id, cancellationToken);
        

   }


}
