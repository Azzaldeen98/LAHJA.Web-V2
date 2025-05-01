

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class ExternalLoginAuthUseCase : ITBaseUseCase {

    private readonly IAuthRepository _repository;
    public ExternalLoginAuthUseCase(IAuthRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(string provider, string returnUrl, CancellationToken cancellationToken)
   {

    
          await _repository.ExternalLoginAsync(provider, returnUrl, cancellationToken);
        

   }


}
