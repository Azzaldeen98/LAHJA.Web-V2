

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetModelsByTypeAndGenderModelAiUseCase : ITBaseUseCase {

    private readonly IModelAiRepository _repository;
    public GetModelsByTypeAndGenderModelAiUseCase(IModelAiRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<ModelAiResponse>> ExecuteAsync(string type, string gender, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetModelsByTypeAndGenderAsync(type, gender, cancellationToken);
        

   }


}
