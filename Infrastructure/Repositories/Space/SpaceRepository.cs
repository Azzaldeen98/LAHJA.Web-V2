
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


 public  class SpaceRepository : ISpaceRepository {

    private readonly ISpaceApiClient _apiClient;
    public SpaceRepository(ISpaceApiClient apiClient){
        _apiClient=apiClient;
    }
                

    public async Task<ICollection<SpaceResponse>> GetSpacesAsync(CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetSpacesAsync(cancellationToken);
                

   }


    public async Task<SpaceResponse> CreateSpaceAsync(CreateSpaceRequest body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.CreateSpaceAsync(body, cancellationToken);
                

   }


    public async Task<SpaceResponse> GetSpaceAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetSpaceAsync(id, cancellationToken);
                

   }


    public async Task<SpaceResponse> UpdateSpaceAsync(string id, UpdateSpaceRequest body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.UpdateSpaceAsync(id, body, cancellationToken);
                

   }


    public async Task<DeletedResponse> DeleteSpaceAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.DeleteSpaceAsync(id, cancellationToken);
                

   }


    public async Task<SpaceResponse> GetByTokenAsync(string token, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetByTokenAsync(token, cancellationToken);
                

   }


    public async Task<ICollection<SpaceResponse>> GetBySubscriptionIdAsync(string subscriptionId, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetBySubscriptionIdAsync(subscriptionId, cancellationToken);
                

   }


    public async Task<ICollection<SpaceResponse>> GetSpacesByRamAsync(int ram, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetSpacesByRamAsync(ram, cancellationToken);
                

   }


}

