

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class DeleteModelAiUseCase : ITBaseUseCase {

    private readonly IModelAiRepository _repository;
    public DeleteModelAiUseCase(IModelAiRepository repository){
        _repository=repository;
    }

                
    public async Task<DeletedResponse> ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.DeleteModelAiAsync(id, cancellationToken);
        

   }


}
