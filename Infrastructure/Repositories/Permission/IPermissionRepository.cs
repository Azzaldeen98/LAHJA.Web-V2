
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public interface IPermissionRepository :  ITBaseRepository ,  ITScope  
{
    public Task GetAllAsync(CancellationToken cancellationToken);

}

