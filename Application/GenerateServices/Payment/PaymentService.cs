
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public class PaymentService : IPaymentService {


        
     private readonly CancelPaymentUseCase _cancelPaymentUseCase;
     private readonly ConfirmPaymentUseCase _confirmPaymentUseCase;
     private readonly CreateCustomerSessionPaymentUseCase _createCustomerSessionPaymentUseCase;
     private readonly CreatePaymentMethodUseCase _createPaymentMethodUseCase;
     private readonly DeleteMethodPaymentUseCase _deleteMethodPaymentUseCase;
     private readonly GetMethodsPaymentUseCase _getMethodsPaymentUseCase;
     private readonly GetSetupIntentsPaymentUseCase _getSetupIntentsPaymentUseCase;
     private readonly MakePaymentMethodDefaultUseCase _makePaymentMethodDefaultUseCase;
     private readonly UpdateBillingInformationPaymentUseCase _updateBillingInformationPaymentUseCase;


    public PaymentService(   
            CancelPaymentUseCase cancelPaymentUseCase,
            ConfirmPaymentUseCase confirmPaymentUseCase,
            CreateCustomerSessionPaymentUseCase createCustomerSessionPaymentUseCase,
            CreatePaymentMethodUseCase createPaymentMethodUseCase,
            DeleteMethodPaymentUseCase deleteMethodPaymentUseCase,
            GetMethodsPaymentUseCase getMethodsPaymentUseCase,
            GetSetupIntentsPaymentUseCase getSetupIntentsPaymentUseCase,
            MakePaymentMethodDefaultUseCase makePaymentMethodDefaultUseCase,
            UpdateBillingInformationPaymentUseCase updateBillingInformationPaymentUseCase)
    {
                        
          _cancelPaymentUseCase=cancelPaymentUseCase;
          _confirmPaymentUseCase=confirmPaymentUseCase;
          _createCustomerSessionPaymentUseCase=createCustomerSessionPaymentUseCase;
          _createPaymentMethodUseCase=createPaymentMethodUseCase;
          _deleteMethodPaymentUseCase=deleteMethodPaymentUseCase;
          _getMethodsPaymentUseCase=getMethodsPaymentUseCase;
          _getSetupIntentsPaymentUseCase=getSetupIntentsPaymentUseCase;
          _makePaymentMethodDefaultUseCase=makePaymentMethodDefaultUseCase;
          _updateBillingInformationPaymentUseCase=updateBillingInformationPaymentUseCase;


    }

                

    public async Task cancelPaymentAsync(string id, CancellationToken cancellationToken)
   {

    

         await _cancelPaymentUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task confirmPaymentAsync(string id, CancellationToken cancellationToken)
   {

    

         await _confirmPaymentUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task<PaymentResponse> createCustomerSessionPaymentAsync(PaymentMethodsRequest body, CancellationToken cancellationToken)
   {

    

         return   await _createCustomerSessionPaymentUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<PaymentResponse> createPaymentMethodAsync(PaymentMethodsRequest body, CancellationToken cancellationToken)
   {

    

         return   await _createPaymentMethodUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task deleteMethodPaymentAsync(string id, CancellationToken cancellationToken)
   {

    

         await _deleteMethodPaymentUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task<ICollection<PaymentMethodResponse>> getMethodsPaymentAsync(CancellationToken cancellationToken)
   {

    

         return   await _getMethodsPaymentUseCase.ExecuteAsync(cancellationToken);
        

   }



    public async Task getSetupIntentsPaymentAsync(CancellationToken cancellationToken)
   {

    

         await _getSetupIntentsPaymentUseCase.ExecuteAsync(cancellationToken);
        

   }



    public async Task makePaymentMethodDefaultAsync(string paymentMethodId, CancellationToken cancellationToken)
   {

    

         await _makePaymentMethodDefaultUseCase.ExecuteAsync(paymentMethodId, cancellationToken);
        

   }



    public async Task<CustomerResponse> updateBillingInformationPaymentAsync(BillingInformationRequest body, CancellationToken cancellationToken)
   {

    

         return   await _updateBillingInformationPaymentUseCase.ExecuteAsync(body, cancellationToken);
        

   }





}
