﻿
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Infrastructure.Share.Invoker;
using AutoMapper;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Share.Invoker;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.DataSource.ApiClient2;


public interface IModelGatewayApiClient :  ITBaseApiClient  
{
    public Task<ICollection<ModelGatewayResponse>> GetModelGatwaysAsync(CancellationToken cancellationToken);

    public Task<ModelGatewayResponse> CreateModelGatewayAsync(ModelGatewayCreate body, CancellationToken cancellationToken);

    public Task<ModelGatewayResponse> GetModelGatewayAsync(string id, CancellationToken cancellationToken);

    public Task<ModelGatewayResponse> UpdateModelGatewayAsync(string id, ModelGatewayUpdate body, CancellationToken cancellationToken);

    public Task<DeletedResponse> DeleteModelGatewayAsync(string id, CancellationToken cancellationToken);

    public Task DefaultModelGatewayAsync(string id, CancellationToken cancellationToken);

}

