
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


 public  class DashboardRepository : IDashboardRepository {

    private readonly IDashboardApiClient _apiClient;
    public DashboardRepository(IDashboardApiClient apiClient){
        _apiClient=apiClient;
    }
                

    public async Task<ICollection<StatisticsUsedRequests>> ServiceUsageDataAsync(CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.ServiceUsageDataAsync(cancellationToken);
                

   }


    public async Task<ICollection<ServiceUsersCount>> ServiceUsersCountAsync(CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.ServiceUsersCountAsync(cancellationToken);
                

   }


    public async Task<ICollection<StatisticsUsedRequests>> ServiceUsageAndRemainingAsync(CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.ServiceUsageAndRemainingAsync(cancellationToken);
                

   }


    public async Task<StatisticsUsedRequests> UsageAndRemainingRequestsAsync(CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.UsageAndRemainingRequestsAsync(cancellationToken);
                

   }


    public async Task<ICollection<RequestData>> GetRequestsAsync(FilterBy? filterBy, System.DateTimeOffset? startDate, System.DateTimeOffset? endDate, RequestType? requestType, DateTimeFilter? groupBy, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetRequestsAsync(filterBy, startDate, endDate, requestType, groupBy, cancellationToken);
                

   }


    public async Task<ICollection<RequestData>> GetRequestsByDatetimeAsync(FilterBy? filterBy, System.DateTimeOffset? startDate, System.DateTimeOffset? endDate, RequestType? requestType, DateTimeFilter? groupBy, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetRequestsByDatetimeAsync(filterBy, startDate, endDate, requestType, groupBy, cancellationToken);
                

   }


    public async Task<ICollection<ServiceDataTod>> GetRequestsByStatusAsync(FilterBy? filterBy, System.DateTimeOffset? startDate, System.DateTimeOffset? endDate, RequestType? requestType, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetRequestsByStatusAsync(filterBy, startDate, endDate, requestType, cancellationToken);
                

   }


    public async Task<ICollection<ModelAiServiceData>> ModelAiServiceRequestsAsync(CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.ModelAiServiceRequestsAsync(cancellationToken);
                

   }


}

