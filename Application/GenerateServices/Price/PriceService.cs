
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public class PriceService : IPriceService {


        
     private readonly CreatePriceUseCase _createPriceUseCase;
     private readonly GetPricesUseCase _getPricesUseCase;
     private readonly GetPriceUseCase _getPriceUseCase;
     private readonly SearchPriceUseCase _searchPriceUseCase;
     private readonly UpdatePriceUseCase _updatePriceUseCase;


    public PriceService(   
            CreatePriceUseCase createPriceUseCase,
            GetPricesUseCase getPricesUseCase,
            GetPriceUseCase getPriceUseCase,
            SearchPriceUseCase searchPriceUseCase,
            UpdatePriceUseCase updatePriceUseCase)
    {
                        
          _createPriceUseCase=createPriceUseCase;
          _getPricesUseCase=getPricesUseCase;
          _getPriceUseCase=getPriceUseCase;
          _searchPriceUseCase=searchPriceUseCase;
          _updatePriceUseCase=updatePriceUseCase;


    }

                

    public async Task<PriceResponse> createPriceAsync(PriceCreate body, CancellationToken cancellationToken)
   {

    

         return   await _createPriceUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<ICollection<PriceResponse>> getPricesAsync(string productId, bool? active, CancellationToken cancellationToken)
   {

    

         return   await _getPricesUseCase.ExecuteAsync(productId, active, cancellationToken);
        

   }



    public async Task<PriceResponse> getPriceAsync(string id, CancellationToken cancellationToken)
   {

    

         return   await _getPriceUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task searchPriceAsync(PriceSearchOptions body, CancellationToken cancellationToken)
   {

    

         await _searchPriceUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<PriceResponse> updatePriceAsync(string id, PriceUpdate body, CancellationToken cancellationToken)
   {

    

         return   await _updatePriceUseCase.ExecuteAsync(id, body, cancellationToken);
        

   }





}
