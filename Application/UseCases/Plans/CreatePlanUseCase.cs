

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class CreatePlanUseCase : ITBaseUseCase {

    private readonly IPlansRepository _repository;
    public CreatePlanUseCase(IPlansRepository repository){
        _repository=repository;
    }

                
    public async Task<PlanResponse> ExecuteAsync(string lg, PlanCreate body, CancellationToken cancellationToken)
   {

    
         return    await _repository.CreatePlanAsync(lg, body, cancellationToken);
        

   }


}
