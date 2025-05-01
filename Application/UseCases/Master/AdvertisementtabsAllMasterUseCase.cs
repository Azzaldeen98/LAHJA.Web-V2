

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class AdvertisementtabsAllMasterUseCase : ITBaseUseCase {

    private readonly IMasterRepository _repository;
    public AdvertisementtabsAllMasterUseCase(IMasterRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<AdvertisementTabView>> ExecuteAsync(string advertisementId, string lg, CancellationToken cancellationToken)
   {

    
         return    await _repository.AdvertisementtabsAllAsync(advertisementId, lg, cancellationToken);
        

   }


}
