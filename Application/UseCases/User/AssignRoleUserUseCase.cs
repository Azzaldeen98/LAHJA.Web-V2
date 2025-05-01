

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class AssignRoleUserUseCase : ITBaseUseCase {

    private readonly IUserRepository _repository;
    public AssignRoleUserUseCase(IUserRepository repository){
        _repository=repository;
    }

                
    public async Task<UserResponse> ExecuteAsync(RoleAssign body, CancellationToken cancellationToken)
   {

    
         return    await _repository.AssignRoleAsync(body, cancellationToken);
        

   }


}
