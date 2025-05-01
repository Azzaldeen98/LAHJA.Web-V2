
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public interface IPlansService :  ITBaseService ,  ITScope  
{

    public Task<ICollection<PlanView>> asGroupPlansAsync(string langauge, CancellationToken cancellationToken);


    public Task<PlanResponse> createPlanAsync(string lg, PlanCreate body, CancellationToken cancellationToken);


    public Task<DeletedResponse> deletePlanAsync(string id, CancellationToken cancellationToken);


    public Task<ICollection<PlanView>> getPlansAsync(string lg, CancellationToken cancellationToken);


    public Task<PlanView> getPlanAsync(string id, string lg, CancellationToken cancellationToken);


    public Task<PlanResponse> updatePlanAsync(string id, PlanUpdate body, CancellationToken cancellationToken);




}

