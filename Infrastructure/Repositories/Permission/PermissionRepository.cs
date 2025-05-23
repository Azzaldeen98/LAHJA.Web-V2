
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


 public  class PermissionRepository : IPermissionRepository {

    private readonly IPermissionApiClient _apiClient;
    public PermissionRepository(IPermissionApiClient apiClient){
        _apiClient=apiClient;
    }
                

    public async Task GetAllAsync(CancellationToken cancellationToken)
   {

    
                
      await _apiClient.GetAllAsync(cancellationToken);
                

   }


}

