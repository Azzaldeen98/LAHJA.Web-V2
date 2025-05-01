

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class RefreshAuthUseCase : ITBaseUseCase {

    private readonly IAuthRepository _repository;
    public RefreshAuthUseCase(IAuthRepository repository){
        _repository=repository;
    }

                
    public async Task<AccessTokenResponse> ExecuteAsync(RefreshRequest body, CancellationToken cancellationToken)
   {

    
         return    await _repository.RefreshAsync(body, cancellationToken);
        

   }


}
