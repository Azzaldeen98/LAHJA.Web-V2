

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class CreateServiceUseCase : ITBaseUseCase {

    private readonly IServiceRepository _repository;
    public CreateServiceUseCase(IServiceRepository repository){
        _repository=repository;
    }

                
    public async Task<ServiceResponse> ExecuteAsync(ServiceCreate body, CancellationToken cancellationToken)
   {

    
         return    await _repository.CreateServiceAsync(body, cancellationToken);
        

   }


}
