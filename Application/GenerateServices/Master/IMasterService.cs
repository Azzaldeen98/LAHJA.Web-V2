
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public interface IMasterService :  ITBaseService ,  ITScope  
{

    public Task<ICollection<AdvertisementView>> active2MasterAsync(string lg, CancellationToken cancellationToken);


    public Task<ICollection<TypeModelView>> activeMasterAsync(string lg, CancellationToken cancellationToken);


    public Task<AdvertisementView> advertisementsGETMasterAsync(string id, string lg, CancellationToken cancellationToken);


    public Task advertisementsPOSTMasterAsync(string lg, AdvertisementCreate body, CancellationToken cancellationToken);


    public Task<AdvertisementTabView> advertisementtabMasterAsync(string id, string lg, CancellationToken cancellationToken);


    public Task<ICollection<AdvertisementTabView>> advertisementtabsAllMasterAsync(string advertisementId, string lg, CancellationToken cancellationToken);


    public Task<AdvertisementTabView> advertisementtabsMasterAsync(string lg, AdvertisementTabCreate body, CancellationToken cancellationToken);


    public Task categoriesGETMasterAsync(string name, string lg, CancellationToken cancellationToken);


    public Task categoriesPOSTMasterAsync(string lg, CategoryCreate body, CancellationToken cancellationToken);


    public Task<DialectView> dialectMasterAsync(string languageId, string lg, CancellationToken cancellationToken);


    public Task<ICollection<DialectView>> dialectsAllMasterAsync(string languageId, string lg, CancellationToken cancellationToken);


    public Task<DialectView> dialectsMasterAsync(string lg, DialectCreate body, CancellationToken cancellationToken);


    public Task<ICollection<LanguageView>> languagesAllMasterAsync(string lg, CancellationToken cancellationToken);


    public Task languagesGETMasterAsync(string code, string lg, CancellationToken cancellationToken);


    public Task languagesPOSTMasterAsync(string lg, LanguageCreate body, CancellationToken cancellationToken);


    public Task<TypeModelView> typesGETMasterAsync(string name, string lg, CancellationToken cancellationToken);


    public Task<TypeModelView> typesPOSTMasterAsync(string lg, TypeModelCreate body, CancellationToken cancellationToken);




}

