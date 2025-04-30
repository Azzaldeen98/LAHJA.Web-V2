
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.AutoGenerator.Interfaces;
using Infrastructure.DataSource.ApiClient2.Base;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public interface IUserRepository :  ITBaseRepository ,  ITScope  
{
public Task<UserResponse> GetUserAsync(string id, CancellationToken cancellationToken);

public Task<UserResponse> AssignServiceAsync(AssignService body, CancellationToken cancellationToken);

public Task<UserResponse> AssignModelAiAsync(AssignModelAi body, CancellationToken cancellationToken);

public Task<UserResponse> AssignRoleAsync(RoleAssign body, CancellationToken cancellationToken);

}

