

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class AllowedRequestUseCase : ITBaseUseCase {

    private readonly IRequestRepository _repository;
    public AllowedRequestUseCase(IRequestRepository repository){
        _repository=repository;
    }

                
    public async Task<RequestAllowed> ExecuteAsync(string serviceId, CancellationToken cancellationToken)
   {

    
         return    await _repository.AllowedAsync(serviceId, cancellationToken);
        

   }


}
