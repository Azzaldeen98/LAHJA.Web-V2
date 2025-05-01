

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetCategoriesByTypeModelAiUseCase : ITBaseUseCase {

    private readonly IModelAiRepository _repository;
    public GetCategoriesByTypeModelAiUseCase(IModelAiRepository repository){
        _repository=repository;
    }

                
    public async Task<ArrayResponse> ExecuteAsync(string type, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetCategoriesByTypeAsync(type, cancellationToken);
        

   }


}
