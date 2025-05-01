

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class CreatePriceUseCase : ITBaseUseCase {

    private readonly IPriceRepository _repository;
    public CreatePriceUseCase(IPriceRepository repository){
        _repository=repository;
    }

                
    public async Task<PriceResponse> ExecuteAsync(PriceCreate body, CancellationToken cancellationToken)
   {

    
         return    await _repository.CreatePriceAsync(body, cancellationToken);
        

   }


}
