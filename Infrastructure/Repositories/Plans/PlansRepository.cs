
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public class PlansRepository : IPlansRepository {

    private readonly IPlansApiClient _apiClient;
    public PlansRepository(IPlansApiClient apiClient){
        _apiClient=apiClient;
    }
                

    public async Task<ICollection<PlanView>> GetPlansAsync(string lg, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetPlansAsync(lg, cancellationToken);
                

   }


    public async Task<PlanResponse> CreatePlanAsync(string lg, PlanCreate body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.CreatePlanAsync(lg, body, cancellationToken);
                

   }


    public async Task<ICollection<PlanView>> AsGroupAsync(string langauge, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.AsGroupAsync(langauge, cancellationToken);
                

   }


    public async Task<PlanView> GetPlanAsync(string id, string lg, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetPlanAsync(id, lg, cancellationToken);
                

   }


    public async Task<PlanResponse> UpdatePlanAsync(string id, PlanUpdate body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.UpdatePlanAsync(id, body, cancellationToken);
                

   }


    public async Task<DeletedResponse> DeletePlanAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.DeletePlanAsync(id, cancellationToken);
                

   }


}

