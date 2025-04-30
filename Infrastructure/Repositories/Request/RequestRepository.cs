
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.AutoGenerator.Interfaces;
using Infrastructure.DataSource.ApiClient2.Base;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public class RequestRepository : IRequestRepository {

    private readonly IRequestApiClient _apiClient;
    public RequestRepository(IRequestApiClient apiClient){
        _apiClient=apiClient;
    }
                

    public async Task<ICollection<RequestResponse>> GetRequests2Async(CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetRequests2Async(cancellationToken);
                

   }


    public async Task<ServiceDataTod> CreateRequestAsync(RequestCreate body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.CreateRequestAsync(body, cancellationToken);
                

   }


    public async Task<RequestResponse> GetRequestAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetRequestAsync(id, cancellationToken);
                

   }


    public async Task<DeletedResponse> DeleteRequestAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.DeleteRequestAsync(id, cancellationToken);
                

   }


    public async Task<EventRequestResponse> CreateEventAsync(EventRequestRequest body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.CreateEventAsync(body, cancellationToken);
                

   }


    public async Task<RequestAllowed> AllowedAsync(string serviceId, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.AllowedAsync(serviceId, cancellationToken);
                

   }


}

