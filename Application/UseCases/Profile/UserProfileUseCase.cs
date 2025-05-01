

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class UserProfileUseCase : ITBaseUseCase {

    private readonly IProfileRepository _repository;
    public UserProfileUseCase(IProfileRepository repository){
        _repository=repository;
    }

                
    public async Task<UserResponse> ExecuteAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.UserAsync(cancellationToken);
        

   }


}
