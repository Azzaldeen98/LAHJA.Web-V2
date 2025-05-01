
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public class DashboardService : IDashboardService {


            
 private readonly GetRequestsByDatetimeDashboardUseCase _getRequestsByDatetimeDashboardUseCase;
 private readonly GetRequestsByStatusDashboardUseCase _getRequestsByStatusDashboardUseCase;
 private readonly GetRequestsDashboardUseCase _getRequestsDashboardUseCase;
 private readonly ModelAiServiceRequestsDashboardUseCase _modelAiServiceRequestsDashboardUseCase;
 private readonly ServiceUsageAndRemainingDashboardUseCase _serviceUsageAndRemainingDashboardUseCase;
 private readonly ServiceUsageDataDashboardUseCase _serviceUsageDataDashboardUseCase;
 private readonly ServiceUsersCountDashboardUseCase _serviceUsersCountDashboardUseCase;
 private readonly UsageAndRemainingRequestsDashboardUseCase _usageAndRemainingRequestsDashboardUseCase;


            public DashboardService(
GetRequestsByDatetimeDashboardUseCase getRequestsByDatetimeDashboardUseCase,
GetRequestsByStatusDashboardUseCase getRequestsByStatusDashboardUseCase,
GetRequestsDashboardUseCase getRequestsDashboardUseCase,
ModelAiServiceRequestsDashboardUseCase modelAiServiceRequestsDashboardUseCase,
ServiceUsageAndRemainingDashboardUseCase serviceUsageAndRemainingDashboardUseCase,
ServiceUsageDataDashboardUseCase serviceUsageDataDashboardUseCase,
ServiceUsersCountDashboardUseCase serviceUsersCountDashboardUseCase,
UsageAndRemainingRequestsDashboardUseCase usageAndRemainingRequestsDashboardUseCase){
                
      _getRequestsByDatetimeDashboardUseCase=getRequestsByDatetimeDashboardUseCase;
      _getRequestsByStatusDashboardUseCase=getRequestsByStatusDashboardUseCase;
      _getRequestsDashboardUseCase=getRequestsDashboardUseCase;
      _modelAiServiceRequestsDashboardUseCase=modelAiServiceRequestsDashboardUseCase;
      _serviceUsageAndRemainingDashboardUseCase=serviceUsageAndRemainingDashboardUseCase;
      _serviceUsageDataDashboardUseCase=serviceUsageDataDashboardUseCase;
      _serviceUsersCountDashboardUseCase=serviceUsersCountDashboardUseCase;
      _usageAndRemainingRequestsDashboardUseCase=usageAndRemainingRequestsDashboardUseCase;


            }

                

    public async Task<ICollection<RequestData>> getRequestsByDatetimeDashboardAsync(FilterBy? filterBy, System.DateTimeOffset? startDate, System.DateTimeOffset? endDate, RequestType? requestType, DateTimeFilter? groupBy, CancellationToken cancellationToken)
   {

    

         return    await _getRequestsByDatetimeDashboardUseCase.ExecuteAsync(filterBy, startDate, endDate, requestType, groupBy, cancellationToken);
        

   }



    public async Task<ICollection<ServiceDataTod>> getRequestsByStatusDashboardAsync(FilterBy? filterBy, System.DateTimeOffset? startDate, System.DateTimeOffset? endDate, RequestType? requestType, CancellationToken cancellationToken)
   {

    

         return    await _getRequestsByStatusDashboardUseCase.ExecuteAsync(filterBy, startDate, endDate, requestType, cancellationToken);
        

   }



    public async Task<ICollection<RequestData>> getRequestsDashboardAsync(FilterBy? filterBy, System.DateTimeOffset? startDate, System.DateTimeOffset? endDate, RequestType? requestType, DateTimeFilter? groupBy, CancellationToken cancellationToken)
   {

    

         return    await _getRequestsDashboardUseCase.ExecuteAsync(filterBy, startDate, endDate, requestType, groupBy, cancellationToken);
        

   }



    public async Task<ICollection<ModelAiServiceData>> modelAiServiceRequestsDashboardAsync(CancellationToken cancellationToken)
   {

    

         return    await _modelAiServiceRequestsDashboardUseCase.ExecuteAsync(cancellationToken);
        

   }



    public async Task<ICollection<StatisticsUsedRequests>> serviceUsageAndRemainingDashboardAsync(CancellationToken cancellationToken)
   {

    

         return    await _serviceUsageAndRemainingDashboardUseCase.ExecuteAsync(cancellationToken);
        

   }



    public async Task<ICollection<StatisticsUsedRequests>> serviceUsageDataDashboardAsync(CancellationToken cancellationToken)
   {

    

         return    await _serviceUsageDataDashboardUseCase.ExecuteAsync(cancellationToken);
        

   }



    public async Task<ICollection<ServiceUsersCount>> serviceUsersCountDashboardAsync(CancellationToken cancellationToken)
   {

    

         return    await _serviceUsersCountDashboardUseCase.ExecuteAsync(cancellationToken);
        

   }



    public async Task<StatisticsUsedRequests> usageAndRemainingRequestsDashboardAsync(CancellationToken cancellationToken)
   {

    

         return    await _usageAndRemainingRequestsDashboardUseCase.ExecuteAsync(cancellationToken);
        

   }





}
