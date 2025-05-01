

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetPricesUseCase : ITBaseUseCase {

    private readonly IPriceRepository _repository;
    public GetPricesUseCase(IPriceRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<PriceResponse>> ExecuteAsync(string productId, bool? active, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetPricesAsync(productId, active, cancellationToken);
        

   }


}
