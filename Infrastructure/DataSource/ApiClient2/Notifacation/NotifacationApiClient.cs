
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Infrastructure.Shared.ApiInvoker;
using AutoMapper;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Shared.ApiInvoker;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.DataSource.ApiClient2;


public class NotifacationApiClient : BuildApiClient<NotifacationClient>  , INotifacationApiClient {

  
    public NotifacationApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, 
    IApiInvoker apiInvoker) : base(clientFactory, mapper, config, apiInvoker){

    }
                

    public   async Task NotifyUserByEmailAsync(string email, string subject, string htmlMessage, CancellationToken cancellationToken)
   {

    
                
     await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
          await client.NotifyUserByEmailAsync(email, subject, htmlMessage, cancellationToken);

    });
                

   }


    public   async Task NotifyAllUsersByEmailAsync(string subject, string htmlMessage, CancellationToken cancellationToken)
   {

    
                
     await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
          await client.NotifyAllUsersByEmailAsync(subject, htmlMessage, cancellationToken);

    });
                

   }


}

