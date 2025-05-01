
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


public interface IProfileApiClient :  ITBaseApiClient  
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

