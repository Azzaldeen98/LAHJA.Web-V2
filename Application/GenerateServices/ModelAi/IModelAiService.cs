
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public interface IModelAiService :  ITBaseShareService  
{

    public Task<ModelAiResponse> createModelAiAsync(ModelAiCreate body, CancellationToken cancellationToken);


    public Task<DeletedResponse> deleteModelAiAsync(string id, CancellationToken cancellationToken);


    public Task<ICollection<ModelAiResponse>> filterMaodelAi2ModelAiAsync(FilterModelAI body, CancellationToken cancellationToken);


    public Task<ICollection<ModelAiResponse>> filterMaodelAiModelAiAsync(FilterModelAI body, CancellationToken cancellationToken);


    public Task<ArrayResponse> getCategoriesByTypeModelAiAsync(string type, CancellationToken cancellationToken);


    public Task<ArrayResponse> getLanguagesByModelAiAsync(string type, string category, CancellationToken cancellationToken);


    public Task<ModelAiResponse> getModelAiAsync(string id, CancellationToken cancellationToken);


    public Task<IDictionary<string, object>> getModelChatStudioModelAiAsync(string lg, CancellationToken cancellationToken);


    public Task<ICollection<ModelAiResponse>> getModelsAiModelAiAsync(CancellationToken cancellationToken);


    public Task<ICollection<ModelAiResponse>> getModelsByCategoryModelAiAsync(string category, CancellationToken cancellationToken);


    public Task<ICollection<ModelAiResponse>> getModelsByDialectModelAiAsync(string dialect, CancellationToken cancellationToken);


    public Task<ICollection<ModelAiResponse>> getModelsByGenderModelAiAsync(string gender, CancellationToken cancellationToken);


    public Task<ICollection<ModelAiResponse>> getModelsByIsStandardModelAiAsync(string isStandard, CancellationToken cancellationToken);


    public Task<ICollection<ModelAiResponse>> getModelsByLanguageAndDialectModelAiAsync(string language, string dialect, CancellationToken cancellationToken);


    public Task<ICollection<ModelAiResponse>> getModelsByLanguageDialectTypeModelAiAsync(string language, string dialect, string type, CancellationToken cancellationToken);


    public Task<ICollection<ModelAiResponse>> getModelsByLanguageModelAiAsync(string language, CancellationToken cancellationToken);


    public Task<ICollection<ModelAiResponse>> getModelsByTypeAndGenderModelAiAsync(string type, string gender, CancellationToken cancellationToken);


    public Task<ICollection<ArrayResponse>> getModelsByTypeModelAiAsync(string type, CancellationToken cancellationToken);


    public Task<IDictionary<string, object>> getModelSpechStudioModelAiAsync(string lg, CancellationToken cancellationToken);


    public Task<IDictionary<string, object>> getModelTextStudioModelAiAsync(string lg, CancellationToken cancellationToken);


    public Task<ModelPropertyValues> getSettingModelAiAsync(string langage, CancellationToken cancellationToken);


    public Task<ICollection<Item>> getStartStudioModelAiAsync(string lg, CancellationToken cancellationToken);


    public Task<ValueFilterModel> getValueFilterServiceModelAiAsync(string lg, CancellationToken cancellationToken);


    public Task<ModelAiResponse> updateModelAiAsync(string id, ModelAiUpdate body, CancellationToken cancellationToken);




}

