
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public interface IRolesService :  ITBaseService ,  ITScope  
{

    public Task assignPermissionRolesAsync(RolePermitionAssign body, CancellationToken cancellationToken);


    public Task<ICollection<object>> rolesAllAsync(CancellationToken cancellationToken);


    public Task rolesDELETEAsync(string id, CancellationToken cancellationToken);


    public Task<RoleResponse> rolesGETAsync(string id, CancellationToken cancellationToken);


    public Task rolesPOSTAsync(RoleCreate body, CancellationToken cancellationToken);




}

