
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.AutoGenerator.Interfaces;
using Infrastructure.DataSource.ApiClient2.Base;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public interface INotifacationRepository :  ITBaseRepository ,  ITScope  
{
public Task NotifyUserByEmailAsync(string email, string subject, string htmlMessage, CancellationToken cancellationToken);

public Task NotifyAllUsersByEmailAsync(string subject, string htmlMessage, CancellationToken cancellationToken);

}

