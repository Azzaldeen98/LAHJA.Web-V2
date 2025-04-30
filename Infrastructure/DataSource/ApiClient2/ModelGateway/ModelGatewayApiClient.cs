
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


public class ModelGatewayApiClient : BuildApiClient<ModelGatewayClient>  , IModelGatewayApiClient {

  
                    public ModelGatewayApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, 
                    IApiInvoker apiInvoker) : base(clientFactory, mapper, config, apiInvoker){

                    }
                

public   async Task<ICollection<ModelGatewayResponse>> GetModelGatwaysAsync(CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetModelGatwaysAsync(cancellationToken);

                    });
                

}


public   async Task<ModelGatewayResponse> CreateModelGatewayAsync(ModelGatewayCreate body, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.CreateModelGatewayAsync(body, cancellationToken);

                    });
                

}


public   async Task<ModelGatewayResponse> GetModelGatewayAsync(string id, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetModelGatewayAsync(id, cancellationToken);

                    });
                

}


public   async Task<ModelGatewayResponse> UpdateModelGatewayAsync(string id, ModelGatewayUpdate body, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.UpdateModelGatewayAsync(id, body, cancellationToken);

                    });
                

}


public   async Task<DeletedResponse> DeleteModelGatewayAsync(string id, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.DeleteModelGatewayAsync(id, cancellationToken);

                    });
                

}


public   async Task DefaultModelGatewayAsync(string id, CancellationToken cancellationToken)
{


                
                     await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                          await client.DefaultModelGatewayAsync(id, cancellationToken);

                    });
                

}


}

