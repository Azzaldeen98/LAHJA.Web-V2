
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public class ServiceService : IServiceService {


        
     private readonly CreateServiceUseCase _createServiceUseCase;
     private readonly DeleteServiceUseCase _deleteServiceUseCase;
     private readonly GetServicesUseCase _getServicesUseCase;
     private readonly GetServiceUseCase _getServiceUseCase;
     private readonly UpdateServiceUseCase _updateServiceUseCase;


    public ServiceService(   
            CreateServiceUseCase createServiceUseCase,
            DeleteServiceUseCase deleteServiceUseCase,
            GetServicesUseCase getServicesUseCase,
            GetServiceUseCase getServiceUseCase,
            UpdateServiceUseCase updateServiceUseCase)
    {
                        
          _createServiceUseCase=createServiceUseCase;
          _deleteServiceUseCase=deleteServiceUseCase;
          _getServicesUseCase=getServicesUseCase;
          _getServiceUseCase=getServiceUseCase;
          _updateServiceUseCase=updateServiceUseCase;


    }

                

    public async Task<ServiceResponse> createServiceAsync(ServiceCreate body, CancellationToken cancellationToken)
   {

    

         return   await _createServiceUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<DeletedResponse> deleteServiceAsync(string id, CancellationToken cancellationToken)
   {

    

         return   await _deleteServiceUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task<ICollection<ServiceResponse>> getServicesAsync(CancellationToken cancellationToken)
   {

    

         return   await _getServicesUseCase.ExecuteAsync(cancellationToken);
        

   }



    public async Task<ServiceResponse> getServiceAsync(string id, CancellationToken cancellationToken)
   {

    

         return   await _getServiceUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task updateServiceAsync(string id, ServiceUpdate body, CancellationToken cancellationToken)
   {

    

         await _updateServiceUseCase.ExecuteAsync(id, body, cancellationToken);
        

   }





}
