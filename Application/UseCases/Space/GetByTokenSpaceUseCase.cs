

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetByTokenSpaceUseCase : ITBaseUseCase {

    private readonly ISpaceRepository _repository;
    public GetByTokenSpaceUseCase(ISpaceRepository repository){
        _repository=repository;
    }

                
    public async Task<SpaceResponse> ExecuteAsync(string token, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetByTokenAsync(token, cancellationToken);
        

   }


}
