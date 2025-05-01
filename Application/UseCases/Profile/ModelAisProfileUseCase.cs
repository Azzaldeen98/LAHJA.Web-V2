

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class ModelAisProfileUseCase : ITBaseUseCase {

    private readonly IProfileRepository _repository;
    public ModelAisProfileUseCase(IProfileRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<ModelAiResponse>> ExecuteAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.ModelAisAsync(cancellationToken);
        

   }


}
