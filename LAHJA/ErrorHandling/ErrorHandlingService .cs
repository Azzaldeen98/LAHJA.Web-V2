
using LAHJA.Helpers;
using LAHJA.Resources.Messages.Errors;
using Microsoft.Extensions.Localization;
using Shared.Constants.Router;
using Shared.Exceptions;
using Shared.Exceptions.Server;
using Shared.Exceptions.Subscription;
using System.Globalization;
using System.Resources;
using System.Threading.Tasks;

namespace LAHJA.ErrorHandling
{


    public interface IErrorHandlingService
    {
        public Task HandleException(Exception ex);
        public Task HandleUnauthorizedError(UnauthorizedException ex);
        public Task HandleServiceUnavailableError(ServiceUnavailableException ex);
        public Task HandleInternalServerError(InternalServerException ex);
        public Task HandleTooManyRequestsError(TooManyRequestsException ex);
        public Task HandleForbiddenError(ForbiddenException ex);
        public Task HandleSubscriptionUnavailableError(SubscriptionUnavailableException ex);
        public Task HandleSubscriptionExpiredError(SubscriptionExpiredException ex);
        public Task HandleTimeoutError(TimeoutExceptionApp ex);
        public Task HandleBadRequestError(BadRequestException ex);
        public Task HandleNotFoundError(NotFoundException ex);
    }


    public class ErrorHandlingService : IErrorHandlingService
    {

        private readonly IUserActionService userActionService;
        private readonly CustomStringLocalizer localizerHttpError;
        private readonly CustomStringLocalizer localizerShared;
        public ErrorHandlingService(IUserActionService userActionService)
        {
            this.userActionService = userActionService;
            localizerHttpError = new CustomStringLocalizer("LAHJA.Resources.Messages.Errors.HttpMessageErrors");
            localizerShared = new CustomStringLocalizer("LAHJA.Resources.SharedResource");
         
            
        }


        public async Task HandleException(Exception ex)
        {
            //throw new NotImplementedException();
        }

        public async Task HandleTooManyRequestsError(TooManyRequestsException? ex = null)
        {
            var message = localizerHttpError.GetLocalizedString("TooManyRequests409");
            var result = await userActionService.ShowMessageBox(message:message, yesText: localizerShared.GetLocalizedString("yes"), noText: localizerShared.GetLocalizedString("no"));
            if (result == true) { }
            else { }
        }
        public async Task HandleServiceUnavailableError(ServiceUnavailableException? ex = null)
        {
            var message = localizerHttpError.GetLocalizedString("ServiceUnavailable503");
            var result = await userActionService.ShowMessageBox(message:message, yesText: localizerShared.GetLocalizedString("yes"), noText: localizerShared.GetLocalizedString("no"));
            if (result == true) { }
            else { }
        }     
        public async Task HandleForbiddenError(ForbiddenException? ex = null)
        {
            var message = localizerHttpError.GetLocalizedString("Forbidden403");
            var result = await userActionService.ShowMessageBox(message: message, yesText: localizerShared.GetLocalizedString("yes"), noText: localizerShared.GetLocalizedString("no"));
            if (result == true) { }
            else { }
        }

        public async Task HandleInternalServerError(InternalServerException? ex = null)
        {
            var message = localizerHttpError.GetLocalizedString("InternalServer500");
            var result = await userActionService.ShowMessageBox(message: message, yesText: localizerShared.GetLocalizedString("yes"), noText: localizerShared.GetLocalizedString("no"));
            if (result == true) { }
            else { }
        }

        public async Task HandleUnauthorizedError(UnauthorizedException? ex = null)
        {
            userActionService.NavigationTo($"{RouterPage.LOGOUT}/");
        }

        public async Task HandleSubscriptionUnavailableError(SubscriptionUnavailableException? ex=null)
        {
     
            var message = localizerHttpError.GetLocalizedString("SubscriptionUnavailable904");
            var result = await userActionService.ShowMessageBox(message: message, yesText: localizerShared.GetLocalizedString("yes"),noText: localizerShared.GetLocalizedString("no"));
            if (result == true) {
                userActionService.NavigationTo(RouterPage.PLANS);
            }
            else { }
            
        }

        public async Task HandleTimeoutError(TimeoutExceptionApp? ex = null)
        {
            var message = localizerHttpError.GetLocalizedString("GatewayTimeout504");
            userActionService.ShowSnackBar(message);
        }

        public async Task HandleNotFoundError(NotFoundException? ex = null)
        {
            var message = localizerHttpError.GetLocalizedString("NotFound404");
            userActionService.ShowSnackBar(message);
        }

        public async Task HandleSubscriptionExpiredError(SubscriptionExpiredException? ex = null)
        {
            var message = localizerHttpError.GetLocalizedString("SubscriptionExpired905");
            var result = await userActionService.ShowMessageBox(message, yesText: localizerShared.GetLocalizedString("yes"), noText: localizerShared.GetLocalizedString("no"));
            if (result == true) {
                userActionService.NavigationTo(RouterPage.PLANS);
            }
            else { }
            
        }

        public async Task HandleBadRequestError(BadRequestException ex)
        {
            var message = localizerHttpError.GetLocalizedString("BadRequest400");
            var result = await userActionService.ShowMessageBox(message: message, yesText: localizerShared.GetLocalizedString("yes"), noText: localizerShared.GetLocalizedString("no"));
            if (result == true)
            {
                //userActionService.NavigationTo(RouterPage.PLANS);
            }
            else { }
        }
    }
}
