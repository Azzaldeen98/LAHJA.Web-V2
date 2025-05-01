

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetSpacesByRamUseCase : ITBaseUseCase {

    private readonly ISpaceRepository _repository;
    public GetSpacesByRamUseCase(ISpaceRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<SpaceResponse>> ExecuteAsync(int ram, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetSpacesByRamAsync(ram, cancellationToken);
        

   }


}
