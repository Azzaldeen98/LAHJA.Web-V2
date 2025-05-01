
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public class SubscriptionsService : ISubscriptionsService {


            
 private readonly CancelAtEndSubscriptionsUseCase _cancelAtEndSubscriptionsUseCase;
 private readonly CancelSubscriptionUseCase _cancelSubscriptionUseCase;
 private readonly CreateSubscriptionUseCase _createSubscriptionUseCase;
 private readonly GetSubscriptionsUseCase _getSubscriptionsUseCase;
 private readonly GetSubscriptionUseCase _getSubscriptionUseCase;
 private readonly PauseCollectionSubscriptionsUseCase _pauseCollectionSubscriptionsUseCase;
 private readonly RenewSubscriptionsUseCase _renewSubscriptionsUseCase;
 private readonly ResetRequestsSubscriptionsUseCase _resetRequestsSubscriptionsUseCase;
 private readonly ResetSpacesSubscriptionsUseCase _resetSpacesSubscriptionsUseCase;
 private readonly ResumeCollectionSubscriptionsUseCase _resumeCollectionSubscriptionsUseCase;
 private readonly ResumeSubscriptionsUseCase _resumeSubscriptionsUseCase;


            public SubscriptionsService(
CancelAtEndSubscriptionsUseCase cancelAtEndSubscriptionsUseCase,
CancelSubscriptionUseCase cancelSubscriptionUseCase,
CreateSubscriptionUseCase createSubscriptionUseCase,
GetSubscriptionsUseCase getSubscriptionsUseCase,
GetSubscriptionUseCase getSubscriptionUseCase,
PauseCollectionSubscriptionsUseCase pauseCollectionSubscriptionsUseCase,
RenewSubscriptionsUseCase renewSubscriptionsUseCase,
ResetRequestsSubscriptionsUseCase resetRequestsSubscriptionsUseCase,
ResetSpacesSubscriptionsUseCase resetSpacesSubscriptionsUseCase,
ResumeCollectionSubscriptionsUseCase resumeCollectionSubscriptionsUseCase,
ResumeSubscriptionsUseCase resumeSubscriptionsUseCase){
                
      _cancelAtEndSubscriptionsUseCase=cancelAtEndSubscriptionsUseCase;
      _cancelSubscriptionUseCase=cancelSubscriptionUseCase;
      _createSubscriptionUseCase=createSubscriptionUseCase;
      _getSubscriptionsUseCase=getSubscriptionsUseCase;
      _getSubscriptionUseCase=getSubscriptionUseCase;
      _pauseCollectionSubscriptionsUseCase=pauseCollectionSubscriptionsUseCase;
      _renewSubscriptionsUseCase=renewSubscriptionsUseCase;
      _resetRequestsSubscriptionsUseCase=resetRequestsSubscriptionsUseCase;
      _resetSpacesSubscriptionsUseCase=resetSpacesSubscriptionsUseCase;
      _resumeCollectionSubscriptionsUseCase=resumeCollectionSubscriptionsUseCase;
      _resumeSubscriptionsUseCase=resumeSubscriptionsUseCase;


            }

                

    public async Task cancelAtEndSubscriptionsAsync(string id, CancellationToken cancellationToken)
   {

    

          await _cancelAtEndSubscriptionsUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task cancelSubscriptionAsync(string id, CancellationToken cancellationToken)
   {

    

          await _cancelSubscriptionUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task<SubscriptionCreateResponse> createSubscriptionAsync(SubscriptionCreateRequest body, CancellationToken cancellationToken)
   {

    

         return    await _createSubscriptionUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<ICollection<SubscriptionResponse>> getSubscriptionsAsync(CancellationToken cancellationToken)
   {

    

         return    await _getSubscriptionsUseCase.ExecuteAsync(cancellationToken);
        

   }



    public async Task<SubscriptionResponse> getSubscriptionAsync(string id, CancellationToken cancellationToken)
   {

    

         return    await _getSubscriptionUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task pauseCollectionSubscriptionsAsync(string id, SubscriptionUpdateRequest body, CancellationToken cancellationToken)
   {

    

          await _pauseCollectionSubscriptionsUseCase.ExecuteAsync(id, body, cancellationToken);
        

   }



    public async Task renewSubscriptionsAsync(string id, CancellationToken cancellationToken)
   {

    

          await _renewSubscriptionsUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task resetRequestsSubscriptionsAsync(string id, CancellationToken cancellationToken)
   {

    

          await _resetRequestsSubscriptionsUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task resetSpacesSubscriptionsAsync(string id, CancellationToken cancellationToken)
   {

    

          await _resetSpacesSubscriptionsUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task resumeCollectionSubscriptionsAsync(string id, CancellationToken cancellationToken)
   {

    

          await _resumeCollectionSubscriptionsUseCase.ExecuteAsync(id, cancellationToken);
        

   }



    public async Task resumeSubscriptionsAsync(string id, SubscriptionResumeRequest body, CancellationToken cancellationToken)
   {

    

          await _resumeSubscriptionsUseCase.ExecuteAsync(id, body, cancellationToken);
        

   }





}
