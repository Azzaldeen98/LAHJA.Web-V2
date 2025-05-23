
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


 public  class UserRepository : IUserRepository {

    private readonly IUserApiClient _apiClient;
    public UserRepository(IUserApiClient apiClient){
        _apiClient=apiClient;
    }
                

    public async Task<UserResponse> GetUserAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetUserAsync(id, cancellationToken);
                

   }


    public async Task<UserResponse> AssignServiceAsync(AssignService body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.AssignServiceAsync(body, cancellationToken);
                

   }


    public async Task<UserResponse> AssignModelAiAsync(AssignModelAi body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.AssignModelAiAsync(body, cancellationToken);
                

   }


    public async Task<UserResponse> AssignRoleAsync(RoleAssign body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.AssignRoleAsync(body, cancellationToken);
                

   }


}

