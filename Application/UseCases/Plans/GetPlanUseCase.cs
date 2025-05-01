

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetPlanUseCase : ITBaseUseCase {

    private readonly IPlansRepository _repository;
    public GetPlanUseCase(IPlansRepository repository){
        _repository=repository;
    }

                
    public async Task<PlanView> ExecuteAsync(string id, string lg, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetPlanAsync(id, lg, cancellationToken);
        

   }


}
