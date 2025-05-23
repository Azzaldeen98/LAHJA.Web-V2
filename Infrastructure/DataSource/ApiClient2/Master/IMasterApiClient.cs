
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Infrastructure.Share.Invoker;
using AutoMapper;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Share.Invoker;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.DataSource.ApiClient2;


public interface IMasterApiClient :  ITBaseApiClient  
{
    public Task<ICollection<LanguageView>> LanguagesAllAsync(string lg, CancellationToken cancellationToken);

    public Task LanguagesPOSTAsync(string lg, LanguageCreate body, CancellationToken cancellationToken);

    public Task LanguagesGETAsync(string code, string lg, CancellationToken cancellationToken);

    public Task CategoriesGETAsync(string name, string lg, CancellationToken cancellationToken);

    public Task CategoriesPOSTAsync(string lg, CategoryCreate body, CancellationToken cancellationToken);

    public Task<TypeModelView> TypesGETAsync(string name, string lg, CancellationToken cancellationToken);

    public Task<ICollection<TypeModelView>> ActiveAsync(string lg, CancellationToken cancellationToken);

    public Task<TypeModelView> TypesPOSTAsync(string lg, TypeModelCreate body, CancellationToken cancellationToken);

    public Task<DialectView> DialectAsync(string languageId, string lg, CancellationToken cancellationToken);

    public Task<ICollection<DialectView>> DialectsAllAsync(string languageId, string lg, CancellationToken cancellationToken);

    public Task<DialectView> DialectsAsync(string lg, DialectCreate body, CancellationToken cancellationToken);

    public Task<AdvertisementView> AdvertisementsGETAsync(string id, string lg, CancellationToken cancellationToken);

    public Task<ICollection<AdvertisementView>> Active2Async(string lg, CancellationToken cancellationToken);

    public Task AdvertisementsPOSTAsync(string lg, AdvertisementCreate body, CancellationToken cancellationToken);

    public Task<AdvertisementTabView> AdvertisementtabAsync(string id, string lg, CancellationToken cancellationToken);

    public Task<ICollection<AdvertisementTabView>> AdvertisementtabsAllAsync(string advertisementId, string lg, CancellationToken cancellationToken);

    public Task<AdvertisementTabView> AdvertisementtabsAsync(string lg, AdvertisementTabCreate body, CancellationToken cancellationToken);

}

