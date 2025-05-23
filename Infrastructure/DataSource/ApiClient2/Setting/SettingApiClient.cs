
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


 public  class SettingApiClient : BuildApiClient<SettingClient>  , ISettingApiClient {

  
    public SettingApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, 
    IApiInvoker apiInvoker) : base(clientFactory, mapper, config, apiInvoker){

    }
                

    public   async Task<ICollection<object>> SettingAllAsync(CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.SettingAllAsync(cancellationToken);

    });
                

   }


    public   async Task<ServiceResponse> SettingPOSTAsync(SettingCreate body, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.SettingPOSTAsync(body, cancellationToken);

    });
                

   }


    public   async Task<ServiceResponse> SettingGETAsync(string name, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.SettingGETAsync(name, cancellationToken);

    });
                

   }


    public   async Task SettingPUTAsync(string name, SettingUpdate body, CancellationToken cancellationToken)
   {

    
                
     await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
          await client.SettingPUTAsync(name, body, cancellationToken);

    });
                

   }


    public   async Task SettingDELETEAsync(string name, CancellationToken cancellationToken)
   {

    
                
     await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
          await client.SettingDELETEAsync(name, cancellationToken);

    });
                

   }


}

