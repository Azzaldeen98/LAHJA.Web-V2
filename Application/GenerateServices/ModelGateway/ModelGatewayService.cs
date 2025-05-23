
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public class ModelGatewayService : IModelGatewayService {


        
     private readonly CreateModelGatewayUseCase _createModelGatewayUseCase;
     private readonly DefaultModelGatewayUseCase _defaultModelGatewayUseCase;
     private readonly DeleteModelGatewayUseCase _deleteModelGatewayUseCase;
     private readonly GetModelGatewayUseCase _getModelGatewayUseCase;
     private readonly GetModelGatwaysModelGatewayUseCase _getModelGatwaysModelGatewayUseCase;
     private readonly UpdateModelGatewayUseCase _updateModelGatewayUseCase;


    public ModelGatewayService(   
            CreateModelGatewayUseCase createModelGatewayUseCase,
            DefaultModelGatewayUseCase defaultModelGatewayUseCase,
            DeleteModelGatewayUseCase deleteModelGatewayUseCase,
            GetModelGatewayUseCase getModelGatewayUseCase,
            GetModelGatwaysModelGatewayUseCase getModelGatwaysModelGatewayUseCase,
            UpdateModelGatewayUseCase updateModelGatewayUseCase)
    {
                        
          _createModelGatewayUseCase=createModelGatewayUseCase;
          _defaultModelGatewayUseCase=defaultModelGatewayUseCase;
          _deleteModelGatewayUseCase=deleteModelGatewayUseCase;
          _getModelGatewayUseCase=getModelGatewayUseCase;
          _getModelGatwaysModelGatewayUseCase=getModelGatwaysModelGatewayUseCase;
          _updateModelGatewayUseCase=updateModelGatewayUseCase;


    }

                

    public async Task<ModelGatewayResponse> createModelGatewayAsync(ModelGatewayCreate body, CancellationToken cancellationToken)
   {

    

         return   await _createModelGatewayUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task defaultModelGatewayAsync(string id, CancellationToken cancellationToken)
   {

    

         await _defaultModelGatewayUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task<DeletedResponse> deleteModelGatewayAsync(string id, CancellationToken cancellationToken)
   {

    

         return   await _deleteModelGatewayUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task<ModelGatewayResponse> getModelGatewayAsync(string id, CancellationToken cancellationToken)
   {

    

         return   await _getModelGatewayUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task<ICollection<ModelGatewayResponse>> getModelGatwaysModelGatewayAsync(CancellationToken cancellationToken)
   {

    

         return   await _getModelGatwaysModelGatewayUseCase.ExecuteAsync(cancellationToken);
        

   }



    public async Task<ModelGatewayResponse> updateModelGatewayAsync(string id, ModelGatewayUpdate body, CancellationToken cancellationToken)
   {

    

         return   await _updateModelGatewayUseCase.ExecuteAsync(id, body, cancellationToken);
        

   }





}
