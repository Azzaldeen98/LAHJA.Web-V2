
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.AutoGenerator.Interfaces;
using Infrastructure.DataSource.ApiClient2.Base;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public interface IPlansRepository :  ITBaseRepository ,  ITScope  
{
public Task<ICollection<PlanView>> GetPlansAsync(string lg, CancellationToken cancellationToken);

public Task<PlanResponse> CreatePlanAsync(string lg, PlanCreate body, CancellationToken cancellationToken);

public Task<ICollection<PlanView>> AsGroupAsync(string langauge, CancellationToken cancellationToken);

public Task<PlanView> GetPlanAsync(string id, string lg, CancellationToken cancellationToken);

public Task<PlanResponse> UpdatePlanAsync(string id, PlanUpdate body, CancellationToken cancellationToken);

public Task<DeletedResponse> DeletePlanAsync(string id, CancellationToken cancellationToken);

}

