

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class FilterMaodelAiModelAiUseCase : ITBaseUseCase {

    private readonly IModelAiRepository _repository;
    public FilterMaodelAiModelAiUseCase(IModelAiRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<ModelAiResponse>> ExecuteAsync(FilterModelAI body, CancellationToken cancellationToken)
   {

    
         return    await _repository.FilterMaodelAiAsync(body, cancellationToken);
        

   }


}
