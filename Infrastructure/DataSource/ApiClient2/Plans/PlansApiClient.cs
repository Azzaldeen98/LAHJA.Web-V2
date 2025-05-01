
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Infrastructure.Shared.ApiInvoker;
using AutoMapper;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Shared.ApiInvoker;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.DataSource.ApiClient2;


public class PlansApiClient : BuildApiClient<PlansClient>  , IPlansApiClient {

  
    public PlansApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, 
    IApiInvoker apiInvoker) : base(clientFactory, mapper, config, apiInvoker){

    }
                

    public   async Task<ICollection<PlanView>> GetPlansAsync(string lg, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.GetPlansAsync(lg, cancellationToken);

    });
                

   }


    public   async Task<PlanResponse> CreatePlanAsync(string lg, PlanCreate body, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.CreatePlanAsync(lg, body, cancellationToken);

    });
                

   }


    public   async Task<ICollection<PlanView>> AsGroupAsync(string langauge, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.AsGroupAsync(langauge, cancellationToken);

    });
                

   }


    public   async Task<PlanView> GetPlanAsync(string id, string lg, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.GetPlanAsync(id, lg, cancellationToken);

    });
                

   }


    public   async Task<PlanResponse> UpdatePlanAsync(string id, PlanUpdate body, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.UpdatePlanAsync(id, body, cancellationToken);

    });
                

   }


    public   async Task<DeletedResponse> DeletePlanAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return   await apiInvoker.InvokeAsync(async () =>
    {
        var client = await GetApiClient();
         return    await client.DeletePlanAsync(id, cancellationToken);

    });
                

   }


}

