
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public interface IRequestRepository :  ITBaseRepository ,  ITScope  
{
    public Task<ICollection<RequestResponse>> GetRequests2Async(CancellationToken cancellationToken);

    public Task<ServiceDataTod> CreateRequestAsync(RequestCreate body, CancellationToken cancellationToken);

    public Task<RequestResponse> GetRequestAsync(string id, CancellationToken cancellationToken);

    public Task<DeletedResponse> DeleteRequestAsync(string id, CancellationToken cancellationToken);

    public Task<EventRequestResponse> CreateEventAsync(EventRequestRequest body, CancellationToken cancellationToken);

    public Task<RequestAllowed> AllowedAsync(string serviceId, CancellationToken cancellationToken);

}

