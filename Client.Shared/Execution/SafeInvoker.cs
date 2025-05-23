using Microsoft.Extensions.Logging;
using Shared.Exceptions.Base;
using Shared.Exceptions.Server;
using Shared.Exceptions.Subscription;
using Shared.Exceptions;
using Shared.Interfaces;
using Shared.Wrapper;
using Client.Shared.UI.ErrorHandling;


namespace Client.Shared.Execution
{

    public interface ISafeInvoker: ITScope
    {
        // This interface is used to safely invoke methods and handle exceptions.
        // It provides methods to execute actions and return results, while logging the process.
        // The HandleExceptionAsync method is used to handle exceptions that occur during the invocation.
        // The InvokeAsync method can be used for both synchronous and asynchronous actions.
    
        public Task<T> InvokeAsync<T>(Func<Task<T>> action);
        public Task<Result> InvokeAsync(Func<Task> action);
        public Task HandleExceptionAsync(Exception ex);
    }

    public class SafeInvoker : ISafeInvoker
    {
        private readonly ILogger<ISafeInvoker> _logger;



        public readonly IErrorHandlingService _errorHandlingService;

        public SafeInvoker(ILogger<ISafeInvoker> logger,
            IErrorHandlingService errorHandlingService)
        {
            _logger = logger;
            _errorHandlingService = errorHandlingService;
        }

        public  async Task<Result> InvokeAsync(Func<Task> action)
        {
            try
            {
                _logger.LogInformation($"Start Executing {action.Method.Name}");

                await action();

                _logger.LogInformation($"End Executing {action.Method.Name}");

                return Result<object>.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,$"Error  Executing {action.Method.Name}");

                await HandleExceptionAsync(ex);
               return Result<object>.Fail(ex.Message); 

            }

        }
        public  async Task<T> InvokeAsync<T>(Func<Task<T>> action)
        {

            try
            {
                _logger.LogInformation($"Start Executing {action.Method.Name}");

                 var result= await action();

                _logger.LogInformation($"End Executing {action.Method.Name}");
                return result;

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Error  Executing {action.Method.Name}");
                await HandleExceptionAsync(ex);
                return default;

            }
  


        }

        public async Task HandleExceptionAsync(Exception ex)
        {
            switch (ex)
            {
                case BadRequestException badEx:
                    _logger.LogError($"🟠 BadRequestException: {badEx.Message} | ErrorCode: {badEx.ErrorCode}");
                    await _errorHandlingService.HandleBadRequestErrorAsync(badEx);
                    break;

                case TimeoutExceptionApp timeoutEx:
                    _logger.LogError($"⏱️ TimeoutExceptionApp: {timeoutEx.Message} | ErrorCode: {timeoutEx.ErrorCode}");
                    await _errorHandlingService.HandleTimeoutErrorAsync(timeoutEx);
                    break;

                case InternalServerException serverEx:
                    _logger.LogError($"🔥 InternalServerException: {serverEx.Message} | ErrorCode: {serverEx.ErrorCode}");
                    await _errorHandlingService.HandleInternalServerErrorAsync(serverEx);
                    break;

                case ServiceUnavailableException serviceEx:
                    _logger.LogError($"🔌 ServiceUnavailableException: {serviceEx.Message} | ErrorCode: {serviceEx.ErrorCode}");
                    await _errorHandlingService.HandleServiceUnavailableErrorAsync(serviceEx);
                    break;

                case TooManyRequestsException tooManyRequestsEx:
                    _logger.LogError($"🚫 TooManyRequestsException: {tooManyRequestsEx.Message} | ErrorCode: {tooManyRequestsEx.ErrorCode}");
                    await _errorHandlingService.HandleTooManyRequestsErrorAsync(tooManyRequestsEx);
                    break;

                case UnauthorizedException unauthorizedEx:
                    _logger.LogError($"🔒 UnauthorizedException: {unauthorizedEx.Message} | ErrorCode: {unauthorizedEx.ErrorCode}");
                    await _errorHandlingService.HandleUnauthorizedErrorAsync(unauthorizedEx);
                    break;

                case ForbiddenException forbiddenEx:
                    _logger.LogError($"🚫 ForbiddenException: {forbiddenEx.Message} | ErrorCode: {forbiddenEx.ErrorCode}");
                    await _errorHandlingService.HandleForbiddenErrorAsync(forbiddenEx);
                    break;

                case NotFoundException notFoundEx:
                    _logger.LogError($"🔍 NotFoundException: {notFoundEx.Message} | ErrorCode: {notFoundEx.ErrorCode}");
                    await _errorHandlingService.HandleNotFoundErrorAsync(notFoundEx);
                    break;

                case SubscriptionUnavailableException subEx:
                    _logger.LogError($"📴 SubscriptionUnavailableException: {subEx.Message} | ErrorCode: {subEx.ErrorCode}");
                    await _errorHandlingService.HandleSubscriptionUnavailableErrorAsync(subEx);
                    break;

                case SubscriptionExpiredException expireEx:
                    _logger.LogError($"📅 SubscriptionExpiredException: {expireEx.Message} | ErrorCode: {expireEx.ErrorCode}");
                    await _errorHandlingService.HandleSubscriptionExpiredErrorAsync(expireEx);
                    break;

                case BaseExceptionApp baseEx:
                    _logger.LogError($"📌 BaseExceptionApp: {baseEx.Message} | ErrorCode: {baseEx.ErrorCode}");
                    break;

                case Exception e:
                    _logger.LogError($"⚠️ General Exception: {e.Message}");
                    break;

                default:
                    _logger.LogError($"❓ Unknown Exception Type: {ex?.GetType().Name} - {ex?.Message}");
                    break;
            }
        }


    }
}
