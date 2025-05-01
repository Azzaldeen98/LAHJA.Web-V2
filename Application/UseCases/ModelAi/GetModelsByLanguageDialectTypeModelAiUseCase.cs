

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetModelsByLanguageDialectTypeModelAiUseCase : ITBaseUseCase {

    private readonly IModelAiRepository _repository;
    public GetModelsByLanguageDialectTypeModelAiUseCase(IModelAiRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<ModelAiResponse>> ExecuteAsync(string language, string dialect, string type, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetModelsByLanguageDialectTypeAsync(language, dialect, type, cancellationToken);
        

   }


}
