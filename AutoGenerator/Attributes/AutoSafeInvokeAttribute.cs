namespace AutoGenerator.Attributes
{

    using System;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class AutoSafeInvokeAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class IgnoreSafeInvokeAttribute : Attribute
    {
    }


}
