
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

public interface ISubscriptionsApiClient
 :  ITBaseApiClient  
{
public Task<ICollection<SubscriptionResponse>> GetSubscriptionsAsync(CancellationToken cancellationToken);

public Task<SubscriptionCreateResponse> CreateSubscriptionAsync(SubscriptionCreateRequest body, CancellationToken cancellationToken);

public Task<SubscriptionResponse> GetSubscriptionAsync(string id, CancellationToken cancellationToken);

public Task PauseCollectionAsync(string id, SubscriptionUpdateRequest body, CancellationToken cancellationToken);

public Task ResumeCollectionAsync(string id, CancellationToken cancellationToken);

public Task CancelSubscriptionAsync(string id, CancellationToken cancellationToken);

public Task CancelAtEndAsync(string id, CancellationToken cancellationToken);

public Task RenewAsync(string id, CancellationToken cancellationToken);

public Task ResumeAsync(string id, SubscriptionResumeRequest body, CancellationToken cancellationToken);

public Task ResetRequestsAsync(string id, CancellationToken cancellationToken);

public Task ResetSpacesAsync(string id, CancellationToken cancellationToken);

}

