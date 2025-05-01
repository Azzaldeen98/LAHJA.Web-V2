

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetModelAiUseCase : ITBaseUseCase {

    private readonly IModelAiRepository _repository;
    public GetModelAiUseCase(IModelAiRepository repository){
        _repository=repository;
    }

                
    public async Task<ModelAiResponse> ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetModelAiAsync(id, cancellationToken);
        

   }


}
