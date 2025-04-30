
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


public class SpaceApiClient : BuildApiClient<SpaceClient>  , ISpaceApiClient {

  
                    public SpaceApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, 
                    IApiInvoker apiInvoker) : base(clientFactory, mapper, config, apiInvoker){

                    }
                

public   async Task<ICollection<SpaceResponse>> GetSpacesAsync(CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetSpacesAsync(cancellationToken);

                    });
                

}


public   async Task<SpaceResponse> CreateSpaceAsync(CreateSpaceRequest body, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.CreateSpaceAsync(body, cancellationToken);

                    });
                

}


public   async Task<SpaceResponse> GetSpaceAsync(string id, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetSpaceAsync(id, cancellationToken);

                    });
                

}


public   async Task<SpaceResponse> UpdateSpaceAsync(string id, UpdateSpaceRequest body, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.UpdateSpaceAsync(id, body, cancellationToken);

                    });
                

}


public   async Task<DeletedResponse> DeleteSpaceAsync(string id, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.DeleteSpaceAsync(id, cancellationToken);

                    });
                

}


public   async Task<SpaceResponse> GetByTokenAsync(string token, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetByTokenAsync(token, cancellationToken);

                    });
                

}


public   async Task<ICollection<SpaceResponse>> GetBySubscriptionIdAsync(string subscriptionId, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetBySubscriptionIdAsync(subscriptionId, cancellationToken);

                    });
                

}


public   async Task<ICollection<SpaceResponse>> GetSpacesByRamAsync(int ram, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetSpacesByRamAsync(ram, cancellationToken);

                    });
                

}


}

