

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class NotifyUserByEmailNotifacationUseCase : ITBaseUseCase {

    private readonly INotifacationRepository _repository;
    public NotifyUserByEmailNotifacationUseCase(INotifacationRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(string email, string subject, string htmlMessage, CancellationToken cancellationToken)
   {

    
          await _repository.NotifyUserByEmailAsync(email, subject, htmlMessage, cancellationToken);
        

   }


}
