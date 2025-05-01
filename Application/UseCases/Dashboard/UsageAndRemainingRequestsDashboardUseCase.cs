

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class UsageAndRemainingRequestsDashboardUseCase : ITBaseUseCase {

    private readonly IDashboardRepository _repository;
    public UsageAndRemainingRequestsDashboardUseCase(IDashboardRepository repository){
        _repository=repository;
    }

                
    public async Task<StatisticsUsedRequests> ExecuteAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.UsageAndRemainingRequestsAsync(cancellationToken);
        

   }


}
