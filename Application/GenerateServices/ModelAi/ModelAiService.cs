
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public class ModelAiService : IModelAiService {


        
     private readonly CreateModelAiUseCase _createModelAiUseCase;
     private readonly DeleteModelAiUseCase _deleteModelAiUseCase;
     private readonly FilterMaodelAi2ModelAiUseCase _filterMaodelAi2ModelAiUseCase;
     private readonly FilterMaodelAiModelAiUseCase _filterMaodelAiModelAiUseCase;
     private readonly GetCategoriesByTypeModelAiUseCase _getCategoriesByTypeModelAiUseCase;
     private readonly GetLanguagesByModelAiUseCase _getLanguagesByModelAiUseCase;
     private readonly GetModelAiUseCase _getModelAiUseCase;
     private readonly GetModelChatStudioModelAiUseCase _getModelChatStudioModelAiUseCase;
     private readonly GetModelsAiModelAiUseCase _getModelsAiModelAiUseCase;
     private readonly GetModelsByCategoryModelAiUseCase _getModelsByCategoryModelAiUseCase;
     private readonly GetModelsByDialectModelAiUseCase _getModelsByDialectModelAiUseCase;
     private readonly GetModelsByGenderModelAiUseCase _getModelsByGenderModelAiUseCase;
     private readonly GetModelsByIsStandardModelAiUseCase _getModelsByIsStandardModelAiUseCase;
     private readonly GetModelsByLanguageAndDialectModelAiUseCase _getModelsByLanguageAndDialectModelAiUseCase;
     private readonly GetModelsByLanguageDialectTypeModelAiUseCase _getModelsByLanguageDialectTypeModelAiUseCase;
     private readonly GetModelsByLanguageModelAiUseCase _getModelsByLanguageModelAiUseCase;
     private readonly GetModelsByTypeAndGenderModelAiUseCase _getModelsByTypeAndGenderModelAiUseCase;
     private readonly GetModelsByTypeModelAiUseCase _getModelsByTypeModelAiUseCase;
     private readonly GetModelSpechStudioModelAiUseCase _getModelSpechStudioModelAiUseCase;
     private readonly GetModelTextStudioModelAiUseCase _getModelTextStudioModelAiUseCase;
     private readonly GetSettingModelAiUseCase _getSettingModelAiUseCase;
     private readonly GetStartStudioModelAiUseCase _getStartStudioModelAiUseCase;
     private readonly GetValueFilterServiceModelAiUseCase _getValueFilterServiceModelAiUseCase;
     private readonly UpdateModelAiUseCase _updateModelAiUseCase;


    public ModelAiService(   
            CreateModelAiUseCase createModelAiUseCase,
            DeleteModelAiUseCase deleteModelAiUseCase,
            FilterMaodelAi2ModelAiUseCase filterMaodelAi2ModelAiUseCase,
            FilterMaodelAiModelAiUseCase filterMaodelAiModelAiUseCase,
            GetCategoriesByTypeModelAiUseCase getCategoriesByTypeModelAiUseCase,
            GetLanguagesByModelAiUseCase getLanguagesByModelAiUseCase,
            GetModelAiUseCase getModelAiUseCase,
            GetModelChatStudioModelAiUseCase getModelChatStudioModelAiUseCase,
            GetModelsAiModelAiUseCase getModelsAiModelAiUseCase,
            GetModelsByCategoryModelAiUseCase getModelsByCategoryModelAiUseCase,
            GetModelsByDialectModelAiUseCase getModelsByDialectModelAiUseCase,
            GetModelsByGenderModelAiUseCase getModelsByGenderModelAiUseCase,
            GetModelsByIsStandardModelAiUseCase getModelsByIsStandardModelAiUseCase,
            GetModelsByLanguageAndDialectModelAiUseCase getModelsByLanguageAndDialectModelAiUseCase,
            GetModelsByLanguageDialectTypeModelAiUseCase getModelsByLanguageDialectTypeModelAiUseCase,
            GetModelsByLanguageModelAiUseCase getModelsByLanguageModelAiUseCase,
            GetModelsByTypeAndGenderModelAiUseCase getModelsByTypeAndGenderModelAiUseCase,
            GetModelsByTypeModelAiUseCase getModelsByTypeModelAiUseCase,
            GetModelSpechStudioModelAiUseCase getModelSpechStudioModelAiUseCase,
            GetModelTextStudioModelAiUseCase getModelTextStudioModelAiUseCase,
            GetSettingModelAiUseCase getSettingModelAiUseCase,
            GetStartStudioModelAiUseCase getStartStudioModelAiUseCase,
            GetValueFilterServiceModelAiUseCase getValueFilterServiceModelAiUseCase,
            UpdateModelAiUseCase updateModelAiUseCase)
    {
                        
          _createModelAiUseCase=createModelAiUseCase;
          _deleteModelAiUseCase=deleteModelAiUseCase;
          _filterMaodelAi2ModelAiUseCase=filterMaodelAi2ModelAiUseCase;
          _filterMaodelAiModelAiUseCase=filterMaodelAiModelAiUseCase;
          _getCategoriesByTypeModelAiUseCase=getCategoriesByTypeModelAiUseCase;
          _getLanguagesByModelAiUseCase=getLanguagesByModelAiUseCase;
          _getModelAiUseCase=getModelAiUseCase;
          _getModelChatStudioModelAiUseCase=getModelChatStudioModelAiUseCase;
          _getModelsAiModelAiUseCase=getModelsAiModelAiUseCase;
          _getModelsByCategoryModelAiUseCase=getModelsByCategoryModelAiUseCase;
          _getModelsByDialectModelAiUseCase=getModelsByDialectModelAiUseCase;
          _getModelsByGenderModelAiUseCase=getModelsByGenderModelAiUseCase;
          _getModelsByIsStandardModelAiUseCase=getModelsByIsStandardModelAiUseCase;
          _getModelsByLanguageAndDialectModelAiUseCase=getModelsByLanguageAndDialectModelAiUseCase;
          _getModelsByLanguageDialectTypeModelAiUseCase=getModelsByLanguageDialectTypeModelAiUseCase;
          _getModelsByLanguageModelAiUseCase=getModelsByLanguageModelAiUseCase;
          _getModelsByTypeAndGenderModelAiUseCase=getModelsByTypeAndGenderModelAiUseCase;
          _getModelsByTypeModelAiUseCase=getModelsByTypeModelAiUseCase;
          _getModelSpechStudioModelAiUseCase=getModelSpechStudioModelAiUseCase;
          _getModelTextStudioModelAiUseCase=getModelTextStudioModelAiUseCase;
          _getSettingModelAiUseCase=getSettingModelAiUseCase;
          _getStartStudioModelAiUseCase=getStartStudioModelAiUseCase;
          _getValueFilterServiceModelAiUseCase=getValueFilterServiceModelAiUseCase;
          _updateModelAiUseCase=updateModelAiUseCase;


    }

                

    public async Task<ModelAiResponse> createModelAiAsync(ModelAiCreate body, CancellationToken cancellationToken)
   {

    

         return   await _createModelAiUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<DeletedResponse> deleteModelAiAsync(string id, CancellationToken cancellationToken)
   {

    

         return   await _deleteModelAiUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task<ICollection<ModelAiResponse>> filterMaodelAi2ModelAiAsync(FilterModelAI body, CancellationToken cancellationToken)
   {

    

         return   await _filterMaodelAi2ModelAiUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<ICollection<ModelAiResponse>> filterMaodelAiModelAiAsync(FilterModelAI body, CancellationToken cancellationToken)
   {

    

         return   await _filterMaodelAiModelAiUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<ArrayResponse> getCategoriesByTypeModelAiAsync(string type, CancellationToken cancellationToken)
   {

    

         return   await _getCategoriesByTypeModelAiUseCase.ExecuteAsync(type, cancellationToken);
        

   }



    public async Task<ArrayResponse> getLanguagesByModelAiAsync(string type, string category, CancellationToken cancellationToken)
   {

    

         return   await _getLanguagesByModelAiUseCase.ExecuteAsync(type, category, cancellationToken);
        

   }



    public async Task<ModelAiResponse> getModelAiAsync(string id, CancellationToken cancellationToken)
   {

    

         return   await _getModelAiUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task<IDictionary<string, object>> getModelChatStudioModelAiAsync(string lg, CancellationToken cancellationToken)
   {

    

         return   await _getModelChatStudioModelAiUseCase.ExecuteAsync(lg, cancellationToken);
        

   }



    public async Task<ICollection<ModelAiResponse>> getModelsAiModelAiAsync(CancellationToken cancellationToken)
   {

    

         return   await _getModelsAiModelAiUseCase.ExecuteAsync(cancellationToken);
        

   }



    public async Task<ICollection<ModelAiResponse>> getModelsByCategoryModelAiAsync(string category, CancellationToken cancellationToken)
   {

    

         return   await _getModelsByCategoryModelAiUseCase.ExecuteAsync(category, cancellationToken);
        

   }



    public async Task<ICollection<ModelAiResponse>> getModelsByDialectModelAiAsync(string dialect, CancellationToken cancellationToken)
   {

    

         return   await _getModelsByDialectModelAiUseCase.ExecuteAsync(dialect, cancellationToken);
        

   }



    public async Task<ICollection<ModelAiResponse>> getModelsByGenderModelAiAsync(string gender, CancellationToken cancellationToken)
   {

    

         return   await _getModelsByGenderModelAiUseCase.ExecuteAsync(gender, cancellationToken);
        

   }



    public async Task<ICollection<ModelAiResponse>> getModelsByIsStandardModelAiAsync(string isStandard, CancellationToken cancellationToken)
   {

    

         return   await _getModelsByIsStandardModelAiUseCase.ExecuteAsync(isStandard, cancellationToken);
        

   }



    public async Task<ICollection<ModelAiResponse>> getModelsByLanguageAndDialectModelAiAsync(string language, string dialect, CancellationToken cancellationToken)
   {

    

         return   await _getModelsByLanguageAndDialectModelAiUseCase.ExecuteAsync(language, dialect, cancellationToken);
        

   }



    public async Task<ICollection<ModelAiResponse>> getModelsByLanguageDialectTypeModelAiAsync(string language, string dialect, string type, CancellationToken cancellationToken)
   {

    

         return   await _getModelsByLanguageDialectTypeModelAiUseCase.ExecuteAsync(language, dialect, type, cancellationToken);
        

   }



    public async Task<ICollection<ModelAiResponse>> getModelsByLanguageModelAiAsync(string language, CancellationToken cancellationToken)
   {

    

         return   await _getModelsByLanguageModelAiUseCase.ExecuteAsync(language, cancellationToken);
        

   }



    public async Task<ICollection<ModelAiResponse>> getModelsByTypeAndGenderModelAiAsync(string type, string gender, CancellationToken cancellationToken)
   {

    

         return   await _getModelsByTypeAndGenderModelAiUseCase.ExecuteAsync(type, gender, cancellationToken);
        

   }



    public async Task<ICollection<ArrayResponse>> getModelsByTypeModelAiAsync(string type, CancellationToken cancellationToken)
   {

    

         return   await _getModelsByTypeModelAiUseCase.ExecuteAsync(type, cancellationToken);
        

   }



    public async Task<IDictionary<string, object>> getModelSpechStudioModelAiAsync(string lg, CancellationToken cancellationToken)
   {

    

         return   await _getModelSpechStudioModelAiUseCase.ExecuteAsync(lg, cancellationToken);
        

   }



    public async Task<IDictionary<string, object>> getModelTextStudioModelAiAsync(string lg, CancellationToken cancellationToken)
   {

    

         return   await _getModelTextStudioModelAiUseCase.ExecuteAsync(lg, cancellationToken);
        

   }



    public async Task<ModelPropertyValues> getSettingModelAiAsync(string langage, CancellationToken cancellationToken)
   {

    

         return   await _getSettingModelAiUseCase.ExecuteAsync(langage, cancellationToken);
        

   }



    public async Task<ICollection<Item>> getStartStudioModelAiAsync(string lg, CancellationToken cancellationToken)
   {

    

         return   await _getStartStudioModelAiUseCase.ExecuteAsync(lg, cancellationToken);
        

   }



    public async Task<ValueFilterModel> getValueFilterServiceModelAiAsync(string lg, CancellationToken cancellationToken)
   {

    

         return   await _getValueFilterServiceModelAiUseCase.ExecuteAsync(lg, cancellationToken);
        

   }



    public async Task<ModelAiResponse> updateModelAiAsync(string id, ModelAiUpdate body, CancellationToken cancellationToken)
   {

    

         return   await _updateModelAiUseCase.ExecuteAsync(id, body, cancellationToken);
        

   }





}
