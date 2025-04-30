
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

public interface ISettingApiClient
 :  ITBaseApiClient  
{
public Task<ICollection<object>> SettingAllAsync(CancellationToken cancellationToken);

public Task<ServiceResponse> SettingPOSTAsync(SettingCreate body, CancellationToken cancellationToken);

public Task<ServiceResponse> SettingGETAsync(string name, CancellationToken cancellationToken);

public Task SettingPUTAsync(string name, SettingUpdate body, CancellationToken cancellationToken);

public Task SettingDELETEAsync(string name, CancellationToken cancellationToken);

}

