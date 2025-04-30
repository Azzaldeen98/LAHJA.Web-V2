
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.AutoGenerator.Interfaces;
using Infrastructure.DataSource.ApiClient2.Base;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public class PaymentRepository : IPaymentRepository {

    private readonly IPaymentApiClient _apiClient;
    public PaymentRepository(IPaymentApiClient apiClient){
        _apiClient=apiClient;
    }
                

    public async Task<ICollection<PaymentMethodResponse>> GetMethodsAsync(CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.GetMethodsAsync(cancellationToken);
                

   }


    public async Task<CustomerResponse> UpdateBillingInformationAsync(BillingInformationRequest body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.UpdateBillingInformationAsync(body, cancellationToken);
                

   }


    public async Task MakePaymentMethodDefaultAsync(string paymentMethodId, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.MakePaymentMethodDefaultAsync(paymentMethodId, cancellationToken);
                

   }


    public async Task DeleteMethodAsync(string id, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.DeleteMethodAsync(id, cancellationToken);
                

   }


    public async Task GetSetupIntentsAsync(CancellationToken cancellationToken)
   {

    
                
      await _apiClient.GetSetupIntentsAsync(cancellationToken);
                

   }


    public async Task CancelAsync(string id, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.CancelAsync(id, cancellationToken);
                

   }


    public async Task ConfirmAsync(string id, CancellationToken cancellationToken)
   {

    
                
      await _apiClient.ConfirmAsync(id, cancellationToken);
                

   }


    public async Task<PaymentResponse> CreatePaymentMethodAsync(PaymentMethodsRequest body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.CreatePaymentMethodAsync(body, cancellationToken);
                

   }


    public async Task<PaymentResponse> CreateCustomerSessionAsync(PaymentMethodsRequest body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.CreateCustomerSessionAsync(body, cancellationToken);
                

   }


}

