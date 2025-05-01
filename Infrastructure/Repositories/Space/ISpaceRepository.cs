
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public interface ISpaceRepository :  ITBaseRepository ,  ITScope  
{
    public Task<ICollection<SpaceResponse>> GetSpacesAsync(CancellationToken cancellationToken);

    public Task<SpaceResponse> CreateSpaceAsync(CreateSpaceRequest body, CancellationToken cancellationToken);

    public Task<SpaceResponse> GetSpaceAsync(string id, CancellationToken cancellationToken);

    public Task<SpaceResponse> UpdateSpaceAsync(string id, UpdateSpaceRequest body, CancellationToken cancellationToken);

    public Task<DeletedResponse> DeleteSpaceAsync(string id, CancellationToken cancellationToken);

    public Task<SpaceResponse> GetByTokenAsync(string token, CancellationToken cancellationToken);

    public Task<ICollection<SpaceResponse>> GetBySubscriptionIdAsync(string subscriptionId, CancellationToken cancellationToken);

    public Task<ICollection<SpaceResponse>> GetSpacesByRamAsync(int ram, CancellationToken cancellationToken);

}

