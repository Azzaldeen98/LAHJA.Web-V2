
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Infrastructure.Shared.ApiInvoker;
using AutoMapper;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Shared.ApiInvoker;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.DataSource.ApiClient2;


public interface IServiceMethodApiClient :  ITBaseApiClient  
{
    public Task<ICollection<ServiceMethodResponse>> GetServiceMethodsAsync(CancellationToken cancellationToken);

    public Task<ServiceMethodResponse> CreateServiceMethodsAsync(ServiceMethodCreate body, CancellationToken cancellationToken);

    public Task<ServiceMethodResponse> GetServiceMethodAsync(string id, CancellationToken cancellationToken);

    public Task<ServiceMethodResponse> UpdateServiceMethodsAsync(string id, ServiceMethodUpdate body, CancellationToken cancellationToken);

    public Task<DeletedResponse> DeleteServiceMethodsAsync(string id, CancellationToken cancellationToken);

}

