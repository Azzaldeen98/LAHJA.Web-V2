using Shared.Exceptions.Others;
using Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Shared.Exceptions.Server;
using Shared.Constants;
using Shared.Exceptions.Base;

namespace Shared.Middleware.HandlerException
{
    public  interface IExceptionHandlerMiddleware
    {
        public  Task<T> InvokeAsync<T>(Func<Task<T>> action);
        public  Task InvokeAsync(Func<Task> action);
        public bool IsTransientError(HttpRequestException ex);

        public TimeSpan GetRetryDelay(int attempt);
        public int ExtractStateCode(string message);
        public   void HandleAndThrowException(Exception ex);
    }


    public abstract class ExceptionHandlerMiddleware : IExceptionHandlerMiddleware
    {
        public abstract  Task<T> InvokeAsync<T>(Func<Task<T>> action);
        public abstract  Task InvokeAsync(Func<Task> action);

        public TimeSpan GetRetryDelay(int attempt)
        {
            return TimeSpan.FromSeconds(Math.Pow(2, attempt));
        }

        public bool IsTransientError(HttpRequestException ex)
        {
            return ex.StatusCode == System.Net.HttpStatusCode.InternalServerError ||  // 500
                ex.StatusCode == System.Net.HttpStatusCode.Unauthorized ||         // 401
                ex.StatusCode == System.Net.HttpStatusCode.Forbidden;// 403
        }
        public BaseExceptionApp GetExceptionTypeByStateCode(int stateCode)
        {

            switch (stateCode)
            {
                case 400: return new BadRequestException();
                case 401: return new UnauthorizedException();
                case 403: return new ForbiddenException();
                case 404: return new NotFoundException();
                case 408: return new TimeoutExceptionApp();
                case 409: return new ConflictException();
                case 429: return new TooManyRequestsException();
                case 500: return new InternalServerException();
                case 502: return new BadGatewayException();
                case 503: return new ServiceUnavailableException();
                default: return new UnknownException();
            }
        }

        public BaseExceptionApp GetExceptionFromStateCode(string errorMessage,int stateCode)
        {
            string errorCode = $"{stateCode}";
            switch (stateCode)
            {
                case 400: return new BadRequestException(errorMessage, errorCode);
                case 401: return new UnauthorizedException(errorMessage, errorCode);
                case 403: return new ForbiddenException(errorMessage, errorCode);
                case 404: return new NotFoundException(errorMessage, errorCode);
                case 408: return new TimeoutExceptionApp(errorMessage, errorCode);
                case 409: return new ConflictException(errorMessage, errorCode);
                case 429: return new TooManyRequestsException(errorMessage, errorCode);
                case 500: return new InternalServerException(errorMessage, errorCode);
                case 502: return new BadGatewayException(errorMessage, errorCode);
                case 503: return new ServiceUnavailableException(errorMessage, errorCode);
                default: return new UnknownException(errorMessage, "Unknown");
            }
        }
        public  void ThrowMappedException(string errorMessage,int stateCode)
        {
            throw GetExceptionTypeByStateCode(stateCode).SetMessage(errorMessage,$"{stateCode}");
      
        }

        public virtual void HandleAndThrowException(Exception ex)
        {
            
                var stateCode = ExtractStateCode(ex.Message);
                var errorMessage = ex.Message;

                if (stateCode == -1) // إذا لم يتم العثور على رقم خطأ، استخدم البحث عن الكلمات الرئيسية
                {
                    stateCode = DetectErrorTypeByMessage(errorMessage);
                }

                ThrowMappedException(errorMessage, stateCode);


        }

        public  int ExtractStateCode(string message)
        {
            var match = Regex.Match(message, @"\b(\d{3})\b"); // البحث عن رقم مكون من 3 خانات
            return match.Success ? int.Parse(match.Value) : -1; // إرجاع الرقم أو -1 إذا لم يتم العثور عليه
        }

        public int DetectErrorTypeByMessage(string message)
        {
            message=message.ToLower();

            if (message.Contains("bad request", StringComparison.OrdinalIgnoreCase))
                return 400;
            if (message.Contains("conflict detected", StringComparison.OrdinalIgnoreCase))
                return 409;
            if (message.Contains("unauthorized", StringComparison.OrdinalIgnoreCase))
                return 401;
            if (message.Contains("not found", StringComparison.OrdinalIgnoreCase))
                return 404;
            if (message.Contains("timeout", StringComparison.OrdinalIgnoreCase))
                return 408; 
            if (message.Contains("too many requests", StringComparison.OrdinalIgnoreCase))
                return 429;
            if (message.Contains("bad gateway", StringComparison.OrdinalIgnoreCase))
                return 502;
            if (message.Contains("internal server error", StringComparison.OrdinalIgnoreCase))
                return 500;
            if (message.Contains("service unavailable", StringComparison.OrdinalIgnoreCase))
                return 503;      

            return -1; // في حال لم يتم العثور على تطابق
        }

        


}
}
