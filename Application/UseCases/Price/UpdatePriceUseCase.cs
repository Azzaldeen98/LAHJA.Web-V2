

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class UpdatePriceUseCase : ITBaseUseCase {

    private readonly IPriceRepository _repository;
    public UpdatePriceUseCase(IPriceRepository repository){
        _repository=repository;
    }

                
    public async Task<PriceResponse> ExecuteAsync(string id, PriceUpdate body, CancellationToken cancellationToken)
   {

    
         return    await _repository.UpdatePriceAsync(id, body, cancellationToken);
        

   }


}
