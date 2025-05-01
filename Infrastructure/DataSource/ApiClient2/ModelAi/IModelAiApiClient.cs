
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Infrastructure.Shared.ApiInvoker;
using AutoMapper;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Shared.ApiInvoker;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.DataSource.ApiClient2;


public interface IModelAiApiClient :  ITBaseApiClient  
{
    public Task<ICollection<Item>> GetStartStudioAsync(string lg, CancellationToken cancellationToken);

    public Task<IDictionary<string, object>> GetModelSpechStudioAsync(string lg, CancellationToken cancellationToken);

    public Task<IDictionary<string, object>> GetModelTextStudioAsync(string lg, CancellationToken cancellationToken);

    public Task<IDictionary<string, object>> GetModelChatStudioAsync(string lg, CancellationToken cancellationToken);

    public Task<ICollection<ModelAiResponse>> GetModelsAiAsync(CancellationToken cancellationToken);

    public Task<ModelAiResponse> CreateModelAiAsync(ModelAiCreate body, CancellationToken cancellationToken);

    public Task<ICollection<ArrayResponse>> GetModelsByTypeAsync(string type, CancellationToken cancellationToken);

    public Task<ArrayResponse> GetCategoriesByTypeAsync(string type, CancellationToken cancellationToken);

    public Task<ArrayResponse> GetLanguagesByAsync(string type, string category, CancellationToken cancellationToken);

    public Task<ICollection<ModelAiResponse>> GetModelsByCategoryAsync(string category, CancellationToken cancellationToken);

    public Task<ICollection<ModelAiResponse>> FilterMaodelAiAsync(FilterModelAI body, CancellationToken cancellationToken);

    public Task<ICollection<ModelAiResponse>> FilterMaodelAi2Async(FilterModelAI body, CancellationToken cancellationToken);

    public Task<ICollection<ModelAiResponse>> GetModelsByGenderAsync(string gender, CancellationToken cancellationToken);

    public Task<ICollection<ModelAiResponse>> GetModelsByDialectAsync(string dialect, CancellationToken cancellationToken);

    public Task<ICollection<ModelAiResponse>> GetModelsByLanguageAndDialectAsync(string language, string dialect, CancellationToken cancellationToken);

    public Task<ICollection<ModelAiResponse>> GetModelsByLanguageDialectTypeAsync(string language, string dialect, string type, CancellationToken cancellationToken);

    public Task<ICollection<ModelAiResponse>> GetModelsByIsStandardAsync(string isStandard, CancellationToken cancellationToken);

    public Task<ICollection<ModelAiResponse>> GetModelsByTypeAndGenderAsync(string type, string gender, CancellationToken cancellationToken);

    public Task<ICollection<ModelAiResponse>> GetModelsByLanguageAsync(string language, CancellationToken cancellationToken);

    public Task<ModelAiResponse> GetModelAiAsync(string id, CancellationToken cancellationToken);

    public Task<ModelAiResponse> UpdateModelAiAsync(string id, ModelAiUpdate body, CancellationToken cancellationToken);

    public Task<DeletedResponse> DeleteModelAiAsync(string id, CancellationToken cancellationToken);

    public Task<ModelPropertyValues> GetSettingModelAiAsync(string langage, CancellationToken cancellationToken);

    public Task<ValueFilterModel> GetValueFilterServiceAsync(string lg, CancellationToken cancellationToken);

}

