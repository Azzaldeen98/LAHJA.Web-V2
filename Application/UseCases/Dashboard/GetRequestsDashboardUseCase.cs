

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetRequestsDashboardUseCase : ITBaseUseCase {

    private readonly IDashboardRepository _repository;
    public GetRequestsDashboardUseCase(IDashboardRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<RequestData>> ExecuteAsync(FilterBy? filterBy, System.DateTimeOffset? startDate, System.DateTimeOffset? endDate, RequestType? requestType, DateTimeFilter? groupBy, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetRequestsAsync(filterBy, startDate, endDate, requestType, groupBy, cancellationToken);
        

   }


}
