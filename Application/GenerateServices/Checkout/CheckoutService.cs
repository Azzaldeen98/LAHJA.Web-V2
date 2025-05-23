
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public class CheckoutService : ICheckoutService {


        
     private readonly CreateCheckoutUseCase _createCheckoutUseCase;
     private readonly ManageCheckoutUseCase _manageCheckoutUseCase;


    public CheckoutService(   
            CreateCheckoutUseCase createCheckoutUseCase,
            ManageCheckoutUseCase manageCheckoutUseCase)
    {
                        
          _createCheckoutUseCase=createCheckoutUseCase;
          _manageCheckoutUseCase=manageCheckoutUseCase;


    }

                

    public async Task<CheckoutResponse> createCheckoutAsync(CheckoutOptions body, CancellationToken cancellationToken)
   {

    

         return   await _createCheckoutUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<CheckoutResponse> manageCheckoutAsync(SessionCreate body, CancellationToken cancellationToken)
   {

    

         return   await _manageCheckoutUseCase.ExecuteAsync(body, cancellationToken);
        

   }





}
