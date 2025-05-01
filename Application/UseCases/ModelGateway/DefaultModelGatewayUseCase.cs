

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class DefaultModelGatewayUseCase : ITBaseUseCase {

    private readonly IModelGatewayRepository _repository;
    public DefaultModelGatewayUseCase(IModelGatewayRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
          await _repository.DefaultModelGatewayAsync(id, cancellationToken);
        

   }


}
