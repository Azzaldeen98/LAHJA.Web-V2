
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.AutoGenerator.Interfaces;
using Infrastructure.DataSource.ApiClient2.Base;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public interface IProductRepository :  ITBaseRepository ,  ITScope  
{
public Task<ICollection<ProductResponse>> GetProductsAsync(string startingAfter, string endingBefore, long? limit, CancellationToken cancellationToken);

public Task<ProductResponse> CreateProductAsync(ProductCreate body, CancellationToken cancellationToken);

public Task<ProductResponse> GetProductAsync(string id, CancellationToken cancellationToken);

public Task<ProductResponse> UpdateProductAsync(string id, ProductUpdate body, CancellationToken cancellationToken);

public Task<DeletedResponse> DeleteProductAsync(string id, CancellationToken cancellationToken);

public Task<ICollection<ProductResponse>> SearchAllAsync(string query, int? limit, string page, CancellationToken cancellationToken);

}

