
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Infrastructure.Shared.ApiInvoker;
using AutoMapper;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Shared.ApiInvoker;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.DataSource.ApiClient2;


public interface IInvoicesApiClient :  ITBaseApiClient  
{
    public Task<ICollection<Invoice>> GetInvoicesAsync(string customerId, CancellationToken cancellationToken);

    public Task<Invoice> GetInvoiceAsync(string id, CancellationToken cancellationToken);

}

