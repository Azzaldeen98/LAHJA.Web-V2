
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public interface IServiceService :  ITBaseService ,  ITScope  
{

    public Task<ServiceResponse> createServiceAsync(ServiceCreate body, CancellationToken cancellationToken);


    public Task<DeletedResponse> deleteServiceAsync(string id, CancellationToken cancellationToken);


    public Task<ICollection<ServiceResponse>> getServicesAsync(CancellationToken cancellationToken);


    public Task<ServiceResponse> getServiceAsync(string id, CancellationToken cancellationToken);


    public Task updateServiceAsync(string id, ServiceUpdate body, CancellationToken cancellationToken);




}

