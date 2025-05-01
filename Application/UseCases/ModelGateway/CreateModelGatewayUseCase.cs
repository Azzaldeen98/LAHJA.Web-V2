

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class CreateModelGatewayUseCase : ITBaseUseCase {

    private readonly IModelGatewayRepository _repository;
    public CreateModelGatewayUseCase(IModelGatewayRepository repository){
        _repository=repository;
    }

                
    public async Task<ModelGatewayResponse> ExecuteAsync(ModelGatewayCreate body, CancellationToken cancellationToken)
   {

    
         return    await _repository.CreateModelGatewayAsync(body, cancellationToken);
        

   }


}
