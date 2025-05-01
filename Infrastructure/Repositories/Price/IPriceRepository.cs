
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public interface IPriceRepository :  ITBaseRepository ,  ITScope  
{
    public Task<ICollection<PriceResponse>> GetPricesAsync(string productId, bool? active, CancellationToken cancellationToken);

    public Task<PriceResponse> CreatePriceAsync(PriceCreate body, CancellationToken cancellationToken);

    public Task<PriceResponse> GetPriceAsync(string id, CancellationToken cancellationToken);

    public Task<PriceResponse> UpdatePriceAsync(string id, PriceUpdate body, CancellationToken cancellationToken);

    public Task SearchAsync(PriceSearchOptions body, CancellationToken cancellationToken);

}

