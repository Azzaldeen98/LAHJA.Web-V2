

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetActiveSessionAuthorizationSessionUseCase : ITBaseUseCase {

    private readonly IAuthorizationSessionRepository _repository;
    public GetActiveSessionAuthorizationSessionUseCase(IAuthorizationSessionRepository repository){
        _repository=repository;
    }

                
    public async Task<SessionVm> ExecuteAsync(string userId, string type, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetActiveSessionAsync(userId, type, cancellationToken);
        

   }


}
