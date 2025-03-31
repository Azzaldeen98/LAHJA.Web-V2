using Infrastructure.Nswag;
using Microsoft.Extensions.Logging;
using Shared.Exceptions;
using Shared.Exceptions.Base;
using Shared.Exceptions.General;
using Shared.Exceptions.Others;
using Shared.Middleware.HandlerException;

namespace Infrastructure.Middlewares
{

    public interface IApiSafelyHandlerMiddleware : IExceptionHandlerMiddleware
    {
        public bool ShouldRetry(BaseExceptionApp ex);
        public void HandlerThrowException(string message, int stateCode, ref int attempt, int _maxRetries);
    }
    public class ApiSafelyHandlerMiddleware : ExceptionHandlerMiddleware, IApiSafelyHandlerMiddleware
    {
        private readonly ILogger<ApiSafelyHandlerMiddleware> _logger;

 
        public ApiSafelyHandlerMiddleware(ILogger<ApiSafelyHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public override async Task<T> InvokeAsync<T>(Func<Task<T>> action)
        {
            int _maxRetries = 3;
            int attempt = 0;
            while (attempt < _maxRetries)
            {
                try
                {
                    return await action();
                }
                catch (HttpRequestException ex)
                {



                    HandlerThrowException(ex.Message, (int)ex.StatusCode,ref attempt,_maxRetries);

                    //if (ShouldRetry(GetExceptionTypeByStateCode((int)ex.StatusCode)))
                    //{
                    //    attempt++;
                    //    if (attempt >= _maxRetries)
                    //    {
                    //        ThrowMappedException(ex.Message, (int)ex.StatusCode);
                    //    }
                    //}
                    //else
                    //{
                    //    ThrowMappedException(ex.Message, (int)ex.StatusCode);
                    //}
                
                      
                }
                catch (TaskCanceledException ex) 
                {
                 
                    if (ex.CancellationToken.IsCancellationRequested)
                    {
                        _logger.LogWarning("The task was canceled by the user or application.");
                        throw new ClientTaskCanceledException();
                    }
                    else
                    {
                        attempt++;
                        _logger.LogWarning($"Retrying request ({attempt}/{_maxRetries}) due to timeout.");

                        if (attempt >= _maxRetries)
                        {
                            _logger.LogError("Max retry attempts reached after {attempts} attempts due to timeout.", attempt);
                            throw new TimeoutExceptionApp(ex.Message);

                        }
                    }
                
                }
                catch (ApiException ex)
                {

                    HandlerThrowException(ex.Message, (int)ex.StatusCode, ref attempt, _maxRetries);


                }
                catch (Exception ex)
                {
                    _logger.LogError($"Unexpected error occurred: {ex.Message}", ex);
                    var stateCode = ExtractStateCode(ex.Message);
                    if (stateCode == -1 )
                    {
                        stateCode = DetectErrorTypeByMessage(ex.Message);
                    }
                    HandlerThrowException(ex.Message, stateCode, ref attempt, _maxRetries);
                    //if (ShouldRetry(GetExceptionTypeByStateCode(stateCode)))
                    //{
                    //    attempt++;
                    //    if (attempt >= _maxRetries)
                    //    {
                    //        ThrowMappedException(ex.Message, stateCode);
                    //    }
                    //}
                    //else
                    //{
                    //    ThrowMappedException(ex.Message, stateCode);
                    //}
                }

                await Task.Delay(GetRetryDelay(attempt));
            }

            _logger.LogError($"Max retry attempts reached: {attempt}");

            throw new MaxRetryAttemptsReachedException("Max retry attempts reached.");
        }

        public void HandlerThrowException(string message,int stateCode,ref int attempt,int _maxRetries)
        {

            _logger.LogError($"StatusCode ({stateCode}): {message}");
            if (ShouldRetry(GetExceptionTypeByStateCode(stateCode)))
            {
                attempt++;

                _logger.LogInformation($"Retry Number: {attempt}");


                if (attempt >= _maxRetries)
                {
                    ThrowMappedException(message, stateCode);
                }
            }
            else
            {
                ThrowMappedException(message, stateCode);
            }
        }
        public bool ShouldRetry(BaseExceptionApp ex)
        {

            var retryExceptions = new List<Type>
            {
                typeof(TimeoutExceptionApp),            // Timeout
                typeof(ServiceUnavailableException),    // الخدمة غير متاحة
                typeof(TooManyRequestsException)        // عدد كبير جداً من الطلبات
            };

            return retryExceptions.Contains(ex.GetType());
        }

    }
}
