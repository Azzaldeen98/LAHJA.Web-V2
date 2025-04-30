
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


public class ModelAiApiClient : BuildApiClient<ModelAiClient>  , IModelAiApiClient {

  
                    public ModelAiApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, 
                    IApiInvoker apiInvoker) : base(clientFactory, mapper, config, apiInvoker){

                    }
                

public   async Task<ICollection<Item>> GetStartStudioAsync(string lg, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetStartStudioAsync(lg, cancellationToken);

                    });
                

}


public   async Task<IDictionary<string, object>> GetModelSpechStudioAsync(string lg, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetModelSpechStudioAsync(lg, cancellationToken);

                    });
                

}


public   async Task<IDictionary<string, object>> GetModelTextStudioAsync(string lg, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetModelTextStudioAsync(lg, cancellationToken);

                    });
                

}


public   async Task<IDictionary<string, object>> GetModelChatStudioAsync(string lg, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetModelChatStudioAsync(lg, cancellationToken);

                    });
                

}


public   async Task<ICollection<ModelAiResponse>> GetModelsAiAsync(CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetModelsAiAsync(cancellationToken);

                    });
                

}


public   async Task<ModelAiResponse> CreateModelAiAsync(ModelAiCreate body, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.CreateModelAiAsync(body, cancellationToken);

                    });
                

}


public   async Task<ICollection<ArrayResponse>> GetModelsByTypeAsync(string type, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetModelsByTypeAsync(type, cancellationToken);

                    });
                

}


public   async Task<ArrayResponse> GetCategoriesByTypeAsync(string type, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetCategoriesByTypeAsync(type, cancellationToken);

                    });
                

}


public   async Task<ArrayResponse> GetLanguagesByAsync(string type, string category, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetLanguagesByAsync(type, category, cancellationToken);

                    });
                

}


public   async Task<ICollection<ModelAiResponse>> GetModelsByCategoryAsync(string category, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetModelsByCategoryAsync(category, cancellationToken);

                    });
                

}


public   async Task<ICollection<ModelAiResponse>> FilterMaodelAiAsync(FilterModelAI body, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.FilterMaodelAiAsync(body, cancellationToken);

                    });
                

}


public   async Task<ICollection<ModelAiResponse>> FilterMaodelAi2Async(FilterModelAI body, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.FilterMaodelAi2Async(body, cancellationToken);

                    });
                

}


public   async Task<ICollection<ModelAiResponse>> GetModelsByGenderAsync(string gender, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetModelsByGenderAsync(gender, cancellationToken);

                    });
                

}


public   async Task<ICollection<ModelAiResponse>> GetModelsByDialectAsync(string dialect, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetModelsByDialectAsync(dialect, cancellationToken);

                    });
                

}


public   async Task<ICollection<ModelAiResponse>> GetModelsByLanguageAndDialectAsync(string language, string dialect, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetModelsByLanguageAndDialectAsync(language, dialect, cancellationToken);

                    });
                

}


public   async Task<ICollection<ModelAiResponse>> GetModelsByLanguageDialectTypeAsync(string language, string dialect, string type, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetModelsByLanguageDialectTypeAsync(language, dialect, type, cancellationToken);

                    });
                

}


public   async Task<ICollection<ModelAiResponse>> GetModelsByIsStandardAsync(string isStandard, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetModelsByIsStandardAsync(isStandard, cancellationToken);

                    });
                

}


public   async Task<ICollection<ModelAiResponse>> GetModelsByTypeAndGenderAsync(string type, string gender, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetModelsByTypeAndGenderAsync(type, gender, cancellationToken);

                    });
                

}


public   async Task<ICollection<ModelAiResponse>> GetModelsByLanguageAsync(string language, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetModelsByLanguageAsync(language, cancellationToken);

                    });
                

}


public   async Task<ModelAiResponse> GetModelAiAsync(string id, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetModelAiAsync(id, cancellationToken);

                    });
                

}


public   async Task<ModelAiResponse> UpdateModelAiAsync(string id, ModelAiUpdate body, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.UpdateModelAiAsync(id, body, cancellationToken);

                    });
                

}


public   async Task<DeletedResponse> DeleteModelAiAsync(string id, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.DeleteModelAiAsync(id, cancellationToken);

                    });
                

}


public   async Task<ModelPropertyValues> GetSettingModelAiAsync(string langage, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetSettingModelAiAsync(langage, cancellationToken);

                    });
                

}


public   async Task<ValueFilterModel> GetValueFilterServiceAsync(string lg, CancellationToken cancellationToken)
{


                
                     return   await apiInvoker.InvokeAsync(async () =>
                    {
                        var client = await GetApiClient();
                         return    await client.GetValueFilterServiceAsync(lg, cancellationToken);

                    });
                

}


}

