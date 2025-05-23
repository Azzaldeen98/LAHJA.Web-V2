
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Infrastructure.Share.Invoker;
using AutoMapper;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Share.Invoker;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.DataSource.ApiClient2;


 public  class RolesApiClient : BuildApiClient<RolesClient>  , IRolesApiClient {

  
    public RolesApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, 
    IApiInvoker apiInvoker) : base(clientFactory, mapper, config, apiInvoker){

    }
                

    public   async Task<ICollection<object>> RolesAllAsync(CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.RolesAllAsync(cancellationToken);

    });
                

   }


    public   async Task RolesPOSTAsync(RoleCreate body, CancellationToken cancellationToken)
   {

    
                
     await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
          await client.RolesPOSTAsync(body, cancellationToken);

    });
                

   }


    public   async Task<RoleResponse> RolesGETAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.RolesGETAsync(id, cancellationToken);

    });
                

   }


    public   async Task RolesDELETEAsync(string id, CancellationToken cancellationToken)
   {

    
                
     await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
          await client.RolesDELETEAsync(id, cancellationToken);

    });
                

   }


    public   async Task AssignPermissionAsync(RolePermitionAssign body, CancellationToken cancellationToken)
   {

    
                
     await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
          await client.AssignPermissionAsync(body, cancellationToken);

    });
                

   }


}

