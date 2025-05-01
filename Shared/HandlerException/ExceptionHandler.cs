﻿using Shared.Exceptions.Others;
using Shared.Exceptions;
using System.Text.RegularExpressions;
using Shared.Exceptions.Server;
using Shared.Exceptions.Base;
using Shared.Exceptions.Subscription;

namespace Shared.HandlerException
{
    public  interface IExceptionHandler
    {
        public TimeSpan GetRetryDelay(int attempt);
        public int ExtractStateCode(string message);
        public   void HandleAndThrowException(Exception ex);
        public int DetectExceptionTypeByMessage(string message);
        public  void ThrowMappedException(string errorMessage, int stateCode);
        public BaseExceptionApp GetExceptionTypeByStateCode(int stateCode);
        public BaseExceptionApp GetExceptionTypeByStateCode(string errorMessage, int stateCode);
    }


    public abstract class ExceptionHandler : IExceptionHandler
    {

        public  virtual TimeSpan GetRetryDelay(int attempt)
        {
            return TimeSpan.FromSeconds(Math.Pow(2, attempt));
        }

        public virtual bool IsTransientError(HttpRequestException ex)
        {
            return ex.StatusCode == System.Net.HttpStatusCode.InternalServerError ||  // 500
                ex.StatusCode == System.Net.HttpStatusCode.Unauthorized ||         // 401
                ex.StatusCode == System.Net.HttpStatusCode.Forbidden;// 403
        }


        public virtual BaseExceptionApp GetExceptionTypeByStateCode(int stateCode)
        {
            return GetExceptionTypeByStateCode("",stateCode);
        }
        public virtual BaseExceptionApp GetExceptionTypeByStateCode(string errorMessage,int stateCode)
        {
            string errorCode = stateCode.ToString()??"";
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
                case 904: return new SubscriptionUnavailableException(errorMessage, errorCode);
                case 905: return new SubscriptionExpiredException(errorMessage, errorCode);
                default: return new UnknownException(errorMessage, "-1");
            }
        }
        public virtual void ThrowMappedException(string errorMessage,int stateCode)
        {
            throw GetExceptionTypeByStateCode(errorMessage,stateCode);
      
        }

        public virtual void HandleAndThrowException(Exception ex)
        {
            
                var stateCode = ExtractStateCode(ex.Message);
                var errorMessage = ex.Message;

                if (stateCode == -1) // إذا لم يتم العثور على رقم خطأ، استخدم البحث عن الكلمات الرئيسية
                {
                    stateCode = DetectExceptionTypeByMessage(errorMessage);
                }

                ThrowMappedException(errorMessage, stateCode);


        }

        public virtual int ExtractStateCode(string message)
        {
            var match = Regex.Match(message, @"\b(\d{3})\b"); // البحث عن رقم مكون من 3 خانات
            return match.Success ? int.Parse(match.Value) : -1; // إرجاع الرقم أو -1 إذا لم يتم العثور عليه
        }

        public virtual int DetectExceptionTypeByMessage(string message)
        {
            message=message.ToLower();

            if (message.Contains("bad request", StringComparison.OrdinalIgnoreCase))
                return 400;
            if (message.Contains("unauthorized", StringComparison.OrdinalIgnoreCase))
                return 401;
            if (message.Contains("not found", StringComparison.OrdinalIgnoreCase))
                return 404;
            if (message.Contains("timeout", StringComparison.OrdinalIgnoreCase))
                return 408;
            if (message.Contains("conflict detected", StringComparison.OrdinalIgnoreCase))
                return 409; 
            if (message.Contains("too many requests", StringComparison.OrdinalIgnoreCase))
                return 429;
            if (message.Contains("internal server error", StringComparison.OrdinalIgnoreCase))
                return 500;
            if (message.Contains("bad gateway", StringComparison.OrdinalIgnoreCase))
                return 502;
            if (message.Contains("service unavailable", StringComparison.OrdinalIgnoreCase))
                return 503;        
            if (Contain(message, "subscription") && Contain(message, "unavailable"))
                return 904;        
            if (Contain(message, "subscription") && Contain(message, "expired"))
                return 905;      

            return -1; // في حال لم يتم العثور على تطابق
        }


        private  bool Contain(string message,string value)
        {
            return message.Contains(value, StringComparison.OrdinalIgnoreCase);
        }
        


}
}
