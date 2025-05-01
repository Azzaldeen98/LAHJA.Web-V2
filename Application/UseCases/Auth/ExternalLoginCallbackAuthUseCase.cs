

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class ExternalLoginCallbackAuthUseCase : ITBaseUseCase {

    private readonly IAuthRepository _repository;
    public ExternalLoginCallbackAuthUseCase(IAuthRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(string returnUrl, CancellationToken cancellationToken)
   {

    
          await _repository.ExternalLoginCallbackAsync(returnUrl, cancellationToken);
        

   }


}
