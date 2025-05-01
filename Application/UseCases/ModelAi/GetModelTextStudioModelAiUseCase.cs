

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetModelTextStudioModelAiUseCase : ITBaseUseCase {

    private readonly IModelAiRepository _repository;
    public GetModelTextStudioModelAiUseCase(IModelAiRepository repository){
        _repository=repository;
    }

                
    public async Task<IDictionary<string, object>> ExecuteAsync(string lg, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetModelTextStudioAsync(lg, cancellationToken);
        

   }


}
