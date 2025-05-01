

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class EncryptFromCoreAuthorizationSessionUseCase : ITBaseUseCase {

    private readonly IAuthorizationSessionRepository _repository;
    public EncryptFromCoreAuthorizationSessionUseCase(IAuthorizationSessionRepository repository){
        _repository=repository;
    }

                
    public async Task<TokenVm> ExecuteAsync(string sesstionToken, CancellationToken cancellationToken)
   {

    
         return    await _repository.EncryptFromCoreAsync(sesstionToken, cancellationToken);
        

   }


}
