
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public interface IServiceMethodService :  ITBaseShareService  
{

    public Task<ServiceMethodResponse> createServiceMethodsAsync(ServiceMethodCreate body, CancellationToken cancellationToken);


    public Task<DeletedResponse> deleteServiceMethodsAsync(string id, CancellationToken cancellationToken);


    public Task<ICollection<ServiceMethodResponse>> getServiceMethodsAsync(CancellationToken cancellationToken);


    public Task<ServiceMethodResponse> getServiceMethodAsync(string id, CancellationToken cancellationToken);


    public Task<ServiceMethodResponse> updateServiceMethodsAsync(string id, ServiceMethodUpdate body, CancellationToken cancellationToken);




}

