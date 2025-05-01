
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public class SettingRepository : ISettingRepository {

    private readonly ISettingApiClient _apiClient;
    public SettingRepository(ISettingApiClient apiClient){
        _apiClient=apiClient;
    }
                

    public async Task<ICollection<object>> SettingAllAsync(CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.SettingAllAsync(cancellationToken);
                

   }


    public async Task<ServiceResponse> SettingPOSTAsync(SettingCreate body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.SettingPOSTAsync(body, cancellationToken);
                

   }


    public async Task<ServiceResponse> SettingGETAsync(string name, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.SettingGETAsync(name, cancellationToken);
                

   }


    public async Task SettingPUTAsync(string name, SettingUpdate body, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.SettingPUTAsync(name, body, cancellationToken);
                

   }


    public async Task SettingDELETEAsync(string name, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.SettingDELETEAsync(name, cancellationToken);
                

   }


}

