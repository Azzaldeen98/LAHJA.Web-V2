

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetModelsByLanguageAndDialectModelAiUseCase : ITBaseUseCase {

    private readonly IModelAiRepository _repository;
    public GetModelsByLanguageAndDialectModelAiUseCase(IModelAiRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<ModelAiResponse>> ExecuteAsync(string language, string dialect, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetModelsByLanguageAndDialectAsync(language, dialect, cancellationToken);
        

   }


}
