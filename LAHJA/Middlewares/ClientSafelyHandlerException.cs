using Domain.Wrapper;
using LAHJA.Helpers;
using Shared.Exceptions;
using Shared.Exceptions.Base;

namespace Infrastructure.Middlewares
{

    public interface IClientSafelyHandlerException 
    {
        public Task<T> InvokeAsync<T>(Func<Task<T>> action);
        public Task<Result<object>> InvokeAsync(Func<Task> action);
        public void HandleException(BaseExceptionApp ex);
    }

    public class ClientSafelyHandlerException : IClientSafelyHandlerException
    {
        private readonly ILogger<ApiSafelyHandlerMiddleware> _logger;

        public readonly IBuildActionsInTakeCaseOfErrors buildActions;

        public ClientSafelyHandlerException(ILogger<ApiSafelyHandlerMiddleware> logger, IBuildActionsInTakeCaseOfErrors buildActions)
        {
            _logger = logger;
            this.buildActions = buildActions;
        }
        public  async Task<Result<object>> InvokeAsync(Func<Task> action)
        {
            try
            {
                await action();

                return Result<object>.Success();
            }
            catch (BaseExceptionApp ex)
            {
                HandleException(ex);
            }
            catch (Exception e)
            {
                throw;
            }


            return Result<object>.Fail("An unexpected error occurred while processing the request.");
        }
        public  async Task<T> InvokeAsync<T>(Func<Task<T>> action)
        {

            try
            {
               return await action();
                //if (result is Result<T>)
                //    return  result as Result<T>;
                //else
                //    return Result<T>.Success(result);

            }
            catch(BaseExceptionApp ex)
            {
                HandleException(ex);
                throw;

            }
            catch (Exception e)
            {
                throw;
            }


            //return Result<T>.Fail();

        }

        public void HandleException(BaseExceptionApp  ex)
        {
            switch (ex)
            {
                case TimeoutExceptionApp timeoutEx:
                    _logger.LogError($"Client Timeout Exception Caught: {timeoutEx.Message} | StateCode: {timeoutEx.ErrorCode}");
                    break;
                case ServiceUnavailableException serviceEx:
                    _logger.LogError($"Client Service Unavailable Exception Caught: {serviceEx.Message} | StateCode: {serviceEx.ErrorCode}");
                    break;
                case TooManyRequestsException tooManyRequestsEx:
                    _logger.LogError($"Client Too Many Requests Exception Caught: {tooManyRequestsEx.Message} | StateCode: {tooManyRequestsEx.ErrorCode}");
                    break;
                case UnauthorizedException unauthorizedEx:
                    _logger.LogError($"Client Unauthorized Exception Caught: {unauthorizedEx.Message} | StateCode: {unauthorizedEx.ErrorCode}");
                    buildActions.HandleUnauthorizedError(unauthorizedEx);
                    break;
                case ForbiddenException forbiddenEx:
                    _logger.LogError($"Client Forbidden Exception Caught: {forbiddenEx.Message} | StateCode: {forbiddenEx.ErrorCode}");
                    break;
                case NotFoundException notFoundEx:
                    _logger.LogError($"Client Not Found Exception Caught: {notFoundEx.Message} | StateCode: {notFoundEx.ErrorCode}");
                    break;
                case BaseExceptionApp baseEx:
                    _logger.LogError($"Client General Exception Caught: {baseEx.Message} | StateCode: {baseEx.ErrorCode}");
                    break;
                default:
                    _logger.LogError(ex?.Message);
                    break;

                //case ExceptiongenericEx:
                //    _logger.LogError($"Client Unexpected Exception Caught: {genericEx.Message}");
                //    break;
            }
        }

   
    }
}
