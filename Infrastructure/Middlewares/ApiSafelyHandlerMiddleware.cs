using Infrastructure.Nswag;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Shared.Exceptions;
using Shared.Exceptions.Base;
using Shared.Exceptions.General;
using Shared.Exceptions.Others;
using Shared.Exceptions.Server;
using Shared.Middleware.HandlerException;
using System.Threading;

namespace Infrastructure.Middlewares
{

    public interface IApiSafelyHandlerMiddleware 
    {
        public bool IsShouldRetry(BaseExceptionApp ex);
        public Task<T> InvokeAsync<T>(Func<Task<T>> action, CancellationToken cancellationToken, int _maxRetries = 3);
        public Task<T> InvokeAsync<T>(Func<Task<T>> action, int _maxRetries = 3);
        public Task InvokeAsync(Func<Task> action);
        public Task InvokeAsync(Func<Task> action, CancellationToken cancellationToken);
        public  void HandleThrowException(string message, int stateCode, ref int attempt, int _maxRetries);



    }
    public class ApiSafelyHandlerMiddleware : ExceptionHandlerMiddleware, IApiSafelyHandlerMiddleware
    {
        private readonly ILogger<ApiSafelyHandlerMiddleware> _logger;
        private readonly RequestDelegate _next;
        private readonly int _maxRetries = 3;
        public ApiSafelyHandlerMiddleware(ILogger<ApiSafelyHandlerMiddleware> logger)
        {
            _logger = logger;
            //_next = next;
        }

        //public async Task InvokeAsync(HttpContext context, CancellationToken cancellationToken)
        //{
        //    int attempt = 0;

        //    while (attempt < _maxRetries)
        //    {
        //        try
        //        {

        //            if (cancellationToken.IsCancellationRequested)
        //            {
        //                _logger.LogWarning($"Attempt {attempt + 1}: Operation was cancelled before starting the request.");
        //                throw new OperationCanceledException(cancellationToken);
        //            }


        //            await _next(context);
        //            return;

        //        }
        //        catch (HttpRequestException ex)
        //        {
        //            _logger.LogWarning($"Attempt {attempt + 1}: HttpRequestException occurred.");
        //            HandleHttpRequestException(ex, ref attempt, _maxRetries);
        //        }
        //        catch (TaskCanceledException ex)
        //        {
        //            _logger.LogWarning($"Attempt {attempt + 1}: TaskCanceledException occurred.");
        //            HandleHClientTaskCanceledException(ex, ref attempt, _maxRetries);
        //        }
        //        catch (OperationCanceledException ex)
        //        {
        //            _logger.LogWarning($"Attempt {attempt + 1}: Operation was cancelled during execution.");
        //            throw;
        //        }
        //        catch (ApiException ex)
        //        {
        //            _logger.LogError($"Attempt {attempt + 1}: ApiException error occurred: {ex.Message}", ex);
        //            HandleThrowException(ex.Message, (int)ex.StatusCode, ref attempt, _maxRetries);
        //        }
        //        catch (Exception ex)
        //        {
        //            _logger.LogError($"Attempt {attempt + 1}: Unexpected exception occurred: {ex.Message}", ex);
        //            HandleException(ex, ref attempt, _maxRetries);
        //        }


        //        if (cancellationToken.IsCancellationRequested)
        //        {
        //            _logger.LogWarning($"Attempt {attempt + 1}: Operation was cancelled before retry delay.");
        //            throw new OperationCanceledException(cancellationToken);
        //        }


        //        await Task.Delay(GetRetryDelay(attempt), cancellationToken);
        //    }

        //    _logger.LogError($"Max retry attempts reached: {attempt}");

        //    throw new MaxRetryAttemptsReachedException("Max retry attempts reached.");
        //}



        public override async Task InvokeAsync(Func<Task> action) {


                     await InvokeAsync<object?>(async() =>
                     {
                         await action();
                         return  null;
                     }, CancellationToken.None);
              
        }

        public override async Task InvokeAsync(Func<Task> action, CancellationToken cancellationToke)
        {
            await InvokeAsync<object?>(async () =>
            {
                await action();
                return null;
            }, cancellationToke);
        }
       

        public override async Task<T> InvokeAsync<T>(Func<Task<T>> action, int _maxRetries = 3)
        {
            return await InvokeAsync(action, CancellationToken.None, _maxRetries);
        }
        public override async Task<T> InvokeAsync<T>(Func<Task<T>> action,CancellationToken cancellationToken,int _maxRetries = 3)
        {
            int attempt = 0;

            while (attempt < _maxRetries)
            {
                try
                {
               
                    if (cancellationToken.IsCancellationRequested)
                    {
                        _logger.LogWarning($"Attempt {attempt + 1}: Operation was cancelled before starting the request.");
                        throw new OperationCanceledException(cancellationToken);
                    }

           
                    return await action();
                }
                catch (HttpRequestException ex)
                {
                    _logger.LogWarning($"Attempt {attempt + 1}: HttpRequestException occurred.");
                    HandleHttpRequestException(ex, ref attempt, _maxRetries);
                }
                catch (TaskCanceledException ex)
                {
                    _logger.LogWarning($"Attempt {attempt + 1}: TaskCanceledException occurred.");
                    HandleHClientTaskCanceledException(ex, ref attempt, _maxRetries);
                }
                catch (OperationCanceledException ex)
                {
                    _logger.LogWarning($"Attempt {attempt + 1}: Operation was cancelled during execution.");
                    throw;
                }
                catch (ApiException ex)
                {
                    _logger.LogError($"Attempt {attempt + 1}: ApiException error occurred: {ex.Message}", ex);
                    HandleThrowException(ex.Message, (int)ex.StatusCode, ref attempt, _maxRetries);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Attempt {attempt + 1}: Unexpected exception occurred: {ex.Message}", ex);
                    HandleException(ex, ref attempt, _maxRetries);
                }

           
                if (cancellationToken.IsCancellationRequested)
                {
                    _logger.LogWarning($"Attempt {attempt + 1}: Operation was cancelled before retry delay.");
                    throw new OperationCanceledException(cancellationToken);
                }

             
                await Task.Delay(GetRetryDelay(attempt), cancellationToken);
            }

            _logger.LogError($"Max retry attempts reached: {attempt}");

            throw new MaxRetryAttemptsReachedException("Max retry attempts reached.");
        }


        private void HandleException(Exception ex, ref int attempt, int _maxRetries)
        {
            _logger.LogError($"Unexpected error occurred: {ex.Message}", ex);
            var stateCode = ExtractStateCode(ex.Message);
            if (stateCode == -1)
            {
                stateCode = DetectExceptionTypeByMessage(ex.Message);
            }
            HandleThrowException(ex.Message, stateCode, ref attempt, _maxRetries);
        }
        private void HandleHClientTaskCanceledException(TaskCanceledException ex, ref int attempt, int _maxRetries)
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
        private void HandleHttpRequestException(HttpRequestException ex, ref int attempt,int _maxRetries)
        {
            _logger.LogError($"HttpRequestException: {ex.Message}");
            HandleThrowException(ex.Message, (int)ex.StatusCode, ref attempt, _maxRetries);
        }

        public void HandleThrowException(string message,int stateCode,ref int attempt,int _maxRetries)
        {

      
            _logger.LogError($"StatusCode ({stateCode}): {message}");
            if (IsShouldRetry(GetExceptionTypeByStateCode(stateCode)))
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

        public bool IsShouldRetry(BaseExceptionApp ex)
        {

            var retryExceptions = new List<Type>
            {
                typeof(BadRequestException),           
                typeof(TimeoutExceptionApp),           
                typeof(UnauthorizedException),         
                typeof(BadGatewayException),          
                typeof(InternalServerException),        
                typeof(ServiceUnavailableException),    
                typeof(TooManyRequestsException)        
            };

            return retryExceptions.Contains(ex.GetType());
        }

    }

}
