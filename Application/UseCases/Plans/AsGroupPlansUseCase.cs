

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class AsGroupPlansUseCase : ITBaseUseCase {

    private readonly IPlansRepository _repository;
    public AsGroupPlansUseCase(IPlansRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<PlanView>> ExecuteAsync(string langauge, CancellationToken cancellationToken)
   {

    
         return    await _repository.AsGroupAsync(langauge, cancellationToken);
        

   }


}
