
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Infrastructure.Shared.ApiInvoker;
using AutoMapper;
using Shared.AutoGenerator.Interfaces;
using Infrastructure.DataSource.ApiClient2.Base;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Shared.ApiInvoker;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.DataSource.ApiClient2;

public interface IModelGatewayApiClient
 :  ITBaseApiClient  
{
public Task<ICollection<ModelGatewayResponse>> GetModelGatwaysAsync(CancellationToken cancellationToken);

public Task<ModelGatewayResponse> CreateModelGatewayAsync(ModelGatewayCreate body, CancellationToken cancellationToken);

public Task<ModelGatewayResponse> GetModelGatewayAsync(string id, CancellationToken cancellationToken);

public Task<ModelGatewayResponse> UpdateModelGatewayAsync(string id, ModelGatewayUpdate body, CancellationToken cancellationToken);

public Task<DeletedResponse> DeleteModelGatewayAsync(string id, CancellationToken cancellationToken);

public Task DefaultModelGatewayAsync(string id, CancellationToken cancellationToken);

}

