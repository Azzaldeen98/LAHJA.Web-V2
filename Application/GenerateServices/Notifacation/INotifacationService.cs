
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public interface INotifacationService :  ITBaseService ,  ITScope  
{

    public Task notifyAllUsersByEmailNotifacationAsync(string subject, string htmlMessage, CancellationToken cancellationToken);


    public Task notifyUserByEmailNotifacationAsync(string email, string subject, string htmlMessage, CancellationToken cancellationToken);




}

