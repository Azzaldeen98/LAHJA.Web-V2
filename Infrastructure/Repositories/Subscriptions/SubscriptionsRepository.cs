
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public class SubscriptionsRepository : ISubscriptionsRepository {

    private readonly ISubscriptionsApiClient _apiClient;
    public SubscriptionsRepository(ISubscriptionsApiClient apiClient){
        _apiClient=apiClient;
    }
                

    public async Task<ICollection<SubscriptionResponse>> GetSubscriptionsAsync(CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetSubscriptionsAsync(cancellationToken);
                

   }


    public async Task<SubscriptionCreateResponse> CreateSubscriptionAsync(SubscriptionCreateRequest body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.CreateSubscriptionAsync(body, cancellationToken);
                

   }


    public async Task<SubscriptionResponse> GetSubscriptionAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetSubscriptionAsync(id, cancellationToken);
                

   }


    public async Task PauseCollectionAsync(string id, SubscriptionUpdateRequest body, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.PauseCollectionAsync(id, body, cancellationToken);
                

   }


    public async Task ResumeCollectionAsync(string id, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.ResumeCollectionAsync(id, cancellationToken);
                

   }


    public async Task CancelSubscriptionAsync(string id, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.CancelSubscriptionAsync(id, cancellationToken);
                

   }


    public async Task CancelAtEndAsync(string id, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.CancelAtEndAsync(id, cancellationToken);
                

   }


    public async Task RenewAsync(string id, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.RenewAsync(id, cancellationToken);
                

   }


    public async Task ResumeAsync(string id, SubscriptionResumeRequest body, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.ResumeAsync(id, body, cancellationToken);
                

   }


    public async Task ResetRequestsAsync(string id, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.ResetRequestsAsync(id, cancellationToken);
                

   }


    public async Task ResetSpacesAsync(string id, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.ResetSpacesAsync(id, cancellationToken);
                

   }


}

