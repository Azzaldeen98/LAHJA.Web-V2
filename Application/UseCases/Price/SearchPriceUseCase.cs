

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class SearchPriceUseCase : ITBaseUseCase {

    private readonly IPriceRepository _repository;
    public SearchPriceUseCase(IPriceRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(PriceSearchOptions body, CancellationToken cancellationToken)
   {

    
          await _repository.SearchAsync(body, cancellationToken);
        

   }


}
