

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetSettingModelAiUseCase : ITBaseUseCase {

    private readonly IModelAiRepository _repository;
    public GetSettingModelAiUseCase(IModelAiRepository repository){
        _repository=repository;
    }

                
    public async Task<ModelPropertyValues> ExecuteAsync(string langage, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetSettingModelAiAsync(langage, cancellationToken);
        

   }


}
