

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetPriceUseCase : ITBaseUseCase {

    private readonly IPriceRepository _repository;
    public GetPriceUseCase(IPriceRepository repository){
        _repository=repository;
    }

                
    public async Task<PriceResponse> ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetPriceAsync(id, cancellationToken);
        

   }


}
