

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class DeleteAuthorizationSessionUseCase : ITBaseUseCase {

    private readonly IAuthorizationSessionRepository _repository;
    public DeleteAuthorizationSessionUseCase(IAuthorizationSessionRepository repository){
        _repository=repository;
    }

                
    public async Task<DeletedResponse> ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.DeleteAuthorizationSessionAsync(id, cancellationToken);
        

   }


}
