
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public class RolesService : IRolesService {


        
     private readonly AssignPermissionRolesUseCase _assignPermissionRolesUseCase;
     private readonly RolesAllUseCase _rolesAllUseCase;
     private readonly RolesDELETEUseCase _rolesDELETEUseCase;
     private readonly RolesGETUseCase _rolesGETUseCase;
     private readonly RolesPOSTUseCase _rolesPOSTUseCase;


    public RolesService(   
            AssignPermissionRolesUseCase assignPermissionRolesUseCase,
            RolesAllUseCase rolesAllUseCase,
            RolesDELETEUseCase rolesDELETEUseCase,
            RolesGETUseCase rolesGETUseCase,
            RolesPOSTUseCase rolesPOSTUseCase)
    {
                        
          _assignPermissionRolesUseCase=assignPermissionRolesUseCase;
          _rolesAllUseCase=rolesAllUseCase;
          _rolesDELETEUseCase=rolesDELETEUseCase;
          _rolesGETUseCase=rolesGETUseCase;
          _rolesPOSTUseCase=rolesPOSTUseCase;


    }

                

    public async Task assignPermissionRolesAsync(RolePermitionAssign body, CancellationToken cancellationToken)
   {

    

         await _assignPermissionRolesUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<ICollection<object>> rolesAllAsync(CancellationToken cancellationToken)
   {

    

         return   await _rolesAllUseCase.ExecuteAsync(cancellationToken);
        

   }



    public async Task rolesDELETEAsync(string id, CancellationToken cancellationToken)
   {

    

         await _rolesDELETEUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task<RoleResponse> rolesGETAsync(string id, CancellationToken cancellationToken)
   {

    

         return   await _rolesGETUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task rolesPOSTAsync(RoleCreate body, CancellationToken cancellationToken)
   {

    

         await _rolesPOSTUseCase.ExecuteAsync(body, cancellationToken);
        

   }





}
