
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

public interface IServiceApiClient
 :  ITBaseApiClient  
{
public Task<ICollection<ServiceResponse>> GetServicesAsync(CancellationToken cancellationToken);

public Task<ServiceResponse> CreateServiceAsync(ServiceCreate body, CancellationToken cancellationToken);

public Task<ServiceResponse> GetServiceAsync(string id, CancellationToken cancellationToken);

public Task UpdateServiceAsync(string id, ServiceUpdate body, CancellationToken cancellationToken);

public Task<DeletedResponse> DeleteServiceAsync(string id, CancellationToken cancellationToken);

}

