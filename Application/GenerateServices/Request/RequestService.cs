
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public class RequestService : IRequestService {


            
 private readonly AllowedRequestUseCase _allowedRequestUseCase;
 private readonly CreateEventRequestUseCase _createEventRequestUseCase;
 private readonly CreateRequestUseCase _createRequestUseCase;
 private readonly DeleteRequestUseCase _deleteRequestUseCase;
 private readonly GetRequests2UseCase _getRequests2UseCase;
 private readonly GetRequestUseCase _getRequestUseCase;


            public RequestService(
AllowedRequestUseCase allowedRequestUseCase,
CreateEventRequestUseCase createEventRequestUseCase,
CreateRequestUseCase createRequestUseCase,
DeleteRequestUseCase deleteRequestUseCase,
GetRequests2UseCase getRequests2UseCase,
GetRequestUseCase getRequestUseCase){
                
      _allowedRequestUseCase=allowedRequestUseCase;
      _createEventRequestUseCase=createEventRequestUseCase;
      _createRequestUseCase=createRequestUseCase;
      _deleteRequestUseCase=deleteRequestUseCase;
      _getRequests2UseCase=getRequests2UseCase;
      _getRequestUseCase=getRequestUseCase;


            }

                

    public async Task<RequestAllowed> allowedRequestAsync(string serviceId, CancellationToken cancellationToken)
   {

    

         return    await _allowedRequestUseCase.ExecuteAsync(serviceId, cancellationToken);
        

   }



    public async Task<EventRequestResponse> createEventRequestAsync(EventRequestRequest body, CancellationToken cancellationToken)
   {

    

         return    await _createEventRequestUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<ServiceDataTod> createRequestAsync(RequestCreate body, CancellationToken cancellationToken)
   {

    

         return    await _createRequestUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<DeletedResponse> deleteRequestAsync(string id, CancellationToken cancellationToken)
   {

    

         return    await _deleteRequestUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task<ICollection<RequestResponse>> getRequests2Async(CancellationToken cancellationToken)
   {

    

         return    await _getRequests2UseCase.ExecuteAsync(cancellationToken);
        

   }



    public async Task<RequestResponse> getRequestAsync(string id, CancellationToken cancellationToken)
   {

    

         return    await _getRequestUseCase.ExecuteAsync(id, cancellationToken);
        

   }





}
