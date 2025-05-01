

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class RolesPOSTUseCase : ITBaseUseCase {

    private readonly IRolesRepository _repository;
    public RolesPOSTUseCase(IRolesRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(RoleCreate body, CancellationToken cancellationToken)
   {

    
          await _repository.RolesPOSTAsync(body, cancellationToken);
        

   }


}
