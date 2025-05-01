

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class AdvertisementtabMasterUseCase : ITBaseUseCase {

    private readonly IMasterRepository _repository;
    public AdvertisementtabMasterUseCase(IMasterRepository repository){
        _repository=repository;
    }

                
    public async Task<AdvertisementTabView> ExecuteAsync(string id, string lg, CancellationToken cancellationToken)
   {

    
         return    await _repository.AdvertisementtabAsync(id, lg, cancellationToken);
        

   }


}
