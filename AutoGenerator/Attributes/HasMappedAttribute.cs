namespace AutoGenerator.Attributes
{

    using System;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class HasMappedAttribute : Attribute
    {
        public Type[] TargetTypes { get; }

        public HasMappedAttribute(params Type[] targetTypes)
        {
            TargetTypes = targetTypes;
        }
    }

}
