
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


public class DashboardApiClient : BuildApiClient<DashboardClient>  , IDashboardApiClient {

  
    public DashboardApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, 
    IApiInvoker apiInvoker) : base(clientFactory, mapper, config, apiInvoker){

    }
                

    public   async Task<ICollection<StatisticsUsedRequests>> ServiceUsageDataAsync(CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.ServiceUsageDataAsync(cancellationToken);

    });
                

   }


    public   async Task<ICollection<ServiceUsersCount>> ServiceUsersCountAsync(CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.ServiceUsersCountAsync(cancellationToken);

    });
                

   }


    public   async Task<ICollection<StatisticsUsedRequests>> ServiceUsageAndRemainingAsync(CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.ServiceUsageAndRemainingAsync(cancellationToken);

    });
                

   }


    public   async Task<StatisticsUsedRequests> UsageAndRemainingRequestsAsync(CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.UsageAndRemainingRequestsAsync(cancellationToken);

    });
                

   }


    public   async Task<ICollection<RequestData>> GetRequestsAsync(FilterBy? filterBy, System.DateTimeOffset? startDate, System.DateTimeOffset? endDate, RequestType? requestType, DateTimeFilter? groupBy, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.GetRequestsAsync(filterBy, startDate, endDate, requestType, groupBy, cancellationToken);

    });
                

   }


    public   async Task<ICollection<RequestData>> GetRequestsByDatetimeAsync(FilterBy? filterBy, System.DateTimeOffset? startDate, System.DateTimeOffset? endDate, RequestType? requestType, DateTimeFilter? groupBy, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.GetRequestsByDatetimeAsync(filterBy, startDate, endDate, requestType, groupBy, cancellationToken);

    });
                

   }


    public   async Task<ICollection<ServiceDataTod>> GetRequestsByStatusAsync(FilterBy? filterBy, System.DateTimeOffset? startDate, System.DateTimeOffset? endDate, RequestType? requestType, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.GetRequestsByStatusAsync(filterBy, startDate, endDate, requestType, cancellationToken);

    });
                

   }


    public   async Task<ICollection<ModelAiServiceData>> ModelAiServiceRequestsAsync(CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.ModelAiServiceRequestsAsync(cancellationToken);

    });
                

   }


}

