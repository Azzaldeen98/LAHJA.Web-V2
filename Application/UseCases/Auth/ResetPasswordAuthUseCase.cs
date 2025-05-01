

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class ResetPasswordAuthUseCase : ITBaseUseCase {

    private readonly IAuthRepository _repository;
    public ResetPasswordAuthUseCase(IAuthRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(ResetPasswordRequest body, CancellationToken cancellationToken)
   {

    
          await _repository.ResetPasswordAsync(body, cancellationToken);
        

   }


}
