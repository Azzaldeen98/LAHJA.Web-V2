

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class FilterMaodelAi2ModelAiUseCase : ITBaseUseCase {

    private readonly IModelAiRepository _repository;
    public FilterMaodelAi2ModelAiUseCase(IModelAiRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<ModelAiResponse>> ExecuteAsync(FilterModelAI body, CancellationToken cancellationToken)
   {

    
         return    await _repository.FilterMaodelAi2Async(body, cancellationToken);
        

   }


}
