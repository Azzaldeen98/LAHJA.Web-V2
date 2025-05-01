

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class AssignModelAiUserUseCase : ITBaseUseCase {

    private readonly IUserRepository _repository;
    public AssignModelAiUserUseCase(IUserRepository repository){
        _repository=repository;
    }

                
    public async Task<UserResponse> ExecuteAsync(AssignModelAi body, CancellationToken cancellationToken)
   {

    
         return    await _repository.AssignModelAiAsync(body, cancellationToken);
        

   }


}
