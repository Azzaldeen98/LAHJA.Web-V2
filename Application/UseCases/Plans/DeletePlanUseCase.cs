

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class DeletePlanUseCase : ITBaseUseCase {

    private readonly IPlansRepository _repository;
    public DeletePlanUseCase(IPlansRepository repository){
        _repository=repository;
    }

                
    public async Task<DeletedResponse> ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.DeletePlanAsync(id, cancellationToken);
        

   }


}
