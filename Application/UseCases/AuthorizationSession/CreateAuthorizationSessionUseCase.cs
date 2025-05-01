

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class CreateAuthorizationSessionUseCase : ITBaseUseCase {

    private readonly IAuthorizationSessionRepository _repository;
    public CreateAuthorizationSessionUseCase(IAuthorizationSessionRepository repository){
        _repository=repository;
    }

                
    public async Task<AuthorizationSessionWebResponse> ExecuteAsync(CreateAuthorizationWebRequest body, CancellationToken cancellationToken)
   {

    
         return    await _repository.CreateAuthorizationSessionAsync(body, cancellationToken);
        

   }


}
