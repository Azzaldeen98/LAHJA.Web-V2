using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Extensions
{
   public static class RegisterDependenciesExtension
    {

        public static void RegisterDependencies<TBase>(this IServiceCollection services,
            Func<IServiceCollection, Type, Type, IServiceCollection> registrationMethod,
            IEnumerable<Assembly> assemblies)
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
                        //services.AddScoped(matchingInterface, implementation);
                        registrationMethod(services, matchingInterface, implementation);
                    }
                }
                else
                {
                    // إذا لم يكن هناك واجهة، نقوم بتسجيل الكلاس فقط
                    if (!services.Any(s => s.ServiceType == implementation))
                    {
                        registrationMethod(services,implementation, implementation);
                    }
                }
            }
        }
    }
}
