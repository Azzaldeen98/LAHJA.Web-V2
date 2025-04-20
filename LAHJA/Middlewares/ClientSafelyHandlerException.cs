using Domain.Wrapper;
using LAHJA.ErrorHandling;
using LAHJA.Helpers;
using Shared.Exceptions;
using Shared.Exceptions.Base;
using Shared.Exceptions.Server;
using Shared.Exceptions.Subscription;
using System.Threading.Tasks;

namespace Infrastructure.Middlewares
{

    public interface IClientSafelyHandlerException 
    {
        public Task<T> InvokeAsync<T>(Func<Task<T>> action);
        public Task<Result<object>> InvokeAsync(Func<Task> action);
        public Task HandleException(Exception ex);
    }

    public class ClientSafelyHandlerException : IClientSafelyHandlerException
    {
        private readonly ILogger<ClientSafelyHandlerException> _logger;

        public readonly IErrorHandlingService errorHandlingService;

        public ClientSafelyHandlerException(ILogger<ClientSafelyHandlerException> logger,
            IErrorHandlingService errorHandlingService)
        {
            _logger = logger;
            this.errorHandlingService = errorHandlingService;
        }

        public  async Task<Result<object>> InvokeAsync(Func<Task> action)
        {
            try
            {
                await action();

                return Result<object>.Success();
            }
            catch (Exception ex)
            {
               await HandleException(ex);
                return default;

            }
            //catch (Exception e)
            //{
            //    return default;
            //}


            //return Result<object>.Fail("An unexpected error occurred while processing the request.");
        }
        public  async Task<T> InvokeAsync<T>(Func<Task<T>> action)
        {

            try
            {
               return await action();

            }
            catch(Exception ex)
            {
                await HandleException(ex);
                return default;

            }
            //catch (Exception e)
            //{
            //    return default;
            //}


        }

        public async Task HandleException(Exception ex)
        {
            switch (ex)
            {
                case BadRequestException badEx:
                    _logger.LogError($"Client Timeout Exception Caught: {badEx.Message} | StateCode: {badEx.ErrorCode}");
                    await errorHandlingService.HandleBadRequestError(badEx);
                    break;          
                
                case TimeoutExceptionApp timeoutEx:
                    _logger.LogError($"Client Timeout Exception Caught: {timeoutEx.Message} | StateCode: {timeoutEx.ErrorCode}");
                    await errorHandlingService.HandleTimeoutError(timeoutEx);
                    break;  
                    
                case InternalServerException serverEx:
                    _logger.LogError($"Internal Server Exception Caught: {serverEx.Message} | StateCode: {serverEx.ErrorCode}");
                    await errorHandlingService.HandleInternalServerError(serverEx);
                    break;

                case ServiceUnavailableException serviceEx:
                    _logger.LogError($"Client Service Unavailable Exception Caught: {serviceEx.Message} | StateCode: {serviceEx.ErrorCode}");
                    await errorHandlingService.HandleServiceUnavailableError(serviceEx);
                    break;

                case TooManyRequestsException tooManyRequestsEx:
                    _logger.LogError($"Client Too Many Requests Exception Caught: {tooManyRequestsEx.Message} | StateCode: {tooManyRequestsEx.ErrorCode}");
                    await errorHandlingService.HandleTooManyRequestsError(tooManyRequestsEx);
                    break;

                case UnauthorizedException unauthorizedEx:
                    _logger.LogError($"Client Unauthorized Exception Caught: {unauthorizedEx.Message} | StateCode: {unauthorizedEx.ErrorCode}");
                    await errorHandlingService.HandleUnauthorizedError(unauthorizedEx);
                    break;

                case ForbiddenException forbiddenEx:
                    _logger.LogError($"Client Forbidden Exception Caught: {forbiddenEx.Message} | StateCode: {forbiddenEx.ErrorCode}");
                    await errorHandlingService.HandleForbiddenError(forbiddenEx);
                    break;

                case NotFoundException notFoundEx:
                    _logger.LogError($"Client Not Found Exception Caught: {notFoundEx.Message} | StateCode: {notFoundEx.ErrorCode}");
                    await errorHandlingService.HandleNotFoundError(notFoundEx);
                    break;


                case SubscriptionUnavailableException subException:
                    _logger.LogError($"Subscription Unavailable Exception Caught: {subException.Message} | StateCode: {subException.ErrorCode}");
                    await errorHandlingService.HandleSubscriptionUnavailableError(subException);
                    break;

                case SubscriptionExpiredException expireSubEx:
                    _logger.LogError($"Subscription Unavailable Exception Caught: {expireSubEx.Message} | StateCode: {expireSubEx.ErrorCode}");
                    await errorHandlingService.HandleSubscriptionExpiredError(expireSubEx);
                    break;


                ///-------------------------------------------------------------------------------------------
                case BaseExceptionApp baseEx:
                    _logger.LogError($"Client Base Exception App Caught: {baseEx.Message} | StateCode: {baseEx.ErrorCode}");
                    break;

                case Exception e:
                    _logger.LogError($"Client General Exception Caught: {e.Message}");
                    break;

                default:
                    _logger.LogError(ex?.Message);
                    break;

          
            }
        }

   
    }
}
