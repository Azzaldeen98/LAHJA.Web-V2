

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class UpdateProfileUseCase : ITBaseUseCase {

    private readonly IProfileRepository _repository;
    public UpdateProfileUseCase(IProfileRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(UserRequest body, CancellationToken cancellationToken)
   {

    
          await _repository.UpdateAsync(body, cancellationToken);
        

   }


}
