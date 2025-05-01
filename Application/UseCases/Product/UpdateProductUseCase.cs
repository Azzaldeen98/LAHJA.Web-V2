

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class UpdateProductUseCase : ITBaseUseCase {

    private readonly IProductRepository _repository;
    public UpdateProductUseCase(IProductRepository repository){
        _repository=repository;
    }

                
    public async Task<ProductResponse> ExecuteAsync(string id, ProductUpdate body, CancellationToken cancellationToken)
   {

    
         return    await _repository.UpdateProductAsync(id, body, cancellationToken);
        

   }


}
