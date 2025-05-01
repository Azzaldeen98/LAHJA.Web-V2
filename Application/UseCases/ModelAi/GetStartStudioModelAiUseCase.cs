

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetStartStudioModelAiUseCase : ITBaseUseCase {

    private readonly IModelAiRepository _repository;
    public GetStartStudioModelAiUseCase(IModelAiRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<Item>> ExecuteAsync(string lg, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetStartStudioAsync(lg, cancellationToken);
        

   }


}
