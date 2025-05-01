
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public interface IProductService :  ITBaseService ,  ITScope  
{

    public Task<ProductResponse> createProductAsync(ProductCreate body, CancellationToken cancellationToken);


    public Task<DeletedResponse> deleteProductAsync(string id, CancellationToken cancellationToken);


    public Task<ICollection<ProductResponse>> getProductsAsync(string startingAfter, string endingBefore, long? limit, CancellationToken cancellationToken);


    public Task<ProductResponse> getProductAsync(string id, CancellationToken cancellationToken);


    public Task<ICollection<ProductResponse>> searchAllProductAsync(string query, int? limit, string page, CancellationToken cancellationToken);


    public Task<ProductResponse> updateProductAsync(string id, ProductUpdate body, CancellationToken cancellationToken);




}

