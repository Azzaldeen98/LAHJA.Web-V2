
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public interface IModelGatewayService :  ITBaseShareService  
{

    public Task<ModelGatewayResponse> createModelGatewayAsync(ModelGatewayCreate body, CancellationToken cancellationToken);


    public Task defaultModelGatewayAsync(string id, CancellationToken cancellationToken);


    public Task<DeletedResponse> deleteModelGatewayAsync(string id, CancellationToken cancellationToken);


    public Task<ModelGatewayResponse> getModelGatewayAsync(string id, CancellationToken cancellationToken);


    public Task<ICollection<ModelGatewayResponse>> getModelGatwaysModelGatewayAsync(CancellationToken cancellationToken);


    public Task<ModelGatewayResponse> updateModelGatewayAsync(string id, ModelGatewayUpdate body, CancellationToken cancellationToken);




}

