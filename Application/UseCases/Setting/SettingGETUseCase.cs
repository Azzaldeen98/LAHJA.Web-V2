

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class SettingGETUseCase : ITBaseUseCase {

    private readonly ISettingRepository _repository;
    public SettingGETUseCase(ISettingRepository repository){
        _repository=repository;
    }

                
    public async Task<ServiceResponse> ExecuteAsync(string name, CancellationToken cancellationToken)
   {

    
         return    await _repository.SettingGETAsync(name, cancellationToken);
        

   }


}
