

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetSessionsAuthorizationSessionUseCase : ITBaseUseCase {

    private readonly IAuthorizationSessionRepository _repository;
    public GetSessionsAuthorizationSessionUseCase(IAuthorizationSessionRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<SessionVm>> ExecuteAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.GetSessionsAsync(cancellationToken);
        

   }


}
