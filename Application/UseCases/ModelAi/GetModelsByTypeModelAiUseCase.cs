

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetModelsByTypeModelAiUseCase : ITBaseUseCase {

    private readonly IModelAiRepository _repository;
    public GetModelsByTypeModelAiUseCase(IModelAiRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<ArrayResponse>> ExecuteAsync(string type, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetModelsByTypeAsync(type, cancellationToken);
        

   }


}
