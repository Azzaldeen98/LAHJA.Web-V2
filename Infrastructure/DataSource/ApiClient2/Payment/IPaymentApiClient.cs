
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


public interface IPaymentApiClient :  ITBaseApiClient  
{
    public Task<ICollection<PaymentMethodResponse>> GetMethodsAsync(CancellationToken cancellationToken);

    public Task<CustomerResponse> UpdateBillingInformationAsync(BillingInformationRequest body, CancellationToken cancellationToken);

    public Task MakePaymentMethodDefaultAsync(string paymentMethodId, CancellationToken cancellationToken);

    public Task DeleteMethodAsync(string id, CancellationToken cancellationToken);

    public Task GetSetupIntentsAsync(CancellationToken cancellationToken);

    public Task CancelAsync(string id, CancellationToken cancellationToken);

    public Task ConfirmAsync(string id, CancellationToken cancellationToken);

    public Task<PaymentResponse> CreatePaymentMethodAsync(PaymentMethodsRequest body, CancellationToken cancellationToken);

    public Task<PaymentResponse> CreateCustomerSessionAsync(PaymentMethodsRequest body, CancellationToken cancellationToken);

}

