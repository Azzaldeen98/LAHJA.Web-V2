
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.AutoGenerator.Interfaces;
using Infrastructure.DataSource.ApiClient2.Base;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public interface IServiceMethodRepository :  ITBaseRepository ,  ITScope  
{
public Task<ICollection<ServiceMethodResponse>> GetServiceMethodsAsync(CancellationToken cancellationToken);

public Task<ServiceMethodResponse> CreateServiceMethodsAsync(ServiceMethodCreate body, CancellationToken cancellationToken);

public Task<ServiceMethodResponse> GetServiceMethodAsync(string id, CancellationToken cancellationToken);

public Task<ServiceMethodResponse> UpdateServiceMethodsAsync(string id, ServiceMethodUpdate body, CancellationToken cancellationToken);

public Task<DeletedResponse> DeleteServiceMethodsAsync(string id, CancellationToken cancellationToken);

}

