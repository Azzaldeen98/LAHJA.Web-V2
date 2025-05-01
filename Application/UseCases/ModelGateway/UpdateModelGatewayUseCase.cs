

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class UpdateModelGatewayUseCase : ITBaseUseCase {

    private readonly IModelGatewayRepository _repository;
    public UpdateModelGatewayUseCase(IModelGatewayRepository repository){
        _repository=repository;
    }

                
    public async Task<ModelGatewayResponse> ExecuteAsync(string id, ModelGatewayUpdate body, CancellationToken cancellationToken)
   {

    
         return    await _repository.UpdateModelGatewayAsync(id, body, cancellationToken);
        

   }


}
