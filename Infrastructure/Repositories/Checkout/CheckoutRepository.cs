
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


 public  class CheckoutRepository : ICheckoutRepository {

    private readonly ICheckoutApiClient _apiClient;
    public CheckoutRepository(ICheckoutApiClient apiClient){
        _apiClient=apiClient;
    }
                

    public async Task<CheckoutResponse> CreateCheckoutAsync(CheckoutOptions body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.CreateCheckoutAsync(body, cancellationToken);
                

   }


    public async Task<CheckoutResponse> ManageAsync(SessionCreate body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.ManageAsync(body, cancellationToken);
                

   }


}

