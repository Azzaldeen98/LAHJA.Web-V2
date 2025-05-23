
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public class ServiceMethodService : IServiceMethodService {


        
     private readonly CreateServiceMethodsUseCase _createServiceMethodsUseCase;
     private readonly DeleteServiceMethodsUseCase _deleteServiceMethodsUseCase;
     private readonly GetServiceMethodsUseCase _getServiceMethodsUseCase;
     private readonly GetServiceMethodUseCase _getServiceMethodUseCase;
     private readonly UpdateServiceMethodsUseCase _updateServiceMethodsUseCase;


    public ServiceMethodService(   
            CreateServiceMethodsUseCase createServiceMethodsUseCase,
            DeleteServiceMethodsUseCase deleteServiceMethodsUseCase,
            GetServiceMethodsUseCase getServiceMethodsUseCase,
            GetServiceMethodUseCase getServiceMethodUseCase,
            UpdateServiceMethodsUseCase updateServiceMethodsUseCase)
    {
                        
          _createServiceMethodsUseCase=createServiceMethodsUseCase;
          _deleteServiceMethodsUseCase=deleteServiceMethodsUseCase;
          _getServiceMethodsUseCase=getServiceMethodsUseCase;
          _getServiceMethodUseCase=getServiceMethodUseCase;
          _updateServiceMethodsUseCase=updateServiceMethodsUseCase;


    }

                

    public async Task<ServiceMethodResponse> createServiceMethodsAsync(ServiceMethodCreate body, CancellationToken cancellationToken)
   {

    

         return   await _createServiceMethodsUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<DeletedResponse> deleteServiceMethodsAsync(string id, CancellationToken cancellationToken)
   {

    

         return   await _deleteServiceMethodsUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task<ICollection<ServiceMethodResponse>> getServiceMethodsAsync(CancellationToken cancellationToken)
   {

    

         return   await _getServiceMethodsUseCase.ExecuteAsync(cancellationToken);
        

   }



    public async Task<ServiceMethodResponse> getServiceMethodAsync(string id, CancellationToken cancellationToken)
   {

    

         return   await _getServiceMethodUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task<ServiceMethodResponse> updateServiceMethodsAsync(string id, ServiceMethodUpdate body, CancellationToken cancellationToken)
   {

    

         return   await _updateServiceMethodsUseCase.ExecuteAsync(id, body, cancellationToken);
        

   }





}
