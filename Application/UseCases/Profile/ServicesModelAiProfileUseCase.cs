

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class ServicesModelAiProfileUseCase : ITBaseUseCase {

    private readonly IProfileRepository _repository;
    public ServicesModelAiProfileUseCase(IProfileRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<ServiceResponse>> ExecuteAsync(string modelAiId, CancellationToken cancellationToken)
   {

    
         return    await _repository.ServicesModelAiAsync(modelAiId, cancellationToken);
        

   }


}
