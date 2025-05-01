

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetLanguagesByModelAiUseCase : ITBaseUseCase {

    private readonly IModelAiRepository _repository;
    public GetLanguagesByModelAiUseCase(IModelAiRepository repository){
        _repository=repository;
    }

                
    public async Task<ArrayResponse> ExecuteAsync(string type, string category, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetLanguagesByAsync(type, category, cancellationToken);
        

   }


}
