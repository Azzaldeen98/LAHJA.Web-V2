
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


public class RequestApiClient : BuildApiClient<RequestClient>  , IRequestApiClient {

  
    public RequestApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, 
    IApiInvoker apiInvoker) : base(clientFactory, mapper, config, apiInvoker){

    }
                

    public   async Task<ICollection<RequestResponse>> GetRequests2Async(CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.GetRequests2Async(cancellationToken);

    });
                

   }


    public   async Task<ServiceDataTod> CreateRequestAsync(RequestCreate body, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.CreateRequestAsync(body, cancellationToken);

    });
                

   }


    public   async Task<RequestResponse> GetRequestAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.GetRequestAsync(id, cancellationToken);

    });
                

   }


    public   async Task<DeletedResponse> DeleteRequestAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.DeleteRequestAsync(id, cancellationToken);

    });
                

   }


    public   async Task<EventRequestResponse> CreateEventAsync(EventRequestRequest body, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.CreateEventAsync(body, cancellationToken);

    });
                

   }


    public   async Task<RequestAllowed> AllowedAsync(string serviceId, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.AllowedAsync(serviceId, cancellationToken);

    });
                

   }


}

