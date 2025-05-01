
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public interface IInvoicesService :  ITBaseService ,  ITScope  
{

    public Task<ICollection<Invoice>> getInvoicesAsync(string customerId, CancellationToken cancellationToken);


    public Task<Invoice> getInvoiceAsync(string id, CancellationToken cancellationToken);




}

