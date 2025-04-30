
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


public class MasterApiClient : BuildApiClient<MasterClient>  , IMasterApiClient {

  
                    public MasterApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, 
                    IApiInvoker apiInvoker) : base(clientFactory, mapper, config, apiInvoker){

                    }
                

public   async Task<ICollection<LanguageView>> LanguagesAllAsync(string lg, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.LanguagesAllAsync(lg, cancellationToken);

                    });
                

}


public   async Task LanguagesPOSTAsync(string lg, LanguageCreate body, CancellationToken cancellationToken)
{


                
                     await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                          await client.LanguagesPOSTAsync(lg, body, cancellationToken);

                    });
                

}


public   async Task LanguagesGETAsync(string code, string lg, CancellationToken cancellationToken)
{


                
                     await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                          await client.LanguagesGETAsync(code, lg, cancellationToken);

                    });
                

}


public   async Task CategoriesGETAsync(string name, string lg, CancellationToken cancellationToken)
{


                
                     await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                          await client.CategoriesGETAsync(name, lg, cancellationToken);

                    });
                

}


public   async Task CategoriesPOSTAsync(string lg, CategoryCreate body, CancellationToken cancellationToken)
{


                
                     await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                          await client.CategoriesPOSTAsync(lg, body, cancellationToken);

                    });
                

}


public   async Task<TypeModelView> TypesGETAsync(string name, string lg, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.TypesGETAsync(name, lg, cancellationToken);

                    });
                

}


public   async Task<ICollection<TypeModelView>> ActiveAsync(string lg, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.ActiveAsync(lg, cancellationToken);

                    });
                

}


public   async Task<TypeModelView> TypesPOSTAsync(string lg, TypeModelCreate body, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.TypesPOSTAsync(lg, body, cancellationToken);

                    });
                

}


public   async Task<DialectView> DialectAsync(string languageId, string lg, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.DialectAsync(languageId, lg, cancellationToken);

                    });
                

}


public   async Task<ICollection<DialectView>> DialectsAllAsync(string languageId, string lg, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.DialectsAllAsync(languageId, lg, cancellationToken);

                    });
                

}


public   async Task<DialectView> DialectsAsync(string lg, DialectCreate body, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.DialectsAsync(lg, body, cancellationToken);

                    });
                

}


public   async Task<AdvertisementView> AdvertisementsGETAsync(string id, string lg, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.AdvertisementsGETAsync(id, lg, cancellationToken);

                    });
                

}


public   async Task<ICollection<AdvertisementView>> Active2Async(string lg, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.Active2Async(lg, cancellationToken);

                    });
                

}


public   async Task AdvertisementsPOSTAsync(string lg, AdvertisementCreate body, CancellationToken cancellationToken)
{


                
                     await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                          await client.AdvertisementsPOSTAsync(lg, body, cancellationToken);

                    });
                

}


public   async Task<AdvertisementTabView> AdvertisementtabAsync(string id, string lg, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.AdvertisementtabAsync(id, lg, cancellationToken);

                    });
                

}


public   async Task<ICollection<AdvertisementTabView>> AdvertisementtabsAllAsync(string advertisementId, string lg, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.AdvertisementtabsAllAsync(advertisementId, lg, cancellationToken);

                    });
                

}


public   async Task<AdvertisementTabView> AdvertisementtabsAsync(string lg, AdvertisementTabCreate body, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.AdvertisementtabsAsync(lg, body, cancellationToken);

                    });
                

}


}

