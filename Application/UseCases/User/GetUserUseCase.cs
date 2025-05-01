

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetUserUseCase : ITBaseUseCase {

    private readonly IUserRepository _repository;
    public GetUserUseCase(IUserRepository repository){
        _repository=repository;
    }

                
    public async Task<UserResponse> ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetUserAsync(id, cancellationToken);
        

   }


}
