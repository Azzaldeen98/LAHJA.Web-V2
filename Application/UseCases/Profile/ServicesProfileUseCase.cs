

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class ServicesProfileUseCase : ITBaseUseCase {

    private readonly IProfileRepository _repository;
    public ServicesProfileUseCase(IProfileRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<ServiceResponse>> ExecuteAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.ServicesAsync(cancellationToken);
        

   }


}
