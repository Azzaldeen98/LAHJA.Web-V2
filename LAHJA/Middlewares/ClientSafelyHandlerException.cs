using Infrastructure.Nswag;
using Microsoft.Extensions.Logging;
using Shared.Exceptions;
using Shared.Exceptions.Base;
using Shared.Exceptions.General;
using Shared.Exceptions.Others;
using Shared.Middleware.HandlerException;

namespace Infrastructure.Middlewares
{

    public interface IClientSafelyHandlerException 
    {
        public Task<T> InvokeAsync<T>(Func<Task<T>> action);
        public Task InvokeAsync(Func<Task> action);
        public void HandleException(Exception ex);
    }

    public class ClientSafelyHandlerException : IClientSafelyHandlerException
    {
        private readonly ILogger<ApiSafelyHandlerMiddleware> _logger;


    
        public ClientSafelyHandlerException(ILogger<ApiSafelyHandlerMiddleware> logger)
        {
            _logger = logger;
        }
        public  async Task InvokeAsync(Func<Task> action)
        {
            try
            {
                 await action();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }


            throw new Exception("An unexpected error occurred while processing the request.");
        }
        public  async Task<T> InvokeAsync<T>(Func<Task<T>> action)
        {

            try
            {
               return await action();

            }catch(Exception ex)
            {
                HandleException(ex);
            }
            //catch (TimeoutExceptionApp ex)
            //{
            //    // معالجة استثناء Timeout
            //    _logger.LogError($"Client Timeout Exception Caught: {ex.Message} | StateCode: {ex.ErrorCode}");
            //}
            //catch (ServiceUnavailableException ex)
            //{
            //    // معالجة استثناء Service Unavailable
            //    _logger.LogError($"Client Service Unavailable Exception Caught: {ex.Message} | StateCode: {ex.ErrorCode}");
            //}
            //catch (TooManyRequestsException ex)
            //{
            //    // معالجة استثناء Too Many Requests
            //    _logger.LogError($"Client Too Many Requests Exception Caught: {ex.Message} | StateCode: {ex.ErrorCode}");
            //}
            //catch (UnauthorizedException ex)
            //{
            //    // معالجة استثناء Unauthorized
            //    _logger.LogError($"Client Unauthorized Exception Caught: {ex.Message} | StateCode: {ex.ErrorCode}");
            //}
            //catch (ForbiddenException ex)
            //{
            //    // معالجة استثناء Forbidden
            //    _logger.LogError($"Client Forbidden Exception Caught: {ex.Message} | StateCode: {ex.ErrorCode}");
            //}
            //catch (NotFoundException ex)
            //{
            //    // معالجة استثناء Not Found
            //    _logger.LogError($"Client Not Found Exception Caught: {ex.Message} | StateCode: {ex.ErrorCode}");
            //}
            //catch (BaseExceptionApp ex)
            //{
            //    // معالجة الاستثناءات العامة الأخرى
            //    _logger.LogError($"Client General Exception Caught: {ex.Message} | StateCode: {ex.ErrorCode}");
            //}
            //catch (Exception ex)
            //{
            //    // التقاط أي استثناء غير متوقع
            //    _logger.LogError($"Client Unexpected Exception Caught: {ex.Message}");
            //}

            throw new Exception("An unexpected error occurred while processing the request.");

        }
        public void HandleException(Exception ex)
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
                case Exception genericEx:
                    _logger.LogError($"Client Unexpected Exception Caught: {genericEx.Message}");
                    break;
            }
        }

    }
}
