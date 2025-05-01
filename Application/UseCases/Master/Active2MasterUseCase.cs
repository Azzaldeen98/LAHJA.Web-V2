

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class Active2MasterUseCase : ITBaseUseCase {

    private readonly IMasterRepository _repository;
    public Active2MasterUseCase(IMasterRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<AdvertisementView>> ExecuteAsync(string lg, CancellationToken cancellationToken)
   {

    
         return    await _repository.Active2Async(lg, cancellationToken);
        

   }


}
