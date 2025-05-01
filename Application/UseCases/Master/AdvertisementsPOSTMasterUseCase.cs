

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class AdvertisementsPOSTMasterUseCase : ITBaseUseCase {

    private readonly IMasterRepository _repository;
    public AdvertisementsPOSTMasterUseCase(IMasterRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(string lg, AdvertisementCreate body, CancellationToken cancellationToken)
   {

    
          await _repository.AdvertisementsPOSTAsync(lg, body, cancellationToken);
        

   }


}
