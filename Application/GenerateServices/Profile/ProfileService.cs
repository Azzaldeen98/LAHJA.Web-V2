
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public class ProfileService : IProfileService {


        
     private readonly GetCustomerProfileUseCase _getCustomerProfileUseCase;
     private readonly ModelAisProfileUseCase _modelAisProfileUseCase;
     private readonly RequestsServiceProfileUseCase _requestsServiceProfileUseCase;
     private readonly RequestsSubscriptionProfileUseCase _requestsSubscriptionProfileUseCase;
     private readonly ServicesModelAiProfileUseCase _servicesModelAiProfileUseCase;
     private readonly ServicesProfileUseCase _servicesProfileUseCase;
     private readonly SpacesSubscriptionProfileUseCase _spacesSubscriptionProfileUseCase;
     private readonly SpaceSubscriptionProfileUseCase _spaceSubscriptionProfileUseCase;
     private readonly SubscriptionsProfileUseCase _subscriptionsProfileUseCase;
     private readonly UpdateProfileUseCase _updateProfileUseCase;
     private readonly UserProfileUseCase _userProfileUseCase;


    public ProfileService(   
            GetCustomerProfileUseCase getCustomerProfileUseCase,
            ModelAisProfileUseCase modelAisProfileUseCase,
            RequestsServiceProfileUseCase requestsServiceProfileUseCase,
            RequestsSubscriptionProfileUseCase requestsSubscriptionProfileUseCase,
            ServicesModelAiProfileUseCase servicesModelAiProfileUseCase,
            ServicesProfileUseCase servicesProfileUseCase,
            SpacesSubscriptionProfileUseCase spacesSubscriptionProfileUseCase,
            SpaceSubscriptionProfileUseCase spaceSubscriptionProfileUseCase,
            SubscriptionsProfileUseCase subscriptionsProfileUseCase,
            UpdateProfileUseCase updateProfileUseCase,
            UserProfileUseCase userProfileUseCase)
    {
                        
          _getCustomerProfileUseCase=getCustomerProfileUseCase;
          _modelAisProfileUseCase=modelAisProfileUseCase;
          _requestsServiceProfileUseCase=requestsServiceProfileUseCase;
          _requestsSubscriptionProfileUseCase=requestsSubscriptionProfileUseCase;
          _servicesModelAiProfileUseCase=servicesModelAiProfileUseCase;
          _servicesProfileUseCase=servicesProfileUseCase;
          _spacesSubscriptionProfileUseCase=spacesSubscriptionProfileUseCase;
          _spaceSubscriptionProfileUseCase=spaceSubscriptionProfileUseCase;
          _subscriptionsProfileUseCase=subscriptionsProfileUseCase;
          _updateProfileUseCase=updateProfileUseCase;
          _userProfileUseCase=userProfileUseCase;


    }

                

    public async Task<CustomerResponse> getCustomerProfileAsync(CancellationToken cancellationToken)
   {

    

         return   await _getCustomerProfileUseCase.ExecuteAsync(cancellationToken);
        

   }



    public async Task<ICollection<ModelAiResponse>> modelAisProfileAsync(CancellationToken cancellationToken)
   {

    

         return   await _modelAisProfileUseCase.ExecuteAsync(cancellationToken);
        

   }



    public async Task<ICollection<RequestResponse>> requestsServiceProfileAsync(string serviceId, CancellationToken cancellationToken)
   {

    

         return   await _requestsServiceProfileUseCase.ExecuteAsync(serviceId, cancellationToken);
        

   }



    public async Task<ICollection<RequestResponse>> requestsSubscriptionProfileAsync(string subscriptionId, CancellationToken cancellationToken)
   {

    

         return   await _requestsSubscriptionProfileUseCase.ExecuteAsync(subscriptionId, cancellationToken);
        

   }



    public async Task<ICollection<ServiceResponse>> servicesModelAiProfileAsync(string modelAiId, CancellationToken cancellationToken)
   {

    

         return   await _servicesModelAiProfileUseCase.ExecuteAsync(modelAiId, cancellationToken);
        

   }



    public async Task<ICollection<ServiceResponse>> servicesProfileAsync(CancellationToken cancellationToken)
   {

    

         return   await _servicesProfileUseCase.ExecuteAsync(cancellationToken);
        

   }



    public async Task<ICollection<SpaceResponse>> spacesSubscriptionProfileAsync(string subscriptionId, CancellationToken cancellationToken)
   {

    

         return   await _spacesSubscriptionProfileUseCase.ExecuteAsync(subscriptionId, cancellationToken);
        

   }



    public async Task<SpaceResponse> spaceSubscriptionProfileAsync(string subscriptionId, string spaceId, CancellationToken cancellationToken)
   {

    

         return   await _spaceSubscriptionProfileUseCase.ExecuteAsync(subscriptionId, spaceId, cancellationToken);
        

   }



    public async Task<ICollection<SubscriptionResponse>> subscriptionsProfileAsync(CancellationToken cancellationToken)
   {

    

         return   await _subscriptionsProfileUseCase.ExecuteAsync(cancellationToken);
        

   }



    public async Task updateProfileAsync(UserRequest body, CancellationToken cancellationToken)
   {

    

         await _updateProfileUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<UserResponse> userProfileAsync(CancellationToken cancellationToken)
   {

    

         return   await _userProfileUseCase.ExecuteAsync(cancellationToken);
        

   }





}
