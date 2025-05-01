

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class ResumeAuthorizationSessionUseCase : ITBaseUseCase {

    private readonly IAuthorizationSessionRepository _repository;
    public ResumeAuthorizationSessionUseCase(IAuthorizationSessionRepository repository){
        _repository=repository;
    }

                
    public async Task<DeletedResponse> ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.ResumeAuthorizationSessionAsync(id, cancellationToken);
        

   }


}
