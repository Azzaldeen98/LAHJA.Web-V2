
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public class NotifacationService : INotifacationService {


            
 private readonly NotifyAllUsersByEmailNotifacationUseCase _notifyAllUsersByEmailNotifacationUseCase;
 private readonly NotifyUserByEmailNotifacationUseCase _notifyUserByEmailNotifacationUseCase;


            public NotifacationService(
NotifyAllUsersByEmailNotifacationUseCase notifyAllUsersByEmailNotifacationUseCase,
NotifyUserByEmailNotifacationUseCase notifyUserByEmailNotifacationUseCase){
                
      _notifyAllUsersByEmailNotifacationUseCase=notifyAllUsersByEmailNotifacationUseCase;
      _notifyUserByEmailNotifacationUseCase=notifyUserByEmailNotifacationUseCase;


            }

                

    public async Task notifyAllUsersByEmailNotifacationAsync(string subject, string htmlMessage, CancellationToken cancellationToken)
   {

    

          await _notifyAllUsersByEmailNotifacationUseCase.ExecuteAsync(subject, htmlMessage, cancellationToken);
        

   }



    public async Task notifyUserByEmailNotifacationAsync(string email, string subject, string htmlMessage, CancellationToken cancellationToken)
   {

    

          await _notifyUserByEmailNotifacationUseCase.ExecuteAsync(email, subject, htmlMessage, cancellationToken);
        

   }





}
