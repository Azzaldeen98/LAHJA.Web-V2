

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class CreateModelAiUseCase : ITBaseUseCase {

    private readonly IModelAiRepository _repository;
    public CreateModelAiUseCase(IModelAiRepository repository){
        _repository=repository;
    }

                
    public async Task<ModelAiResponse> ExecuteAsync(ModelAiCreate body, CancellationToken cancellationToken)
   {

    
         return    await _repository.CreateModelAiAsync(body, cancellationToken);
        

   }


}
