
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Infrastructure.Shared.ApiInvoker;
using AutoMapper;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Shared.ApiInvoker;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.DataSource.ApiClient2;


public class UserApiClient : BuildApiClient<UserClient>  , IUserApiClient {

  
    public UserApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, 
    IApiInvoker apiInvoker) : base(clientFactory, mapper, config, apiInvoker){

    }
                

    public   async Task<UserResponse> GetUserAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.GetUserAsync(id, cancellationToken);

    });
                

   }


    public   async Task<UserResponse> AssignServiceAsync(AssignService body, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.AssignServiceAsync(body, cancellationToken);

    });
                

   }


    public   async Task<UserResponse> AssignModelAiAsync(AssignModelAi body, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.AssignModelAiAsync(body, cancellationToken);

    });
                

   }


    public   async Task<UserResponse> AssignRoleAsync(RoleAssign body, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.AssignRoleAsync(body, cancellationToken);

    });
                

   }


}

