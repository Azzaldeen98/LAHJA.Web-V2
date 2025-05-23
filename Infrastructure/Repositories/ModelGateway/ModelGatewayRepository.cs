
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


 public  class ModelGatewayRepository : IModelGatewayRepository {

    private readonly IModelGatewayApiClient _apiClient;
    public ModelGatewayRepository(IModelGatewayApiClient apiClient){
        _apiClient=apiClient;
    }
                

    public async Task<ICollection<ModelGatewayResponse>> GetModelGatwaysAsync(CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetModelGatwaysAsync(cancellationToken);
                

   }


    public async Task<ModelGatewayResponse> CreateModelGatewayAsync(ModelGatewayCreate body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.CreateModelGatewayAsync(body, cancellationToken);
                

   }


    public async Task<ModelGatewayResponse> GetModelGatewayAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetModelGatewayAsync(id, cancellationToken);
                

   }


    public async Task<ModelGatewayResponse> UpdateModelGatewayAsync(string id, ModelGatewayUpdate body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.UpdateModelGatewayAsync(id, body, cancellationToken);
                

   }


    public async Task<DeletedResponse> DeleteModelGatewayAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.DeleteModelGatewayAsync(id, cancellationToken);
                

   }


    public async Task DefaultModelGatewayAsync(string id, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.DefaultModelGatewayAsync(id, cancellationToken);
                

   }


}

