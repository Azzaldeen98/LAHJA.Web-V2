
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.AutoGenerator.Interfaces;
using Infrastructure.DataSource.ApiClient2.Base;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public interface IProfileRepository :  ITBaseRepository ,  ITScope  
{
public Task<UserResponse> UserAsync(CancellationToken cancellationToken);

public Task UpdateAsync(UserRequest body, CancellationToken cancellationToken);

public Task<CustomerResponse> GetCustomerAsync(CancellationToken cancellationToken);

public Task<ICollection<SubscriptionResponse>> SubscriptionsAsync(CancellationToken cancellationToken);

public Task<ICollection<ModelAiResponse>> ModelAisAsync(CancellationToken cancellationToken);

public Task<ICollection<ServiceResponse>> ServicesAsync(CancellationToken cancellationToken);

public Task<ICollection<ServiceResponse>> ServicesModelAiAsync(string modelAiId, CancellationToken cancellationToken);

public Task<ICollection<SpaceResponse>> SpacesSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken);

public Task<SpaceResponse> SpaceSubscriptionAsync(string subscriptionId, string spaceId, CancellationToken cancellationToken);

public Task<ICollection<RequestResponse>> RequestsSubscriptionAsync(string subscriptionId, CancellationToken cancellationToken);

public Task<ICollection<RequestResponse>> RequestsServiceAsync(string serviceId, CancellationToken cancellationToken);

}

