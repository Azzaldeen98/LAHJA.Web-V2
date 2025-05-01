

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class SettingPOSTUseCase : ITBaseUseCase {

    private readonly ISettingRepository _repository;
    public SettingPOSTUseCase(ISettingRepository repository){
        _repository=repository;
    }

                
    public async Task<ServiceResponse> ExecuteAsync(SettingCreate body, CancellationToken cancellationToken)
   {

    
         return    await _repository.SettingPOSTAsync(body, cancellationToken);
        

   }


}
