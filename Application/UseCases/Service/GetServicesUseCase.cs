

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetServicesUseCase : ITBaseUseCase {

    private readonly IServiceRepository _repository;
    public GetServicesUseCase(IServiceRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<ServiceResponse>> ExecuteAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.GetServicesAsync(cancellationToken);
        

   }


}
