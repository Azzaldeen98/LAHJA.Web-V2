

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class DeleteModelGatewayUseCase : ITBaseUseCase {

    private readonly IModelGatewayRepository _repository;
    public DeleteModelGatewayUseCase(IModelGatewayRepository repository){
        _repository=repository;
    }

                
    public async Task<DeletedResponse> ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.DeleteModelGatewayAsync(id, cancellationToken);
        

   }


}
