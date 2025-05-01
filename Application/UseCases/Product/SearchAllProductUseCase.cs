

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class SearchAllProductUseCase : ITBaseUseCase {

    private readonly IProductRepository _repository;
    public SearchAllProductUseCase(IProductRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<ProductResponse>> ExecuteAsync(string query, int? limit, string page, CancellationToken cancellationToken)
   {

    
         return    await _repository.SearchAllAsync(query, limit, page, cancellationToken);
        

   }


}
