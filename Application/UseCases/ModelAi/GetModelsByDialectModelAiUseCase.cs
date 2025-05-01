

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetModelsByDialectModelAiUseCase : ITBaseUseCase {

    private readonly IModelAiRepository _repository;
    public GetModelsByDialectModelAiUseCase(IModelAiRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<ModelAiResponse>> ExecuteAsync(string dialect, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetModelsByDialectAsync(dialect, cancellationToken);
        

   }


}
