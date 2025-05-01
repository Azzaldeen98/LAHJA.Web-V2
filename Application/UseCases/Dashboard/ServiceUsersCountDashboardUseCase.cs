

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class ServiceUsersCountDashboardUseCase : ITBaseUseCase {

    private readonly IDashboardRepository _repository;
    public ServiceUsersCountDashboardUseCase(IDashboardRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<ServiceUsersCount>> ExecuteAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.ServiceUsersCountAsync(cancellationToken);
        

   }


}
