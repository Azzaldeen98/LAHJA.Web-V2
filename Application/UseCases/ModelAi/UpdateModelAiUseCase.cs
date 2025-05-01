

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class UpdateModelAiUseCase : ITBaseUseCase {

    private readonly IModelAiRepository _repository;
    public UpdateModelAiUseCase(IModelAiRepository repository){
        _repository=repository;
    }

                
    public async Task<ModelAiResponse> ExecuteAsync(string id, ModelAiUpdate body, CancellationToken cancellationToken)
   {

    
         return    await _repository.UpdateModelAiAsync(id, body, cancellationToken);
        

   }


}
