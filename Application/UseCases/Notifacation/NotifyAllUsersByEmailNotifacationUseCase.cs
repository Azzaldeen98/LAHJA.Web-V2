

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class NotifyAllUsersByEmailNotifacationUseCase : ITBaseUseCase {

    private readonly INotifacationRepository _repository;
    public NotifyAllUsersByEmailNotifacationUseCase(INotifacationRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(string subject, string htmlMessage, CancellationToken cancellationToken)
   {

    
          await _repository.NotifyAllUsersByEmailAsync(subject, htmlMessage, cancellationToken);
        

   }


}
