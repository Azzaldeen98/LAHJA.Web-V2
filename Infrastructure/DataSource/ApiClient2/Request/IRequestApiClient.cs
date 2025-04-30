
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

public interface IRequestApiClient
 :  ITBaseApiClient  
{
public Task<ICollection<RequestResponse>> GetRequests2Async(CancellationToken cancellationToken);

public Task<ServiceDataTod> CreateRequestAsync(RequestCreate body, CancellationToken cancellationToken);

public Task<RequestResponse> GetRequestAsync(string id, CancellationToken cancellationToken);

public Task<DeletedResponse> DeleteRequestAsync(string id, CancellationToken cancellationToken);

public Task<EventRequestResponse> CreateEventAsync(EventRequestRequest body, CancellationToken cancellationToken);

public Task<RequestAllowed> AllowedAsync(string serviceId, CancellationToken cancellationToken);

}

