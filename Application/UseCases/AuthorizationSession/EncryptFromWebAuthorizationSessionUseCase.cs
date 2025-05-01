

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class EncryptFromWebAuthorizationSessionUseCase : ITBaseUseCase {

    private readonly IAuthorizationSessionRepository _repository;
    public EncryptFromWebAuthorizationSessionUseCase(IAuthorizationSessionRepository repository){
        _repository=repository;
    }

                
    public async Task<TokenVm> ExecuteAsync(EncryptTokenRequest body, CancellationToken cancellationToken)
   {

    
         return    await _repository.EncryptFromWebAsync(body, cancellationToken);
        

   }


}
