

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class SettingAllUseCase : ITBaseUseCase {

    private readonly ISettingRepository _repository;
    public SettingAllUseCase(ISettingRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<object>> ExecuteAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.SettingAllAsync(cancellationToken);
        

   }


}
