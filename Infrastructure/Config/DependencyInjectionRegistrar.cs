using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.Config
{

    public static class DependencyInjectionRegistrar
    {
        /// <summary>
        /// Creates Scoped registers for all interfaces or classes that implement or inherit from a given base type.
        /// </summary>
        /// <typeparam name="TBase">The base type from which you want to search for types that inherit or implement</typeparam>
        /// <param name="assemblies">A list of assemblies to check for available types</param>
        //public static void RegisterScopedDependencies<TBase>(IEnumerable<Assembly> assemblies,string outputFilePath,string serviceObjectName)
        //{
        //    // Get the base type
        //    var baseType = typeof(TBase);

        //    // List to store the pair (interface/class) that will be linked to AddScoped
        //    var classInterfacePairs = new List<(Type Interface, Type Implementation)>();

        //    // Checking types in assemblies
        //    var types = assemblies
        //    .SelectMany(a => a.GetTypes())
        //    .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
        //    .ToList();

        //    // Detect types that implement an interface or base class
        //    foreach (var type in types)
        //    {
        //        if (type.IsInterface) // If the type is an interface
        //        {
        //            // Check classes that implement this interface
        //            var implementingClasses = types
        //            .Where(t => t.IsClass && baseType.IsAssignableFrom(t) && t.GetInterfaces().Contains(type))
        //            .ToList();

        //            foreach (var impl in implementingClasses)
        //            {
        //                classInterfacePairs.Add((type, impl));
        //            }
        //        }
        //        //else if (type.IsClass) // If the type is a class
        //        //{
        //        //    // Check types that inherit from this class
        //        //    var derivedClasses = types
        //        //    .Where(t => t.IsClass && baseType.IsAssignableFrom(t) && t != type)
        //        //    .ToList();

        //        //    foreach (var derived in derivedClasses)
        //        //    {
        //        //        classInterfacePairs.Add((type, derived));
        //        //    }
        //        //}
        //    }

        //    // AddScoped output for each pair 
        //    Console.WriteLine("//Generated AddScoped registrations");


        //    using (var writer = new StreamWriter(outputFilePath))
        //    {


        //        foreach (var pair in classInterfacePairs)
        //        {
        //            Console.WriteLine($"{serviceObjectName}.AddScoped<{pair.Interface.FullName}, {pair.Implementation.FullName}>();");
        //            writer.WriteLine($"{serviceObjectName}.AddScoped<{pair.Interface.FullName}, {pair.Implementation.FullName}>();");
        //        }
        //    }
        //}
        //public static void RegisterScopedDependencies<TBase>(IEnumerable<Assembly> assemblies, string outputFilePath, string serviceObjectName)
        //{
        //    var baseType = typeof(TBase);

        //    // استخدم HashSet بدلاً من List لمنع التكرار
        //    var classInterfacePairs = new HashSet<(Type Interface, Type Implementation)>();

        //    var types = assemblies
        //        .SelectMany(a => a.GetTypes())
        //        .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
        //        .ToList();

        //    foreach (var type in types)
        //    {
        //        if (type.IsInterface)
        //        {
        //            var implementingClasses = types
        //                .Where(t => t.IsClass && baseType.IsAssignableFrom(t) && t.GetInterfaces().Contains(type))
        //                .ToList();

        //            foreach (var impl in implementingClasses)
        //            {
        //                classInterfacePairs.Add((type, impl)); // HashSet يمنع التكرار
        //            }
        //        }
        //    }

        //    // كتابة نتائج AddScoped
        //    using (var writer = new StreamWriter(outputFilePath))
        //    {
        //        foreach (var pair in classInterfacePairs)
        //        {
        //            var line = $"{serviceObjectName}.AddScoped<{pair.Interface.FullName}, {pair.Implementation.FullName}>();";
        //            Console.WriteLine(line);
        //            writer.WriteLine(line);
        //        }
        //    }
        //}
        //public static void RegisterScopedDependencies<TBase>(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        //{
        //    var baseType = typeof(TBase);

        //    // استخراج جميع الكلاسات التي ترث من TBase
        //    var classes = assemblies
        //        .SelectMany(a => a.GetTypes())
        //        .Where(t => t.IsClass && !t.IsAbstract && baseType.IsAssignableFrom(t) && t != baseType)
        //        .ToList();

        //    // استخراج جميع الواجهات التي ترث من TBase
        //    var interfaces = assemblies
        //        .SelectMany(a => a.GetTypes())
        //        .Where(t => t.IsInterface && baseType.IsAssignableFrom(t) && t != baseType)
        //        .ToList();

        //    // تسجيل الكلاسات التي ترث من TBase
        //    foreach (var implementation in classes)
        //    {
        //        if (!services.Any(s => s.ServiceType == implementation))
        //        {
        //            services.AddScoped(implementation);
        //        }
        //    }

        //    // تسجيل الكلاسات التي تنفذ الواجهات
        //    foreach (var @interface in interfaces)
        //    {
        //        var implementingClasses = classes
        //            .Where(c => @interface.IsAssignableFrom(c))
        //            .ToList();

        //        foreach (var impl in implementingClasses)
        //        {
        //            if (!services.Any(s => s.ServiceType == @interface && s.ImplementationType == impl))
        //            {
        //                services.AddScoped(@interface, impl);
        //            }
        //        }
        //    }
        //}

        public static void RegisterScopedDependencies<TBase>(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            var baseType = typeof(TBase);

            // استخراج جميع الكلاسات التي ترث من TBase
            var classes = assemblies
                .SelectMany(a => a.GetTypes())
                .Where(t => t.IsClass && !t.IsAbstract && baseType.IsAssignableFrom(t) && t != baseType)
                .ToList();

            // استخراج جميع الواجهات التي ترث من TBase
            var interfaces = assemblies
                .SelectMany(a => a.GetTypes())
                .Where(t => t.IsInterface && baseType.IsAssignableFrom(t) && t != baseType)
                .ToList();

            // تسجيل الكلاسات التي ترث من TBase
            foreach (var implementation in classes)
            {
                // البحث عن الواجهة التي تبدأ بـ "I" ولها نفس اسم الكلاس
                var matchingInterface = interfaces.FirstOrDefault(i => i.Name.Substring(1) == implementation.Name);

                if (matchingInterface != null)
                {
                    // إذا وجدنا واجهة مطابقة، نقوم بتسجيل الكلاس والواجهة معًا
                    if (!services.Any(s => s.ServiceType == matchingInterface && s.ImplementationType == implementation))
                    {
                        services.AddScoped(matchingInterface, implementation);
                    }
                }
                else
                {
                    // إذا لم يكن هناك واجهة، نقوم بتسجيل الكلاس فقط
                    if (!services.Any(s => s.ServiceType == implementation))
                    {
                        services.AddScoped(implementation);
                    }
                }
            }
        }




    }
}
