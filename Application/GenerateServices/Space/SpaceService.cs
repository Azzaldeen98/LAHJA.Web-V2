
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public class SpaceService : ISpaceService {


        
     private readonly CreateSpaceUseCase _createSpaceUseCase;
     private readonly DeleteSpaceUseCase _deleteSpaceUseCase;
     private readonly GetBySubscriptionIdSpaceUseCase _getBySubscriptionIdSpaceUseCase;
     private readonly GetByTokenSpaceUseCase _getByTokenSpaceUseCase;
     private readonly GetSpacesByRamUseCase _getSpacesByRamUseCase;
     private readonly GetSpacesUseCase _getSpacesUseCase;
     private readonly GetSpaceUseCase _getSpaceUseCase;
     private readonly UpdateSpaceUseCase _updateSpaceUseCase;


    public SpaceService(   
            CreateSpaceUseCase createSpaceUseCase,
            DeleteSpaceUseCase deleteSpaceUseCase,
            GetBySubscriptionIdSpaceUseCase getBySubscriptionIdSpaceUseCase,
            GetByTokenSpaceUseCase getByTokenSpaceUseCase,
            GetSpacesByRamUseCase getSpacesByRamUseCase,
            GetSpacesUseCase getSpacesUseCase,
            GetSpaceUseCase getSpaceUseCase,
            UpdateSpaceUseCase updateSpaceUseCase)
    {
                        
          _createSpaceUseCase=createSpaceUseCase;
          _deleteSpaceUseCase=deleteSpaceUseCase;
          _getBySubscriptionIdSpaceUseCase=getBySubscriptionIdSpaceUseCase;
          _getByTokenSpaceUseCase=getByTokenSpaceUseCase;
          _getSpacesByRamUseCase=getSpacesByRamUseCase;
          _getSpacesUseCase=getSpacesUseCase;
          _getSpaceUseCase=getSpaceUseCase;
          _updateSpaceUseCase=updateSpaceUseCase;


    }

                

    public async Task<SpaceResponse> createSpaceAsync(CreateSpaceRequest body, CancellationToken cancellationToken)
   {

    

         return   await _createSpaceUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<DeletedResponse> deleteSpaceAsync(string id, CancellationToken cancellationToken)
   {

    

         return   await _deleteSpaceUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task<ICollection<SpaceResponse>> getBySubscriptionIdSpaceAsync(string subscriptionId, CancellationToken cancellationToken)
   {

    

         return   await _getBySubscriptionIdSpaceUseCase.ExecuteAsync(subscriptionId, cancellationToken);
        

   }



    public async Task<SpaceResponse> getByTokenSpaceAsync(string token, CancellationToken cancellationToken)
   {

    

         return   await _getByTokenSpaceUseCase.ExecuteAsync(token, cancellationToken);
        

   }



    public async Task<ICollection<SpaceResponse>> getSpacesByRamAsync(int ram, CancellationToken cancellationToken)
   {

    

         return   await _getSpacesByRamUseCase.ExecuteAsync(ram, cancellationToken);
        

   }



    public async Task<ICollection<SpaceResponse>> getSpacesAsync(CancellationToken cancellationToken)
   {

    

         return   await _getSpacesUseCase.ExecuteAsync(cancellationToken);
        

   }



    public async Task<SpaceResponse> getSpaceAsync(string id, CancellationToken cancellationToken)
   {

    

         return   await _getSpaceUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task<SpaceResponse> updateSpaceAsync(string id, UpdateSpaceRequest body, CancellationToken cancellationToken)
   {

    

         return   await _updateSpaceUseCase.ExecuteAsync(id, body, cancellationToken);
        

   }





}
