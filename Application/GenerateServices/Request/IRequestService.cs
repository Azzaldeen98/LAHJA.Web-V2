
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public interface IRequestService :  ITBaseShareService  
{

    public Task<RequestAllowed> allowedRequestAsync(string serviceId, CancellationToken cancellationToken);


    public Task<EventRequestResponse> createEventRequestAsync(EventRequestRequest body, CancellationToken cancellationToken);


    public Task<ServiceDataTod> createRequestAsync(RequestCreate body, CancellationToken cancellationToken);


    public Task<DeletedResponse> deleteRequestAsync(string id, CancellationToken cancellationToken);


    public Task<ICollection<RequestResponse>> getRequests2Async(CancellationToken cancellationToken);


    public Task<RequestResponse> getRequestAsync(string id, CancellationToken cancellationToken);




}

