
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


 public  class ProfileApiClient : BuildApiClient<ProfileClient>  , IProfileApiClient {

  
    public ProfileApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, 
    IApiInvoker apiInvoker) : base(clientFactory, mapper, config, apiInvoker){

    }
                

    public   async Task<UserResponse> UserAsync(CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.UserAsync(cancellationToken);

    });
                

   }


    public   async Task UpdateAsync(UserRequest body, CancellationToken cancellationToken)
   {

    
                
     await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
          await client.UpdateAsync(body, cancellationToken);

    });
                

   }


    public   async Task<CustomerResponse> GetCustomerAsync(CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.GetCustomerAsync(cancellationToken);

    });
                

   }


    public   async Task<ICollection<SubscriptionResponse>> SubscriptionsAsync(CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.SubscriptionsAsync(cancellationToken);

    });
                

   }


    public   async Task<ICollection<ModelAiResponse>> ModelAisAsync(CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.ModelAisAsync(cancellationToken);

    });
                

   }


    public   async Task<ICollection<ServiceResponse>> ServicesAsync(CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.ServicesAsync(cancellationToken);

    });
                

   }


    public   async Task<ICollection<ServiceResponse>> ServicesModelAiAsync(string modelAiId, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.ServicesModelAiAsync(modelAiId, cancellationToken);

    });
                

   }


    public   async Task<ICollection<SpaceResponse>> SpacesSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.SpacesSubscriptionAsync(subscriptionId, cancellationToken);

    });
                

   }


    public   async Task<SpaceResponse> SpaceSubscriptionAsync(string subscriptionId, string spaceId, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.SpaceSubscriptionAsync(subscriptionId, spaceId, cancellationToken);

    });
                

   }


    public   async Task<ICollection<RequestResponse>> RequestsSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.RequestsSubscriptionAsync(subscriptionId, cancellationToken);

    });
                

   }


    public   async Task<ICollection<RequestResponse>> RequestsServiceAsync(string serviceId, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.RequestsServiceAsync(serviceId, cancellationToken);

    });
                

   }


}

