
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public class MasterService : IMasterService {


            
 private readonly Active2MasterUseCase _active2MasterUseCase;
 private readonly ActiveMasterUseCase _activeMasterUseCase;
 private readonly AdvertisementsGETMasterUseCase _advertisementsGETMasterUseCase;
 private readonly AdvertisementsPOSTMasterUseCase _advertisementsPOSTMasterUseCase;
 private readonly AdvertisementtabMasterUseCase _advertisementtabMasterUseCase;
 private readonly AdvertisementtabsAllMasterUseCase _advertisementtabsAllMasterUseCase;
 private readonly AdvertisementtabsMasterUseCase _advertisementtabsMasterUseCase;
 private readonly CategoriesGETMasterUseCase _categoriesGETMasterUseCase;
 private readonly CategoriesPOSTMasterUseCase _categoriesPOSTMasterUseCase;
 private readonly DialectMasterUseCase _dialectMasterUseCase;
 private readonly DialectsAllMasterUseCase _dialectsAllMasterUseCase;
 private readonly DialectsMasterUseCase _dialectsMasterUseCase;
 private readonly LanguagesAllMasterUseCase _languagesAllMasterUseCase;
 private readonly LanguagesGETMasterUseCase _languagesGETMasterUseCase;
 private readonly LanguagesPOSTMasterUseCase _languagesPOSTMasterUseCase;
 private readonly TypesGETMasterUseCase _typesGETMasterUseCase;
 private readonly TypesPOSTMasterUseCase _typesPOSTMasterUseCase;


            public MasterService(
Active2MasterUseCase active2MasterUseCase,
ActiveMasterUseCase activeMasterUseCase,
AdvertisementsGETMasterUseCase advertisementsGETMasterUseCase,
AdvertisementsPOSTMasterUseCase advertisementsPOSTMasterUseCase,
AdvertisementtabMasterUseCase advertisementtabMasterUseCase,
AdvertisementtabsAllMasterUseCase advertisementtabsAllMasterUseCase,
AdvertisementtabsMasterUseCase advertisementtabsMasterUseCase,
CategoriesGETMasterUseCase categoriesGETMasterUseCase,
CategoriesPOSTMasterUseCase categoriesPOSTMasterUseCase,
DialectMasterUseCase dialectMasterUseCase,
DialectsAllMasterUseCase dialectsAllMasterUseCase,
DialectsMasterUseCase dialectsMasterUseCase,
LanguagesAllMasterUseCase languagesAllMasterUseCase,
LanguagesGETMasterUseCase languagesGETMasterUseCase,
LanguagesPOSTMasterUseCase languagesPOSTMasterUseCase,
TypesGETMasterUseCase typesGETMasterUseCase,
TypesPOSTMasterUseCase typesPOSTMasterUseCase){
                
      _active2MasterUseCase=active2MasterUseCase;
      _activeMasterUseCase=activeMasterUseCase;
      _advertisementsGETMasterUseCase=advertisementsGETMasterUseCase;
      _advertisementsPOSTMasterUseCase=advertisementsPOSTMasterUseCase;
      _advertisementtabMasterUseCase=advertisementtabMasterUseCase;
      _advertisementtabsAllMasterUseCase=advertisementtabsAllMasterUseCase;
      _advertisementtabsMasterUseCase=advertisementtabsMasterUseCase;
      _categoriesGETMasterUseCase=categoriesGETMasterUseCase;
      _categoriesPOSTMasterUseCase=categoriesPOSTMasterUseCase;
      _dialectMasterUseCase=dialectMasterUseCase;
      _dialectsAllMasterUseCase=dialectsAllMasterUseCase;
      _dialectsMasterUseCase=dialectsMasterUseCase;
      _languagesAllMasterUseCase=languagesAllMasterUseCase;
      _languagesGETMasterUseCase=languagesGETMasterUseCase;
      _languagesPOSTMasterUseCase=languagesPOSTMasterUseCase;
      _typesGETMasterUseCase=typesGETMasterUseCase;
      _typesPOSTMasterUseCase=typesPOSTMasterUseCase;


            }

                

    public async Task<ICollection<AdvertisementView>> active2MasterAsync(string lg, CancellationToken cancellationToken)
   {

    

         return    await _active2MasterUseCase.ExecuteAsync(lg, cancellationToken);
        

   }



    public async Task<ICollection<TypeModelView>> activeMasterAsync(string lg, CancellationToken cancellationToken)
   {

    

         return    await _activeMasterUseCase.ExecuteAsync(lg, cancellationToken);
        

   }



    public async Task<AdvertisementView> advertisementsGETMasterAsync(string id, string lg, CancellationToken cancellationToken)
   {

    

         return    await _advertisementsGETMasterUseCase.ExecuteAsync(id, lg, cancellationToken);
        

   }



    public async Task advertisementsPOSTMasterAsync(string lg, AdvertisementCreate body, CancellationToken cancellationToken)
   {

    

          await _advertisementsPOSTMasterUseCase.ExecuteAsync(lg, body, cancellationToken);
        

   }



    public async Task<AdvertisementTabView> advertisementtabMasterAsync(string id, string lg, CancellationToken cancellationToken)
   {

    

         return    await _advertisementtabMasterUseCase.ExecuteAsync(id, lg, cancellationToken);
        

   }



    public async Task<ICollection<AdvertisementTabView>> advertisementtabsAllMasterAsync(string advertisementId, string lg, CancellationToken cancellationToken)
   {

    

         return    await _advertisementtabsAllMasterUseCase.ExecuteAsync(advertisementId, lg, cancellationToken);
        

   }



    public async Task<AdvertisementTabView> advertisementtabsMasterAsync(string lg, AdvertisementTabCreate body, CancellationToken cancellationToken)
   {

    

         return    await _advertisementtabsMasterUseCase.ExecuteAsync(lg, body, cancellationToken);
        

   }



    public async Task categoriesGETMasterAsync(string name, string lg, CancellationToken cancellationToken)
   {

    

          await _categoriesGETMasterUseCase.ExecuteAsync(name, lg, cancellationToken);
        

   }



    public async Task categoriesPOSTMasterAsync(string lg, CategoryCreate body, CancellationToken cancellationToken)
   {

    

          await _categoriesPOSTMasterUseCase.ExecuteAsync(lg, body, cancellationToken);
        

   }



    public async Task<DialectView> dialectMasterAsync(string languageId, string lg, CancellationToken cancellationToken)
   {

    

         return    await _dialectMasterUseCase.ExecuteAsync(languageId, lg, cancellationToken);
        

   }



    public async Task<ICollection<DialectView>> dialectsAllMasterAsync(string languageId, string lg, CancellationToken cancellationToken)
   {

    

         return    await _dialectsAllMasterUseCase.ExecuteAsync(languageId, lg, cancellationToken);
        

   }



    public async Task<DialectView> dialectsMasterAsync(string lg, DialectCreate body, CancellationToken cancellationToken)
   {

    

         return    await _dialectsMasterUseCase.ExecuteAsync(lg, body, cancellationToken);
        

   }



    public async Task<ICollection<LanguageView>> languagesAllMasterAsync(string lg, CancellationToken cancellationToken)
   {

    

         return    await _languagesAllMasterUseCase.ExecuteAsync(lg, cancellationToken);
        

   }



    public async Task languagesGETMasterAsync(string code, string lg, CancellationToken cancellationToken)
   {

    

          await _languagesGETMasterUseCase.ExecuteAsync(code, lg, cancellationToken);
        

   }



    public async Task languagesPOSTMasterAsync(string lg, LanguageCreate body, CancellationToken cancellationToken)
   {

    

          await _languagesPOSTMasterUseCase.ExecuteAsync(lg, body, cancellationToken);
        

   }



    public async Task<TypeModelView> typesGETMasterAsync(string name, string lg, CancellationToken cancellationToken)
   {

    

         return    await _typesGETMasterUseCase.ExecuteAsync(name, lg, cancellationToken);
        

   }



    public async Task<TypeModelView> typesPOSTMasterAsync(string lg, TypeModelCreate body, CancellationToken cancellationToken)
   {

    

         return    await _typesPOSTMasterUseCase.ExecuteAsync(lg, body, cancellationToken);
        

   }





}
