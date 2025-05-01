

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class RolesGETUseCase : ITBaseUseCase {

    private readonly IRolesRepository _repository;
    public RolesGETUseCase(IRolesRepository repository){
        _repository=repository;
    }

                
    public async Task<RoleResponse> ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.RolesGETAsync(id, cancellationToken);
        

   }


}
