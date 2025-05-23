
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Infrastructure.Share.Invoker;
using AutoMapper;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Share.Invoker;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.DataSource.ApiClient2;


public interface INotifacationApiClient :  ITBaseApiClient  
{
    public Task NotifyUserByEmailAsync(string email, string subject, string htmlMessage, CancellationToken cancellationToken);

    public Task NotifyAllUsersByEmailAsync(string subject, string htmlMessage, CancellationToken cancellationToken);

}

