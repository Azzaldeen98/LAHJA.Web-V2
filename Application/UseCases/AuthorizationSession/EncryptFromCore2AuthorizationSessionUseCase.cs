

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class EncryptFromCore2AuthorizationSessionUseCase : ITBaseUseCase {

    private readonly IAuthorizationSessionRepository _repository;
    public EncryptFromCore2AuthorizationSessionUseCase(IAuthorizationSessionRepository repository){
        _repository=repository;
    }

                
    public async Task<TokenVm> ExecuteAsync(string encrptedToken, string coreToken, CancellationToken cancellationToken)
   {

    
         return    await _repository.EncryptFromCore2Async(encrptedToken, coreToken, cancellationToken);
        

   }


}
