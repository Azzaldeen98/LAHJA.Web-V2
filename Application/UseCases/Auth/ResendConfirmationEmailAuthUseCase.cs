

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class ResendConfirmationEmailAuthUseCase : ITBaseUseCase {

    private readonly IAuthRepository _repository;
    public ResendConfirmationEmailAuthUseCase(IAuthRepository repository){
        _repository=repository;
    }

                
    public async Task<string> ExecuteAsync(ResendConfirmationEmailRequest body, CancellationToken cancellationToken)
   {

    
         return    await _repository.ResendConfirmationEmailAsync(body, cancellationToken);
        

   }


}
