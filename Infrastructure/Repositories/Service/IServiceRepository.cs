
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public interface IServiceRepository :  ITBaseRepository ,  ITScope  
{
    public Task<ICollection<ServiceResponse>> GetServicesAsync(CancellationToken cancellationToken);

    public Task<ServiceResponse> CreateServiceAsync(ServiceCreate body, CancellationToken cancellationToken);

    public Task<ServiceResponse> GetServiceAsync(string id, CancellationToken cancellationToken);

    public Task UpdateServiceAsync(string id, ServiceUpdate body, CancellationToken cancellationToken);

    public Task<DeletedResponse> DeleteServiceAsync(string id, CancellationToken cancellationToken);

}

