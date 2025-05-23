﻿
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Infrastructure.Share.Invoker;
using AutoMapper;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Share.Invoker;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.DataSource.ApiClient2;


 public  class CheckoutApiClient : BuildApiClient<CheckoutClient>  , ICheckoutApiClient {

  
    public CheckoutApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, 
    IApiInvoker apiInvoker) : base(clientFactory, mapper, config, apiInvoker){

    }
                

    public   async Task<CheckoutResponse> CreateCheckoutAsync(CheckoutOptions body, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.CreateCheckoutAsync(body, cancellationToken);

    });
                

   }


    public   async Task<CheckoutResponse> ManageAsync(SessionCreate body, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.ManageAsync(body, cancellationToken);

    });
                

   }


}

