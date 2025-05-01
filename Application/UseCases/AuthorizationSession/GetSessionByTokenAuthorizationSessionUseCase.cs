

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetSessionByTokenAuthorizationSessionUseCase : ITBaseUseCase {

    private readonly IAuthorizationSessionRepository _repository;
    public GetSessionByTokenAuthorizationSessionUseCase(IAuthorizationSessionRepository repository){
        _repository=repository;
    }

                
    public async Task<SessionVm> ExecuteAsync(string token, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetSessionByTokenAsync(token, cancellationToken);
        

   }


}
