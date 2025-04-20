﻿using Shared.Exceptions.Base;

namespace Shared.Exceptions.Subscription
{
    public class SubscriptionUnavailableException : BaseExceptionApp
    {
        public SubscriptionUnavailableException()
        {
        }

        public SubscriptionUnavailableException(string message, string errorCode = "GENERIC_ERROR") : base(message, errorCode)
        {
        }

        public SubscriptionUnavailableException(List<string> messages, string errorCode = "GENERIC_ERROR") : base(messages, errorCode)
        {
        }

        public SubscriptionUnavailableException(string message, Exception innerException, string errorCode = "GENERIC_ERROR") : base(message, innerException, errorCode)
        {
        }
    }


}
