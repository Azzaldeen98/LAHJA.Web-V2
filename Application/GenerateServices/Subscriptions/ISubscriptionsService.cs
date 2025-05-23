
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public interface ISubscriptionsService :  ITBaseShareService  
{

    public Task cancelAtEndSubscriptionsAsync(string id, CancellationToken cancellationToken);


    public Task cancelSubscriptionAsync(string id, CancellationToken cancellationToken);


    public Task<SubscriptionCreateResponse> createSubscriptionAsync(SubscriptionCreateRequest body, CancellationToken cancellationToken);


    public Task<ICollection<SubscriptionResponse>> getSubscriptionsAsync(CancellationToken cancellationToken);


    public Task<SubscriptionResponse> getSubscriptionAsync(string id, CancellationToken cancellationToken);


    public Task pauseCollectionSubscriptionsAsync(string id, SubscriptionUpdateRequest body, CancellationToken cancellationToken);


    public Task renewSubscriptionsAsync(string id, CancellationToken cancellationToken);


    public Task resetRequestsSubscriptionsAsync(string id, CancellationToken cancellationToken);


    public Task resetSpacesSubscriptionsAsync(string id, CancellationToken cancellationToken);


    public Task resumeCollectionSubscriptionsAsync(string id, CancellationToken cancellationToken);


    public Task resumeSubscriptionsAsync(string id, SubscriptionResumeRequest body, CancellationToken cancellationToken);




}

