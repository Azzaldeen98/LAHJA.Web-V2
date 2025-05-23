
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public class ProductService : IProductService {


        
     private readonly CreateProductUseCase _createProductUseCase;
     private readonly DeleteProductUseCase _deleteProductUseCase;
     private readonly GetProductsUseCase _getProductsUseCase;
     private readonly GetProductUseCase _getProductUseCase;
     private readonly SearchAllProductUseCase _searchAllProductUseCase;
     private readonly UpdateProductUseCase _updateProductUseCase;


    public ProductService(   
            CreateProductUseCase createProductUseCase,
            DeleteProductUseCase deleteProductUseCase,
            GetProductsUseCase getProductsUseCase,
            GetProductUseCase getProductUseCase,
            SearchAllProductUseCase searchAllProductUseCase,
            UpdateProductUseCase updateProductUseCase)
    {
                        
          _createProductUseCase=createProductUseCase;
          _deleteProductUseCase=deleteProductUseCase;
          _getProductsUseCase=getProductsUseCase;
          _getProductUseCase=getProductUseCase;
          _searchAllProductUseCase=searchAllProductUseCase;
          _updateProductUseCase=updateProductUseCase;


    }

                

    public async Task<ProductResponse> createProductAsync(ProductCreate body, CancellationToken cancellationToken)
   {

    

         return   await _createProductUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<DeletedResponse> deleteProductAsync(string id, CancellationToken cancellationToken)
   {

    

         return   await _deleteProductUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task<ICollection<ProductResponse>> getProductsAsync(string startingAfter, string endingBefore, long? limit, CancellationToken cancellationToken)
   {

    

         return   await _getProductsUseCase.ExecuteAsync(startingAfter, endingBefore, limit, cancellationToken);
        

   }



    public async Task<ProductResponse> getProductAsync(string id, CancellationToken cancellationToken)
   {

    

         return   await _getProductUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task<ICollection<ProductResponse>> searchAllProductAsync(string query, int? limit, string page, CancellationToken cancellationToken)
   {

    

         return   await _searchAllProductUseCase.ExecuteAsync(query, limit, page, cancellationToken);
        

   }



    public async Task<ProductResponse> updateProductAsync(string id, ProductUpdate body, CancellationToken cancellationToken)
   {

    

         return   await _updateProductUseCase.ExecuteAsync(id, body, cancellationToken);
        

   }





}
