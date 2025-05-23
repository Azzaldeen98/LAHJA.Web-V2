
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


 public  class MasterRepository : IMasterRepository {

    private readonly IMasterApiClient _apiClient;
    public MasterRepository(IMasterApiClient apiClient){
        _apiClient=apiClient;
    }
                

    public async Task<ICollection<LanguageView>> LanguagesAllAsync(string lg, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.LanguagesAllAsync(lg, cancellationToken);
                

   }


    public async Task LanguagesPOSTAsync(string lg, LanguageCreate body, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.LanguagesPOSTAsync(lg, body, cancellationToken);
                

   }


    public async Task LanguagesGETAsync(string code, string lg, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.LanguagesGETAsync(code, lg, cancellationToken);
                

   }


    public async Task CategoriesGETAsync(string name, string lg, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.CategoriesGETAsync(name, lg, cancellationToken);
                

   }


    public async Task CategoriesPOSTAsync(string lg, CategoryCreate body, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.CategoriesPOSTAsync(lg, body, cancellationToken);
                

   }


    public async Task<TypeModelView> TypesGETAsync(string name, string lg, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.TypesGETAsync(name, lg, cancellationToken);
                

   }


    public async Task<ICollection<TypeModelView>> ActiveAsync(string lg, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.ActiveAsync(lg, cancellationToken);
                

   }


    public async Task<TypeModelView> TypesPOSTAsync(string lg, TypeModelCreate body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.TypesPOSTAsync(lg, body, cancellationToken);
                

   }


    public async Task<DialectView> DialectAsync(string languageId, string lg, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.DialectAsync(languageId, lg, cancellationToken);
                

   }


    public async Task<ICollection<DialectView>> DialectsAllAsync(string languageId, string lg, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.DialectsAllAsync(languageId, lg, cancellationToken);
                

   }


    public async Task<DialectView> DialectsAsync(string lg, DialectCreate body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.DialectsAsync(lg, body, cancellationToken);
                

   }


    public async Task<AdvertisementView> AdvertisementsGETAsync(string id, string lg, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.AdvertisementsGETAsync(id, lg, cancellationToken);
                

   }


    public async Task<ICollection<AdvertisementView>> Active2Async(string lg, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.Active2Async(lg, cancellationToken);
                

   }


    public async Task AdvertisementsPOSTAsync(string lg, AdvertisementCreate body, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.AdvertisementsPOSTAsync(lg, body, cancellationToken);
                

   }


    public async Task<AdvertisementTabView> AdvertisementtabAsync(string id, string lg, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.AdvertisementtabAsync(id, lg, cancellationToken);
                

   }


    public async Task<ICollection<AdvertisementTabView>> AdvertisementtabsAllAsync(string advertisementId, string lg, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.AdvertisementtabsAllAsync(advertisementId, lg, cancellationToken);
                

   }


    public async Task<AdvertisementTabView> AdvertisementtabsAsync(string lg, AdvertisementTabCreate body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.AdvertisementtabsAsync(lg, body, cancellationToken);
                

   }


}

