

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetProductsUseCase : ITBaseUseCase {

    private readonly IProductRepository _repository;
    public GetProductsUseCase(IProductRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<ProductResponse>> ExecuteAsync(string startingAfter, string endingBefore, long? limit, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetProductsAsync(startingAfter, endingBefore, limit, cancellationToken);
        

   }


}
