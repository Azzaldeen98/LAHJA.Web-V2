
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public interface IPaymentService :  ITBaseShareService  
{

    public Task cancelPaymentAsync(string id, CancellationToken cancellationToken);


    public Task confirmPaymentAsync(string id, CancellationToken cancellationToken);


    public Task<PaymentResponse> createCustomerSessionPaymentAsync(PaymentMethodsRequest body, CancellationToken cancellationToken);


    public Task<PaymentResponse> createPaymentMethodAsync(PaymentMethodsRequest body, CancellationToken cancellationToken);


    public Task deleteMethodPaymentAsync(string id, CancellationToken cancellationToken);


    public Task<ICollection<PaymentMethodResponse>> getMethodsPaymentAsync(CancellationToken cancellationToken);


    public Task getSetupIntentsPaymentAsync(CancellationToken cancellationToken);


    public Task makePaymentMethodDefaultAsync(string paymentMethodId, CancellationToken cancellationToken);


    public Task<CustomerResponse> updateBillingInformationPaymentAsync(BillingInformationRequest body, CancellationToken cancellationToken);




}

