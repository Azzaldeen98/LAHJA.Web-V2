
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.AutoGenerator.Interfaces;
using Infrastructure.DataSource.ApiClient2.Base;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public interface IInvoicesRepository :  ITBaseRepository ,  ITScope  
{
public Task<ICollection<Invoice>> GetInvoicesAsync(string customerId, CancellationToken cancellationToken);

public Task<Invoice> GetInvoiceAsync(string id, CancellationToken cancellationToken);

}

