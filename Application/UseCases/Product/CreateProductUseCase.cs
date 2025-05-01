

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class CreateProductUseCase : ITBaseUseCase {

    private readonly IProductRepository _repository;
    public CreateProductUseCase(IProductRepository repository){
        _repository=repository;
    }

                
    public async Task<ProductResponse> ExecuteAsync(ProductCreate body, CancellationToken cancellationToken)
   {

    
         return    await _repository.CreateProductAsync(body, cancellationToken);
        

   }


}
