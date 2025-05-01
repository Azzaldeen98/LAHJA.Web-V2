

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class RolesAllUseCase : ITBaseUseCase {

    private readonly IRolesRepository _repository;
    public RolesAllUseCase(IRolesRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<object>> ExecuteAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.RolesAllAsync(cancellationToken);
        

   }


}
