
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.AutoGenerator.Interfaces;
using Infrastructure.DataSource.ApiClient2.Base;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public class InvoicesRepository : IInvoicesRepository {

    private readonly IInvoicesApiClient _apiClient;
    public InvoicesRepository(IInvoicesApiClient apiClient){
        _apiClient=apiClient;
    }
                

    public async Task<ICollection<Invoice>> GetInvoicesAsync(string customerId, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetInvoicesAsync(customerId, cancellationToken);
                

   }


    public async Task<Invoice> GetInvoiceAsync(string id, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetInvoiceAsync(id, cancellationToken);
                

   }


}

