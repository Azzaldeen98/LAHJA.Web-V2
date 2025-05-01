

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class CreateServiceMethodsUseCase : ITBaseUseCase {

    private readonly IServiceMethodRepository _repository;
    public CreateServiceMethodsUseCase(IServiceMethodRepository repository){
        _repository=repository;
    }

                
    public async Task<ServiceMethodResponse> ExecuteAsync(ServiceMethodCreate body, CancellationToken cancellationToken)
   {

    
         return    await _repository.CreateServiceMethodsAsync(body, cancellationToken);
        

   }


}
