
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public class ProductRepository : IProductRepository {

    private readonly IProductApiClient _apiClient;
    public ProductRepository(IProductApiClient apiClient){
        _apiClient=apiClient;
    }
                

    public async Task<ICollection<ProductResponse>> GetProductsAsync(string startingAfter, string endingBefore, long? limit, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetProductsAsync(startingAfter, endingBefore, limit, cancellationToken);
                

   }


    public async Task<ProductResponse> CreateProductAsync(ProductCreate body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.CreateProductAsync(body, cancellationToken);
                

   }


    public async Task<ProductResponse> GetProductAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetProductAsync(id, cancellationToken);
                

   }


    public async Task<ProductResponse> UpdateProductAsync(string id, ProductUpdate body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.UpdateProductAsync(id, body, cancellationToken);
                

   }


    public async Task<DeletedResponse> DeleteProductAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.DeleteProductAsync(id, cancellationToken);
                

   }


    public async Task<ICollection<ProductResponse>> SearchAllAsync(string query, int? limit, string page, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.SearchAllAsync(query, limit, page, cancellationToken);
                

   }


}

