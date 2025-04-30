
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.AutoGenerator.Interfaces;
using Infrastructure.DataSource.ApiClient2.Base;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public interface ISettingRepository :  ITBaseRepository ,  ITScope  
{
public Task<ICollection<object>> SettingAllAsync(CancellationToken cancellationToken);

public Task<ServiceResponse> SettingPOSTAsync(SettingCreate body, CancellationToken cancellationToken);

public Task<ServiceResponse> SettingGETAsync(string name, CancellationToken cancellationToken);

public Task SettingPUTAsync(string name, SettingUpdate body, CancellationToken cancellationToken);

public Task SettingDELETEAsync(string name, CancellationToken cancellationToken);

}

