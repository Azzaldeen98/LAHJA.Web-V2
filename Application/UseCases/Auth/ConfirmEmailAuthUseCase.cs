

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class ConfirmEmailAuthUseCase : ITBaseUseCase {

    private readonly IAuthRepository _repository;
    public ConfirmEmailAuthUseCase(IAuthRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(ConfirmEmailRequest body, CancellationToken cancellationToken)
   {

    
          await _repository.ConfirmEmailAsync(body, cancellationToken);
        

   }


}
