

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class ForgotPasswordAuthUseCase : ITBaseUseCase {

    private readonly IAuthRepository _repository;
    public ForgotPasswordAuthUseCase(IAuthRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(ForgotPasswordRequest body, CancellationToken cancellationToken)
   {

    
          await _repository.ForgotPasswordAsync(body, cancellationToken);
        

   }


}
