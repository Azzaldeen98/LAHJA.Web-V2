
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Infrastructure.Shared.ApiInvoker;
using AutoMapper;
using Shared.AutoGenerator.Interfaces;
using Infrastructure.DataSource.ApiClient2.Base;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Shared.ApiInvoker;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.DataSource.ApiClient2;

public interface IPlansApiClient
 :  ITBaseApiClient  
{
public Task<ICollection<PlanView>> GetPlansAsync(string lg, CancellationToken cancellationToken);

public Task<PlanResponse> CreatePlanAsync(string lg, PlanCreate body, CancellationToken cancellationToken);

public Task<ICollection<PlanView>> AsGroupAsync(string langauge, CancellationToken cancellationToken);

public Task<PlanView> GetPlanAsync(string id, string lg, CancellationToken cancellationToken);

public Task<PlanResponse> UpdatePlanAsync(string id, PlanUpdate body, CancellationToken cancellationToken);

public Task<DeletedResponse> DeletePlanAsync(string id, CancellationToken cancellationToken);

}

