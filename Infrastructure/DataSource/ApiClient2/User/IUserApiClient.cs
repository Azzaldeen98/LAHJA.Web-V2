
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


public interface IUserApiClient :  ITBaseApiClient  
{
    public Task<UserResponse> GetUserAsync(string id, CancellationToken cancellationToken);

    public Task<UserResponse> AssignServiceAsync(AssignService body, CancellationToken cancellationToken);

    public Task<UserResponse> AssignModelAiAsync(AssignModelAi body, CancellationToken cancellationToken);

    public Task<UserResponse> AssignRoleAsync(RoleAssign body, CancellationToken cancellationToken);

}

