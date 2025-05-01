
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Shared.Interfaces;
using System.Reflection;


namespace Shared.Services.Infrastructure.Extensions
{


    public static class RegistrarServiceCollectionExtensions
    {

        public static void RegisterServices<TInterface>(this IServiceCollection services,
            Func<IServiceCollection, Type, Type, IServiceCollection> registrationMethod)
        {
            var interfaceType = typeof(TInterface);
            var assembly = Assembly.GetExecutingAssembly();

            var typesToRegister = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && interfaceType.IsAssignableFrom(t))
                .ToList();

            foreach (var type in typesToRegister)
            {
                var interfaces = type.GetInterfaces()
                                     .Where(i => i != interfaceType)
                                     .ToList();

                bool hasMatchedInterface = false;

                foreach (var iface in interfaces)
                {
                    //// TODO
                    System.Diagnostics.Debug.WriteLine($"IServiceRegistrar : {type.Name} as {iface.Name}\n");


                    if (iface.Name.StartsWith("I") && iface.Name.Substring(1) == type.Name)
                    {
                        registrationMethod(services, iface, type);
                        hasMatchedInterface = true;
                        break;
                    }
                }


                if (!hasMatchedInterface)
                {
                    System.Diagnostics.Debug.WriteLine($"ServiceRegistrar : {type.Name} \n");
                    //MethodInfo methodInfo = registrationMethod.Method;

                    //if (methodInfo.IsGenericMethodDefinition)
                    //{
                    //    MethodInfo constructedMethod = methodInfo.MakeGenericMethod(type);


                    //    constructedMethod.Invoke(registrationMethod.Target, new object[] { services, type });
                    //    Console.WriteLine("?? «·œ«·… ÂÌ Ã‰—Ìﬂ ( ” Œœ„ ﬁÊ«·» T).");
                    //}
                    //else
                    //{


                    registrationMethod(services, type, type);
                    //Console.WriteLine("? «·œ«·… ·Ì”  Ã‰—Ìﬂ.");
                    //}

                }
            }
        }

        // <summary>
        /// A generic function used to register services in the IServiceCollection container with the ability to implement additional logic.
        // It relies on two functions:
        // 1. A registrationMethod function that registers the service.
        // 2. A callback function that applies additional logic after or during registration (such as adding a proxy or an interceptor).
        // </summary>
        /// <typeparam name="TInterface">The type of the interceptor or the type of the target service.
        /// <param name="services">The Dependency Injection container in which the services are registered.
        /// <param name="registrationMethod">A function that performs the actual registration of the service in the container.
        /// <param name="callback">A function that implements additional logic after registration (such as adding a proxy or an interceptor).
        /// </param>
        private static void RegisterServicesCallBack<TInterface>(this IServiceCollection services,
           Func<IServiceCollection, Type, Type, IServiceCollection> registrationMethod=null,
             Action<IServiceCollection, Type, Type> callback=null)
        {
            var interfaceType = typeof(TInterface);
            var assembly = Assembly.GetExecutingAssembly();

            var typesToRegister = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && interfaceType.IsAssignableFrom(t))
                .ToList();

            foreach (var type in typesToRegister)
            {
                var interfaces = type.GetInterfaces()
                                     .Where(i => i != interfaceType)
                                     .ToList();

                bool hasMatchedInterface = false;

                foreach (var iface in interfaces)
                {
                    //// TODO
                    System.Diagnostics.Debug.WriteLine($"IServiceRegistrar : {type.Name} as {iface.Name}\n");


                    if (iface.Name.StartsWith("I") && iface.Name.Substring(1) == type.Name)
                    {
                        hasMatchedInterface = true;
                        if (registrationMethod != null)
                            registrationMethod(services, iface,type);
                        if(callback!=null)
                            callback(services, iface,type);
                      
                        break;
                    }
                }


                if (!hasMatchedInterface)
                {
                    System.Diagnostics.Debug.WriteLine($"ServiceRegistrar : {type.Name} \n");
                    if (registrationMethod != null)
                        registrationMethod(services, type, type);
                    if (callback != null)
                        callback(services, type, type);



                }
            }
        }
        public static void RegistersGenericServices<TInterface>(this IServiceCollection services)
        {
            var interfaceType = typeof(TInterface);
            var assembly = Assembly.GetExecutingAssembly();

            var typesToRegister = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && interfaceType.IsAssignableFrom(t))
                .ToList();

            var methodInfo = typeof(RegistrarServiceCollectionExtensions)
                .GetMethods(BindingFlags.Static | BindingFlags.Public)
                .First(m => m.Name == "AddWithInterceptor" && m.IsGenericMethod);


            foreach (var type in typesToRegister)
            {
                var genericMethod = methodInfo.MakeGenericMethod(type);
                genericMethod.Invoke(null, new object[] { services });
            }
        }


        public static IServiceCollection AddSingletonWithInterceptor<TService, TInterceptor>(this IServiceCollection services)
            where TService : class
            where TInterceptor : class, IInterceptor
        {
            services.AddSingleton(provider =>
            {
                var proxyGenerator = new ProxyGenerator();
                var interceptor = provider.GetRequiredService<TInterceptor>();
                var actualInstance = ActivatorUtilities.CreateInstance<TService>(provider);

                return proxyGenerator.CreateClassProxyWithTarget(
                    typeof(TService),
                    actualInstance,
                    interceptor);
            });
            return services;
        }


        public static void RegisterServicesByLifetime(this IServiceCollection services)
        {

            services.RegisterServices<ITSingleton>(ServiceCollectionServiceExtensions.AddSingleton);
            services.RegisterServices<ITScope>(ServiceCollectionServiceExtensions.AddScoped);
            services.RegisterServices<ITTransient>(ServiceCollectionServiceExtensions.AddTransient);



        }

        public static void RegisterInterceptorServices<ITServices,TInterceptorService>(this IServiceCollection services)
                where ITServices : class
                where TInterceptorService : class, IInterceptor
        {

            RegisterServicesCallBack<ITService>(services,callback:(s, interfaceType, implementationType) => {
                
                if (interfaceType == implementationType)
                {

                      var method = typeof(ServiceCollectionExtensions)
                     .GetMethod("AddScopedWithInterceptor", BindingFlags.Public | BindingFlags.Static)
                     .MakeGenericMethod(interfaceType, typeof(TInterceptorService));
                      method.Invoke(null, new object[] { s });
                }
                else
                {

                    var method = typeof(ServiceCollectionExtensions)
                    .GetMethod("AddScopedWithInterceptor", BindingFlags.Public | BindingFlags.Static)
                    .MakeGenericMethod(interfaceType, implementationType, typeof(TInterceptorService));
                        method.Invoke(null, new object[] { s });
                }


            });
 



        }


        public static IServiceCollection AddScopedWithInterceptor<TInterface, TImplementation, TInterceptor>(
                this IServiceCollection services)
                where TInterface : class
                where TImplementation : class, TInterface
                where TInterceptor : class, IInterceptor
        {
            services.AddScoped<TImplementation>();
            var provider = services.BuildServiceProvider();
            var generator = provider.GetRequiredService<ProxyGenerator>();
            var interceptor = provider.GetRequiredService<TInterceptor>();
            var implementation = provider.GetRequiredService<TImplementation>();

            services.AddScoped<TInterface>(provider =>
            {
                return generator.CreateInterfaceProxyWithTarget<TInterface>(implementation, interceptor);
            });

            return services;
        }

        public static IServiceCollection AddScopedWithInterceptor<TService, TInterceptor>(
        this IServiceCollection services)
        where TService : class
        where TInterceptor : class, IInterceptor
        {
            services.AddScoped<TService>();
            var provider = services.BuildServiceProvider();
            var generator = provider.GetRequiredService<ProxyGenerator>();
            var interceptor = provider.GetRequiredService<TInterceptor>();
            var implementation = provider.GetRequiredService<TService>();

            services.AddScoped<TService>(provider =>
            {
                if (typeof(TService).IsInterface)
                {
                    // ≈–« ﬂ«‰  TService Ê«ÃÂ…° ‰” Œœ„ CreateInterfaceProxyWithTarget
                    return generator.CreateInterfaceProxyWithTarget<TService>(implementation, interceptor);
                }
                else
                {
                    // ≈–« ﬂ«‰  TService ›∆…° ‰” Œœ„ CreateClassProxyWithTarget
                    return generator.CreateClassProxyWithTarget<TService>(implementation, interceptor);
                }
            });
            //services.AddScoped<TService>(provider =>
            //{
            //    var generator = provider.GetRequiredService<ProxyGenerator>();
            //    var implementation = provider.GetRequiredService<TService>();
            //    var interceptor = provider.GetRequiredService<TInterceptor>();// ErrorHandlingInterceptor>();
              

            //    // Â‰« ‰ Õﬁﬁ ≈–« ﬂ«‰ TService ÂÊ ›∆… √Ê Ê«ÃÂ…
            //    if (typeof(TService).IsInterface)
            //    {
            //        // ≈–« ﬂ«‰  TService Ê«ÃÂ…° ‰” Œœ„ CreateInterfaceProxyWithTarget
            //        return generator.CreateInterfaceProxyWithTarget<TService>(implementation, interceptor);
            //    }
            //    else
            //    {
            //        // ≈–« ﬂ«‰  TService ›∆…° ‰” Œœ„ CreateClassProxyWithTarget
            //        return generator.CreateClassProxyWithTarget<TService>(implementation, interceptor);
            //    }
            //});

            return services;
        }
        


    }
}