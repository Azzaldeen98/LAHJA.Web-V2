
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.AutoGenerator.Interfaces;
using Infrastructure.DataSource.ApiClient2.Base;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public class PriceRepository : IPriceRepository {

    private readonly IPriceApiClient _apiClient;
    public PriceRepository(IPriceApiClient apiClient){
        _apiClient=apiClient;
    }
                

    public async Task<ICollection<PriceResponse>> GetPricesAsync(string productId, bool? active, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetPricesAsync(productId, active, cancellationToken);
                

   }


    public async Task<PriceResponse> CreatePriceAsync(PriceCreate body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.CreatePriceAsync(body, cancellationToken);
                

   }


    public async Task<PriceResponse> GetPriceAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetPriceAsync(id, cancellationToken);
                

   }


    public async Task<PriceResponse> UpdatePriceAsync(string id, PriceUpdate body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.UpdatePriceAsync(id, body, cancellationToken);
                

   }


    public async Task SearchAsync(PriceSearchOptions body, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.SearchAsync(body, cancellationToken);
                

   }


}

