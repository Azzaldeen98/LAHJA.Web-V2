

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class AssignPermissionRolesUseCase : ITBaseUseCase {

    private readonly IRolesRepository _repository;
    public AssignPermissionRolesUseCase(IRolesRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(RolePermitionAssign body, CancellationToken cancellationToken)
   {

    
          await _repository.AssignPermissionAsync(body, cancellationToken);
        

   }


}
