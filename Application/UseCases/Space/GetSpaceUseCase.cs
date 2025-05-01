

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetSpaceUseCase : ITBaseUseCase {

    private readonly ISpaceRepository _repository;
    public GetSpaceUseCase(ISpaceRepository repository){
        _repository=repository;
    }

                
    public async Task<SpaceResponse> ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetSpaceAsync(id, cancellationToken);
        

   }


}
