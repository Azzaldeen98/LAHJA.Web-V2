
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


public interface IDashboardApiClient :  ITBaseApiClient  
{
    public Task<ICollection<StatisticsUsedRequests>> ServiceUsageDataAsync(CancellationToken cancellationToken);

    public Task<ICollection<ServiceUsersCount>> ServiceUsersCountAsync(CancellationToken cancellationToken);

    public Task<ICollection<StatisticsUsedRequests>> ServiceUsageAndRemainingAsync(CancellationToken cancellationToken);

    public Task<StatisticsUsedRequests> UsageAndRemainingRequestsAsync(CancellationToken cancellationToken);

    public Task<ICollection<RequestData>> GetRequestsAsync(FilterBy? filterBy, System.DateTimeOffset? startDate, System.DateTimeOffset? endDate, RequestType? requestType, DateTimeFilter? groupBy, CancellationToken cancellationToken);

    public Task<ICollection<RequestData>> GetRequestsByDatetimeAsync(FilterBy? filterBy, System.DateTimeOffset? startDate, System.DateTimeOffset? endDate, RequestType? requestType, DateTimeFilter? groupBy, CancellationToken cancellationToken);

    public Task<ICollection<ServiceDataTod>> GetRequestsByStatusAsync(FilterBy? filterBy, System.DateTimeOffset? startDate, System.DateTimeOffset? endDate, RequestType? requestType, CancellationToken cancellationToken);

    public Task<ICollection<ModelAiServiceData>> ModelAiServiceRequestsAsync(CancellationToken cancellationToken);

}

