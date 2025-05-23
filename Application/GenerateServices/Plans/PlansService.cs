
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public class PlansService : IPlansService {


        
     private readonly AsGroupPlansUseCase _asGroupPlansUseCase;
     private readonly CreatePlanUseCase _createPlanUseCase;
     private readonly DeletePlanUseCase _deletePlanUseCase;
     private readonly GetPlansUseCase _getPlansUseCase;
     private readonly GetPlanUseCase _getPlanUseCase;
     private readonly UpdatePlanUseCase _updatePlanUseCase;


    public PlansService(   
            AsGroupPlansUseCase asGroupPlansUseCase,
            CreatePlanUseCase createPlanUseCase,
            DeletePlanUseCase deletePlanUseCase,
            GetPlansUseCase getPlansUseCase,
            GetPlanUseCase getPlanUseCase,
            UpdatePlanUseCase updatePlanUseCase)
    {
                        
          _asGroupPlansUseCase=asGroupPlansUseCase;
          _createPlanUseCase=createPlanUseCase;
          _deletePlanUseCase=deletePlanUseCase;
          _getPlansUseCase=getPlansUseCase;
          _getPlanUseCase=getPlanUseCase;
          _updatePlanUseCase=updatePlanUseCase;


    }

                

    public async Task<ICollection<PlanView>> asGroupPlansAsync(string langauge, CancellationToken cancellationToken)
   {

    

         return   await _asGroupPlansUseCase.ExecuteAsync(langauge, cancellationToken);
        

   }



    public async Task<PlanResponse> createPlanAsync(string lg, PlanCreate body, CancellationToken cancellationToken)
   {

    

         return   await _createPlanUseCase.ExecuteAsync(lg, body, cancellationToken);
        

   }



    public async Task<DeletedResponse> deletePlanAsync(string id, CancellationToken cancellationToken)
   {

    

         return   await _deletePlanUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task<ICollection<PlanView>> getPlansAsync(string lg, CancellationToken cancellationToken)
   {

    

         return   await _getPlansUseCase.ExecuteAsync(lg, cancellationToken);
        

   }



    public async Task<PlanView> getPlanAsync(string id, string lg, CancellationToken cancellationToken)
   {

    

         return   await _getPlanUseCase.ExecuteAsync(id, lg, cancellationToken);
        

   }



    public async Task<PlanResponse> updatePlanAsync(string id, PlanUpdate body, CancellationToken cancellationToken)
   {

    

         return   await _updatePlanUseCase.ExecuteAsync(id, body, cancellationToken);
        

   }





}
