
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public interface IPriceService :  ITBaseShareService  
{

    public Task<PriceResponse> createPriceAsync(PriceCreate body, CancellationToken cancellationToken);


    public Task<ICollection<PriceResponse>> getPricesAsync(string productId, bool? active, CancellationToken cancellationToken);


    public Task<PriceResponse> getPriceAsync(string id, CancellationToken cancellationToken);


    public Task searchPriceAsync(PriceSearchOptions body, CancellationToken cancellationToken);


    public Task<PriceResponse> updatePriceAsync(string id, PriceUpdate body, CancellationToken cancellationToken);




}

