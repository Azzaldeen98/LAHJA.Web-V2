

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetRequestsByStatusDashboardUseCase : ITBaseUseCase {

    private readonly IDashboardRepository _repository;
    public GetRequestsByStatusDashboardUseCase(IDashboardRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<ServiceDataTod>> ExecuteAsync(FilterBy? filterBy, System.DateTimeOffset? startDate, System.DateTimeOffset? endDate, RequestType? requestType, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetRequestsByStatusAsync(filterBy, startDate, endDate, requestType, cancellationToken);
        

   }


}
