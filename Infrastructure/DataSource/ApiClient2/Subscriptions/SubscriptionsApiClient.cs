
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


public class SubscriptionsApiClient : BuildApiClient<SubscriptionsClient>  , ISubscriptionsApiClient {

  
                    public SubscriptionsApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, 
                    IApiInvoker apiInvoker) : base(clientFactory, mapper, config, apiInvoker){

                    }
                

public   async Task<ICollection<SubscriptionResponse>> GetSubscriptionsAsync(CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetSubscriptionsAsync(cancellationToken);

                    });
                

}


public   async Task<SubscriptionCreateResponse> CreateSubscriptionAsync(SubscriptionCreateRequest body, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.CreateSubscriptionAsync(body, cancellationToken);

                    });
                

}


public   async Task<SubscriptionResponse> GetSubscriptionAsync(string id, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetSubscriptionAsync(id, cancellationToken);

                    });
                

}


public   async Task PauseCollectionAsync(string id, SubscriptionUpdateRequest body, CancellationToken cancellationToken)
{


                
                     await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                          await client.PauseCollectionAsync(id, body, cancellationToken);

                    });
                

}


public   async Task ResumeCollectionAsync(string id, CancellationToken cancellationToken)
{


                
                     await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                          await client.ResumeCollectionAsync(id, cancellationToken);

                    });
                

}


public   async Task CancelSubscriptionAsync(string id, CancellationToken cancellationToken)
{


                
                     await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                          await client.CancelSubscriptionAsync(id, cancellationToken);

                    });
                

}


public   async Task CancelAtEndAsync(string id, CancellationToken cancellationToken)
{


                
                     await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                          await client.CancelAtEndAsync(id, cancellationToken);

                    });
                

}


public   async Task RenewAsync(string id, CancellationToken cancellationToken)
{


                
                     await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                          await client.RenewAsync(id, cancellationToken);

                    });
                

}


public   async Task ResumeAsync(string id, SubscriptionResumeRequest body, CancellationToken cancellationToken)
{


                
                     await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                          await client.ResumeAsync(id, body, cancellationToken);

                    });
                

}


public   async Task ResetRequestsAsync(string id, CancellationToken cancellationToken)
{


                
                     await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                          await client.ResetRequestsAsync(id, cancellationToken);

                    });
                

}


public   async Task ResetSpacesAsync(string id, CancellationToken cancellationToken)
{


                
                     await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                          await client.ResetSpacesAsync(id, cancellationToken);

                    });
                

}


}

