
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.AutoGenerator.Interfaces;
using Infrastructure.DataSource.ApiClient2.Base;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public class NotifacationRepository : INotifacationRepository {

    private readonly INotifacationApiClient _apiClient;
    public NotifacationRepository(INotifacationApiClient apiClient){
        _apiClient=apiClient;
    }
                

    public async Task NotifyUserByEmailAsync(string email, string subject, string htmlMessage, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.NotifyUserByEmailAsync(email, subject, htmlMessage, cancellationToken);
                

   }


    public async Task NotifyAllUsersByEmailAsync(string subject, string htmlMessage, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.NotifyAllUsersByEmailAsync(subject, htmlMessage, cancellationToken);
                

   }


}

