

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetModelGatwaysModelGatewayUseCase : ITBaseUseCase {

    private readonly IModelGatewayRepository _repository;
    public GetModelGatwaysModelGatewayUseCase(IModelGatewayRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<ModelGatewayResponse>> ExecuteAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.GetModelGatwaysAsync(cancellationToken);
        

   }


}
