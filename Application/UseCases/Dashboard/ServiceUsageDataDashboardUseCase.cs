

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class ServiceUsageDataDashboardUseCase : ITBaseUseCase {

    private readonly IDashboardRepository _repository;
    public ServiceUsageDataDashboardUseCase(IDashboardRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<StatisticsUsedRequests>> ExecuteAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.ServiceUsageDataAsync(cancellationToken);
        

   }


}
