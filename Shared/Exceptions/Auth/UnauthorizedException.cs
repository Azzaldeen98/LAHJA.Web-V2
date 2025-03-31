using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    public class UnauthorizedException : BaseExceptionApp, IExceptionApp
    {

        //401
        public UnauthorizedException()
        {
        }

        public UnauthorizedException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public UnauthorizedException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public UnauthorizedException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }

}
