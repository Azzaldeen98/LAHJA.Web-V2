
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public interface IProfileService :  ITBaseService ,  ITScope  
{

    public Task<CustomerResponse> getCustomerProfileAsync(CancellationToken cancellationToken);


    public Task<ICollection<ModelAiResponse>> modelAisProfileAsync(CancellationToken cancellationToken);


    public Task<ICollection<RequestResponse>> requestsServiceProfileAsync(string serviceId, CancellationToken cancellationToken);


    public Task<ICollection<RequestResponse>> requestsSubscriptionProfileAsync(string subscriptionId, CancellationToken cancellationToken);


    public Task<ICollection<ServiceResponse>> servicesModelAiProfileAsync(string modelAiId, CancellationToken cancellationToken);


    public Task<ICollection<ServiceResponse>> servicesProfileAsync(CancellationToken cancellationToken);


    public Task<ICollection<SpaceResponse>> spacesSubscriptionProfileAsync(string subscriptionId, CancellationToken cancellationToken);


    public Task<SpaceResponse> spaceSubscriptionProfileAsync(string subscriptionId, string spaceId, CancellationToken cancellationToken);


    public Task<ICollection<SubscriptionResponse>> subscriptionsProfileAsync(CancellationToken cancellationToken);


    public Task updateProfileAsync(UserRequest body, CancellationToken cancellationToken);


    public Task<UserResponse> userProfileAsync(CancellationToken cancellationToken);




}

