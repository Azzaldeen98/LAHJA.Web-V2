
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public interface IRolesRepository :  ITBaseRepository ,  ITScope  
{
    public Task<ICollection<object>> RolesAllAsync(CancellationToken cancellationToken);

    public Task RolesPOSTAsync(RoleCreate body, CancellationToken cancellationToken);

    public Task<RoleResponse> RolesGETAsync(string id, CancellationToken cancellationToken);

    public Task RolesDELETEAsync(string id, CancellationToken cancellationToken);

    public Task AssignPermissionAsync(RolePermitionAssign body, CancellationToken cancellationToken);

}

