
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


 public  class ServiceMethodApiClient : BuildApiClient<ServiceMethodClient>  , IServiceMethodApiClient {

  
    public ServiceMethodApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, 
    IApiInvoker apiInvoker) : base(clientFactory, mapper, config, apiInvoker){

    }
                

    public   async Task<ICollection<ServiceMethodResponse>> GetServiceMethodsAsync(CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.GetServiceMethodsAsync(cancellationToken);

    });
                

   }


    public   async Task<ServiceMethodResponse> CreateServiceMethodsAsync(ServiceMethodCreate body, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.CreateServiceMethodsAsync(body, cancellationToken);

    });
                

   }


    public   async Task<ServiceMethodResponse> GetServiceMethodAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.GetServiceMethodAsync(id, cancellationToken);

    });
                

   }


    public   async Task<ServiceMethodResponse> UpdateServiceMethodsAsync(string id, ServiceMethodUpdate body, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.UpdateServiceMethodsAsync(id, body, cancellationToken);

    });
                

   }


    public   async Task<DeletedResponse> DeleteServiceMethodsAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.DeleteServiceMethodsAsync(id, cancellationToken);

    });
                

   }


}

