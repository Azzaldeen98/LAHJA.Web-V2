
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.AutoGenerator.Interfaces;
using Infrastructure.DataSource.ApiClient2.Base;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public class ModelAiRepository : IModelAiRepository {

    private readonly IModelAiApiClient _apiClient;
    public ModelAiRepository(IModelAiApiClient apiClient){
        _apiClient=apiClient;
    }
                

    public async Task<ICollection<Item>> GetStartStudioAsync(string lg, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetStartStudioAsync(lg, cancellationToken);
                

   }


    public async Task<IDictionary<string, object>> GetModelSpechStudioAsync(string lg, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetModelSpechStudioAsync(lg, cancellationToken);
                

   }


    public async Task<IDictionary<string, object>> GetModelTextStudioAsync(string lg, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetModelTextStudioAsync(lg, cancellationToken);
                

   }


    public async Task<IDictionary<string, object>> GetModelChatStudioAsync(string lg, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetModelChatStudioAsync(lg, cancellationToken);
                

   }


    public async Task<ICollection<ModelAiResponse>> GetModelsAiAsync(CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetModelsAiAsync(cancellationToken);
                

   }


    public async Task<ModelAiResponse> CreateModelAiAsync(ModelAiCreate body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.CreateModelAiAsync(body, cancellationToken);
                

   }


    public async Task<ICollection<ArrayResponse>> GetModelsByTypeAsync(string type, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetModelsByTypeAsync(type, cancellationToken);
                

   }


    public async Task<ArrayResponse> GetCategoriesByTypeAsync(string type, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetCategoriesByTypeAsync(type, cancellationToken);
                

   }


    public async Task<ArrayResponse> GetLanguagesByAsync(string type, string category, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetLanguagesByAsync(type, category, cancellationToken);
                

   }


    public async Task<ICollection<ModelAiResponse>> GetModelsByCategoryAsync(string category, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetModelsByCategoryAsync(category, cancellationToken);
                

   }


    public async Task<ICollection<ModelAiResponse>> FilterMaodelAiAsync(FilterModelAI body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.FilterMaodelAiAsync(body, cancellationToken);
                

   }


    public async Task<ICollection<ModelAiResponse>> FilterMaodelAi2Async(FilterModelAI body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.FilterMaodelAi2Async(body, cancellationToken);
                

   }


    public async Task<ICollection<ModelAiResponse>> GetModelsByGenderAsync(string gender, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetModelsByGenderAsync(gender, cancellationToken);
                

   }


    public async Task<ICollection<ModelAiResponse>> GetModelsByDialectAsync(string dialect, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetModelsByDialectAsync(dialect, cancellationToken);
                

   }


    public async Task<ICollection<ModelAiResponse>> GetModelsByLanguageAndDialectAsync(string language, string dialect, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetModelsByLanguageAndDialectAsync(language, dialect, cancellationToken);
                

   }


    public async Task<ICollection<ModelAiResponse>> GetModelsByLanguageDialectTypeAsync(string language, string dialect, string type, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetModelsByLanguageDialectTypeAsync(language, dialect, type, cancellationToken);
                

   }


    public async Task<ICollection<ModelAiResponse>> GetModelsByIsStandardAsync(string isStandard, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetModelsByIsStandardAsync(isStandard, cancellationToken);
                

   }


    public async Task<ICollection<ModelAiResponse>> GetModelsByTypeAndGenderAsync(string type, string gender, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetModelsByTypeAndGenderAsync(type, gender, cancellationToken);
                

   }


    public async Task<ICollection<ModelAiResponse>> GetModelsByLanguageAsync(string language, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetModelsByLanguageAsync(language, cancellationToken);
                

   }


    public async Task<ModelAiResponse> GetModelAiAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetModelAiAsync(id, cancellationToken);
                

   }


    public async Task<ModelAiResponse> UpdateModelAiAsync(string id, ModelAiUpdate body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.UpdateModelAiAsync(id, body, cancellationToken);
                

   }


    public async Task<DeletedResponse> DeleteModelAiAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.DeleteModelAiAsync(id, cancellationToken);
                

   }


    public async Task<ModelPropertyValues> GetSettingModelAiAsync(string langage, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetSettingModelAiAsync(langage, cancellationToken);
                

   }


    public async Task<ValueFilterModel> GetValueFilterServiceAsync(string lg, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetValueFilterServiceAsync(lg, cancellationToken);
                

   }


}

