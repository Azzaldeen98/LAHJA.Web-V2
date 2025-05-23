
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public interface ISpaceService :  ITBaseShareService  
{

    public Task<SpaceResponse> createSpaceAsync(CreateSpaceRequest body, CancellationToken cancellationToken);


    public Task<DeletedResponse> deleteSpaceAsync(string id, CancellationToken cancellationToken);


    public Task<ICollection<SpaceResponse>> getBySubscriptionIdSpaceAsync(string subscriptionId, CancellationToken cancellationToken);


    public Task<SpaceResponse> getByTokenSpaceAsync(string token, CancellationToken cancellationToken);


    public Task<ICollection<SpaceResponse>> getSpacesByRamAsync(int ram, CancellationToken cancellationToken);


    public Task<ICollection<SpaceResponse>> getSpacesAsync(CancellationToken cancellationToken);


    public Task<SpaceResponse> getSpaceAsync(string id, CancellationToken cancellationToken);


    public Task<SpaceResponse> updateSpaceAsync(string id, UpdateSpaceRequest body, CancellationToken cancellationToken);




}

