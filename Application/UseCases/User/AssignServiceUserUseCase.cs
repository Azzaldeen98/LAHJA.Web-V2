

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class AssignServiceUserUseCase : ITBaseUseCase {

    private readonly IUserRepository _repository;
    public AssignServiceUserUseCase(IUserRepository repository){
        _repository=repository;
    }

                
    public async Task<UserResponse> ExecuteAsync(AssignService body, CancellationToken cancellationToken)
   {

    
         return    await _repository.AssignServiceAsync(body, cancellationToken);
        

   }


}
