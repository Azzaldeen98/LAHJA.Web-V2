

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetModelsByCategoryModelAiUseCase : ITBaseUseCase {

    private readonly IModelAiRepository _repository;
    public GetModelsByCategoryModelAiUseCase(IModelAiRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<ModelAiResponse>> ExecuteAsync(string category, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetModelsByCategoryAsync(category, cancellationToken);
        

   }


}
