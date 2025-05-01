
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public interface IDashboardService :  ITBaseService ,  ITScope  
{

    public Task<ICollection<RequestData>> getRequestsByDatetimeDashboardAsync(FilterBy? filterBy, System.DateTimeOffset? startDate, System.DateTimeOffset? endDate, RequestType? requestType, DateTimeFilter? groupBy, CancellationToken cancellationToken);


    public Task<ICollection<ServiceDataTod>> getRequestsByStatusDashboardAsync(FilterBy? filterBy, System.DateTimeOffset? startDate, System.DateTimeOffset? endDate, RequestType? requestType, CancellationToken cancellationToken);


    public Task<ICollection<RequestData>> getRequestsDashboardAsync(FilterBy? filterBy, System.DateTimeOffset? startDate, System.DateTimeOffset? endDate, RequestType? requestType, DateTimeFilter? groupBy, CancellationToken cancellationToken);


    public Task<ICollection<ModelAiServiceData>> modelAiServiceRequestsDashboardAsync(CancellationToken cancellationToken);


    public Task<ICollection<StatisticsUsedRequests>> serviceUsageAndRemainingDashboardAsync(CancellationToken cancellationToken);


    public Task<ICollection<StatisticsUsedRequests>> serviceUsageDataDashboardAsync(CancellationToken cancellationToken);


    public Task<ICollection<ServiceUsersCount>> serviceUsersCountDashboardAsync(CancellationToken cancellationToken);


    public Task<StatisticsUsedRequests> usageAndRemainingRequestsDashboardAsync(CancellationToken cancellationToken);




}

