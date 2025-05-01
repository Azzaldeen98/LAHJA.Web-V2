

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class RegisterAuthUseCase : ITBaseUseCase {

    private readonly IAuthRepository _repository;
    public RegisterAuthUseCase(IAuthRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(RegisterRequest body, CancellationToken cancellationToken)
   {

    
          await _repository.RegisterAsync(body, cancellationToken);
        

   }


}
