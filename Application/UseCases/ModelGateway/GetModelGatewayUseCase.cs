

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetModelGatewayUseCase : ITBaseUseCase {

    private readonly IModelGatewayRepository _repository;
    public GetModelGatewayUseCase(IModelGatewayRepository repository){
        _repository=repository;
    }

                
    public async Task<ModelGatewayResponse> ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetModelGatewayAsync(id, cancellationToken);
        

   }


}
