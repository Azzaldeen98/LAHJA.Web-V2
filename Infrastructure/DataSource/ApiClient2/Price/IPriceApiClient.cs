
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

public interface IPriceApiClient
 :  ITBaseApiClient  
{
public Task<ICollection<PriceResponse>> GetPricesAsync(string productId, bool? active, CancellationToken cancellationToken);

public Task<PriceResponse> CreatePriceAsync(PriceCreate body, CancellationToken cancellationToken);

public Task<PriceResponse> GetPriceAsync(string id, CancellationToken cancellationToken);

public Task<PriceResponse> UpdatePriceAsync(string id, PriceUpdate body, CancellationToken cancellationToken);

public Task SearchAsync(PriceSearchOptions body, CancellationToken cancellationToken);

}

