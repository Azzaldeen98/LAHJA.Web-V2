
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public class ServiceRepository : IServiceRepository {

    private readonly IServiceApiClient _apiClient;
    public ServiceRepository(IServiceApiClient apiClient){
        _apiClient=apiClient;
    }
                

    public async Task<ICollection<ServiceResponse>> GetServicesAsync(CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetServicesAsync(cancellationToken);
                

   }


    public async Task<ServiceResponse> CreateServiceAsync(ServiceCreate body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.CreateServiceAsync(body, cancellationToken);
                

   }


    public async Task<ServiceResponse> GetServiceAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetServiceAsync(id, cancellationToken);
                

   }


    public async Task UpdateServiceAsync(string id, ServiceUpdate body, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.UpdateServiceAsync(id, body, cancellationToken);
                

   }


    public async Task<DeletedResponse> DeleteServiceAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.DeleteServiceAsync(id, cancellationToken);
                

   }


}

