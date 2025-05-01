

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetProductUseCase : ITBaseUseCase {

    private readonly IProductRepository _repository;
    public GetProductUseCase(IProductRepository repository){
        _repository=repository;
    }

                
    public async Task<ProductResponse> ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetProductAsync(id, cancellationToken);
        

   }


}
