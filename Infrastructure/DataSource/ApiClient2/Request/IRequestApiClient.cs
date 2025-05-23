
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Infrastructure.Share.Invoker;
using AutoMapper;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Share.Invoker;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.DataSource.ApiClient2;


public interface IRequestApiClient :  ITBaseApiClient  
{
    public Task<ICollection<RequestResponse>> GetRequests2Async(CancellationToken cancellationToken);

    public Task<ServiceDataTod> CreateRequestAsync(RequestCreate body, CancellationToken cancellationToken);

    public Task<RequestResponse> GetRequestAsync(string id, CancellationToken cancellationToken);

    public Task<DeletedResponse> DeleteRequestAsync(string id, CancellationToken cancellationToken);

    public Task<EventRequestResponse> CreateEventAsync(EventRequestRequest body, CancellationToken cancellationToken);

    public Task<RequestAllowed> AllowedAsync(string serviceId, CancellationToken cancellationToken);

}

