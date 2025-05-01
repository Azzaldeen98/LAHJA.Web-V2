

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class UpdatePlanUseCase : ITBaseUseCase {

    private readonly IPlansRepository _repository;
    public UpdatePlanUseCase(IPlansRepository repository){
        _repository=repository;
    }

                
    public async Task<PlanResponse> ExecuteAsync(string id, PlanUpdate body, CancellationToken cancellationToken)
   {

    
         return    await _repository.UpdatePlanAsync(id, body, cancellationToken);
        

   }


}
