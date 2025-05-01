

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class SettingPUTUseCase : ITBaseUseCase {

    private readonly ISettingRepository _repository;
    public SettingPUTUseCase(ISettingRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(string name, SettingUpdate body, CancellationToken cancellationToken)
   {

    
          await _repository.SettingPUTAsync(name, body, cancellationToken);
        

   }


}
