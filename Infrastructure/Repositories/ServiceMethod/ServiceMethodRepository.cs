
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public class ServiceMethodRepository : IServiceMethodRepository {

    private readonly IServiceMethodApiClient _apiClient;
    public ServiceMethodRepository(IServiceMethodApiClient apiClient){
        _apiClient=apiClient;
    }
                

    public async Task<ICollection<ServiceMethodResponse>> GetServiceMethodsAsync(CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetServiceMethodsAsync(cancellationToken);
                

   }


    public async Task<ServiceMethodResponse> CreateServiceMethodsAsync(ServiceMethodCreate body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.CreateServiceMethodsAsync(body, cancellationToken);
                

   }


    public async Task<ServiceMethodResponse> GetServiceMethodAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetServiceMethodAsync(id, cancellationToken);
                

   }


    public async Task<ServiceMethodResponse> UpdateServiceMethodsAsync(string id, ServiceMethodUpdate body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.UpdateServiceMethodsAsync(id, body, cancellationToken);
                

   }


    public async Task<DeletedResponse> DeleteServiceMethodsAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.DeleteServiceMethodsAsync(id, cancellationToken);
                

   }


}

