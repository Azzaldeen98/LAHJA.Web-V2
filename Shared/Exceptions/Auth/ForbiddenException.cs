using Shared.Exceptions.Base;

namespace Shared.Exceptions
{
    public class ForbiddenException : BaseExceptionApp
    {
        //403
        public ForbiddenException()
        {
        }

        public ForbiddenException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public ForbiddenException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public ForbiddenException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }


}
