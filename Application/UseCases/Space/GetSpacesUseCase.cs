

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetSpacesUseCase : ITBaseUseCase {

    private readonly ISpaceRepository _repository;
    public GetSpacesUseCase(ISpaceRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<SpaceResponse>> ExecuteAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.GetSpacesAsync(cancellationToken);
        

   }


}
