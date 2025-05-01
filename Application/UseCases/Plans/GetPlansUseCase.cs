

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetPlansUseCase : ITBaseUseCase {

    private readonly IPlansRepository _repository;
    public GetPlansUseCase(IPlansRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<PlanView>> ExecuteAsync(string lg, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetPlansAsync(lg, cancellationToken);
        

   }


}
