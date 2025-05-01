
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public class ProfileRepository : IProfileRepository {

    private readonly IProfileApiClient _apiClient;
    public ProfileRepository(IProfileApiClient apiClient){
        _apiClient=apiClient;
    }
                

    public async Task<UserResponse> UserAsync(CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.UserAsync(cancellationToken);
                

   }


    public async Task UpdateAsync(UserRequest body, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.UpdateAsync(body, cancellationToken);
                

   }


    public async Task<CustomerResponse> GetCustomerAsync(CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetCustomerAsync(cancellationToken);
                

   }


    public async Task<ICollection<SubscriptionResponse>> SubscriptionsAsync(CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.SubscriptionsAsync(cancellationToken);
                

   }


    public async Task<ICollection<ModelAiResponse>> ModelAisAsync(CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.ModelAisAsync(cancellationToken);
                

   }


    public async Task<ICollection<ServiceResponse>> ServicesAsync(CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.ServicesAsync(cancellationToken);
                

   }


    public async Task<ICollection<ServiceResponse>> ServicesModelAiAsync(string modelAiId, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.ServicesModelAiAsync(modelAiId, cancellationToken);
                

   }


    public async Task<ICollection<SpaceResponse>> SpacesSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.SpacesSubscriptionAsync(subscriptionId, cancellationToken);
                

   }


    public async Task<SpaceResponse> SpaceSubscriptionAsync(string subscriptionId, string spaceId, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.SpaceSubscriptionAsync(subscriptionId, spaceId, cancellationToken);
                

   }


    public async Task<ICollection<RequestResponse>> RequestsSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.RequestsSubscriptionAsync(subscriptionId, cancellationToken);
                

   }


    public async Task<ICollection<RequestResponse>> RequestsServiceAsync(string serviceId, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.RequestsServiceAsync(serviceId, cancellationToken);
                

   }


}

