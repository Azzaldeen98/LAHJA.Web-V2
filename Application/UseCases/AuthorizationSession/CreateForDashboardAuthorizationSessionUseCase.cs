

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class CreateForDashboardAuthorizationSessionUseCase : ITBaseUseCase {

    private readonly IAuthorizationSessionRepository _repository;
    public CreateForDashboardAuthorizationSessionUseCase(IAuthorizationSessionRepository repository){
        _repository=repository;
    }

                
    public async Task<AuthorizationSessionWebResponse> ExecuteAsync(CreateAuthorizationForDashboard body, CancellationToken cancellationToken)
   {

    
         return    await _repository.CreateForDashboardAsync(body, cancellationToken);
        

   }


}
