

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class SettingDELETEUseCase : ITBaseUseCase {

    private readonly ISettingRepository _repository;
    public SettingDELETEUseCase(ISettingRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(string name, CancellationToken cancellationToken)
   {

    
          await _repository.SettingDELETEAsync(name, cancellationToken);
        

   }


}
