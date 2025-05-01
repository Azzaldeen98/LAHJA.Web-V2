

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class UpdateSpaceUseCase : ITBaseUseCase {

    private readonly ISpaceRepository _repository;
    public UpdateSpaceUseCase(ISpaceRepository repository){
        _repository=repository;
    }

                
    public async Task<SpaceResponse> ExecuteAsync(string id, UpdateSpaceRequest body, CancellationToken cancellationToken)
   {

    
         return    await _repository.UpdateSpaceAsync(id, body, cancellationToken);
        

   }


}
