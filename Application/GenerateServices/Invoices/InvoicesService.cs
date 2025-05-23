
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public class InvoicesService : IInvoicesService {


        
     private readonly GetInvoicesUseCase _getInvoicesUseCase;
     private readonly GetInvoiceUseCase _getInvoiceUseCase;


    public InvoicesService(   
            GetInvoicesUseCase getInvoicesUseCase,
            GetInvoiceUseCase getInvoiceUseCase)
    {
                        
          _getInvoicesUseCase=getInvoicesUseCase;
          _getInvoiceUseCase=getInvoiceUseCase;


    }

                

    public async Task<ICollection<Invoice>> getInvoicesAsync(string customerId, CancellationToken cancellationToken)
   {

    

         return   await _getInvoicesUseCase.ExecuteAsync(customerId, cancellationToken);
        

   }



    public async Task<Invoice> getInvoiceAsync(string id, CancellationToken cancellationToken)
   {

    

         return   await _getInvoiceUseCase.ExecuteAsync(id, cancellationToken);
        

   }





}
