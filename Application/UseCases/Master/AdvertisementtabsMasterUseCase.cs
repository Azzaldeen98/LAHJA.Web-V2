

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class AdvertisementtabsMasterUseCase : ITBaseUseCase {

    private readonly IMasterRepository _repository;
    public AdvertisementtabsMasterUseCase(IMasterRepository repository){
        _repository=repository;
    }

                
    public async Task<AdvertisementTabView> ExecuteAsync(string lg, AdvertisementTabCreate body, CancellationToken cancellationToken)
   {

    
         return    await _repository.AdvertisementtabsAsync(lg, body, cancellationToken);
        

   }


}
