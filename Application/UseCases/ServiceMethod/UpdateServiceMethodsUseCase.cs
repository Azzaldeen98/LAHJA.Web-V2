

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class UpdateServiceMethodsUseCase : ITBaseUseCase {

    private readonly IServiceMethodRepository _repository;
    public UpdateServiceMethodsUseCase(IServiceMethodRepository repository){
        _repository=repository;
    }

                
    public async Task<ServiceMethodResponse> ExecuteAsync(string id, ServiceMethodUpdate body, CancellationToken cancellationToken)
   {

    
         return    await _repository.UpdateServiceMethodsAsync(id, body, cancellationToken);
        

   }


}
