

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class CreateSpaceUseCase : ITBaseUseCase {

    private readonly ISpaceRepository _repository;
    public CreateSpaceUseCase(ISpaceRepository repository){
        _repository=repository;
    }

                
    public async Task<SpaceResponse> ExecuteAsync(CreateSpaceRequest body, CancellationToken cancellationToken)
   {

    
         return    await _repository.CreateSpaceAsync(body, cancellationToken);
        

   }


}
