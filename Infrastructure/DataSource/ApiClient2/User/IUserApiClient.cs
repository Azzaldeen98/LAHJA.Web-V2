
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

public interface IUserApiClient
 :  ITBaseApiClient  
{
public Task<UserResponse> GetUserAsync(string id, CancellationToken cancellationToken);

public Task<UserResponse> AssignServiceAsync(AssignService body, CancellationToken cancellationToken);

public Task<UserResponse> AssignModelAiAsync(AssignModelAi body, CancellationToken cancellationToken);

public Task<UserResponse> AssignRoleAsync(RoleAssign body, CancellationToken cancellationToken);

}

