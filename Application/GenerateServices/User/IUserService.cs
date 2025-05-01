
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public interface IUserService :  ITBaseService ,  ITScope  
{

    public Task<UserResponse> assignModelAiUserAsync(AssignModelAi body, CancellationToken cancellationToken);


    public Task<UserResponse> assignRoleUserAsync(RoleAssign body, CancellationToken cancellationToken);


    public Task<UserResponse> assignServiceUserAsync(AssignService body, CancellationToken cancellationToken);


    public Task<UserResponse> getUserAsync(string id, CancellationToken cancellationToken);




}

