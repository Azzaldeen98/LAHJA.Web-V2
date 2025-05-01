

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetServiceMethodUseCase : ITBaseUseCase {

    private readonly IServiceMethodRepository _repository;
    public GetServiceMethodUseCase(IServiceMethodRepository repository){
        _repository=repository;
    }

                
    public async Task<ServiceMethodResponse> ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetServiceMethodAsync(id, cancellationToken);
        

   }


}
