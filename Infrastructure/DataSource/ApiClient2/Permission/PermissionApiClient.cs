
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


public class PermissionApiClient : BuildApiClient<PermissionClient>  , IPermissionApiClient {

  
    public PermissionApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, 
    IApiInvoker apiInvoker) : base(clientFactory, mapper, config, apiInvoker){

    }
                

    public   async Task GetAllAsync(CancellationToken cancellationToken)
   {

    
                
     await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
          await client.GetAllAsync(cancellationToken);

    });
                

   }


}

