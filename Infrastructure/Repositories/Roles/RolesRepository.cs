
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


 public  class RolesRepository : IRolesRepository {

    private readonly IRolesApiClient _apiClient;
    public RolesRepository(IRolesApiClient apiClient){
        _apiClient=apiClient;
    }
                

    public async Task<ICollection<object>> RolesAllAsync(CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.RolesAllAsync(cancellationToken);
                

   }


    public async Task RolesPOSTAsync(RoleCreate body, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.RolesPOSTAsync(body, cancellationToken);
                

   }


    public async Task<RoleResponse> RolesGETAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.RolesGETAsync(id, cancellationToken);
                

   }


    public async Task RolesDELETEAsync(string id, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.RolesDELETEAsync(id, cancellationToken);
                

   }


    public async Task AssignPermissionAsync(RolePermitionAssign body, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.AssignPermissionAsync(body, cancellationToken);
                

   }


}

