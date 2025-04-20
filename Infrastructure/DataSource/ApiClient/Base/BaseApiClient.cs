using AutoMapper;
using Domain.Entities.Billing.Request;
using Domain.ShareData.Base;
using Domain.Wrapper;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Middlewares;
using Infrastructure.Models.Billing.Response;
using Microsoft.Extensions.Configuration;
using Shared.Exceptions;
using Shared.Exceptions.Others;
using Shared.Exceptions.Server;
using System.Text.RegularExpressions;

namespace Infrastructure.DataSource.ApiClient.Base
{



    public interface IBuildApiClient<T> {

        public string DevelopmentMessage { get; }


        public  Task<T> GetApiClient();
       
    }



    //public static class ExceptionHandler
    //{
    //    public static void ExecuteSafely(Action action)
    //    {
    //        try
    //        {
    //            action();
    //        }
    //        catch (Exception ex) // التقاط أي استثناء عام
    //        {
    //            var stateCode = ExtractStateCode(ex.Message); // استخراج رقم الخطأ

    //            if (stateCode == 401)
    //                throw new UnauthorizedException("المستخدم غير مخول للوصول إلى هذا المورد.");
    //            else if (stateCode == 408)
    //                throw new TimeoutExceptionApp("انتهت مهلة الاتصال بالخادم.");
    //            else if (stateCode == 500)
    //                throw new InternalServerException("حدث خطأ داخلي في الخادم.");
    //            else
    //                throw new UnknownException($"حدث خطأ غير متوقع: {ex.Message}"); // استثناء عام للأخطاء غير المعروفة
    //        }
    //    }

    //    // دالة لاستخراج كود الخطأ من نص الرسالة
    //    private static int ExtractStateCode(string message)
    //    {
    //        var match = Regex.Match(message, @"\b(\d{3})\b"); // البحث عن رقم مكون من 3 خانات
    //        return match.Success ? int.Parse(match.Value) : -1; // إرجاع الرقم أو -1 إذا لم يتم العثور عليه
    //    }
    //}

    public class BuildApiClient<T>: IBuildApiClient<T> where T : class
    {

        public  string DevelopmentMessage => "The service is still under development From  Api !! ";

        protected readonly ClientFactory _clientFactory;
        protected readonly IMapper _mapper;
        protected readonly IConfiguration _config;
        protected readonly IApiSafelyHandlerMiddleware apiSafelyHandler;



        public BuildApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config)
        {
            _clientFactory = clientFactory;
            _mapper = mapper;
            _config = config;
        }

        public BuildApiClient(
                        ClientFactory clientFactory,
                        IMapper mapper,
                        IConfiguration config,
                        IApiSafelyHandlerMiddleware apiSafelyHandler) : this(clientFactory, mapper, config)
        {

            this.apiSafelyHandler = apiSafelyHandler;
        }

        public async Task<T> GetApiClient()
        {
            var client = await _clientFactory.CreateClientWithAuthAsync<T>("ApiClient");
            return client;
        }


        //public async Task<T> ExecuteWithRetryAsync<T>(Func<Task<T>> action)
        //{

        //    int _maxRetries = 3;
        //    int attempt = 0;
        //    while (attempt < _maxRetries)
        //    {
        //        try
        //        {
        //            return await action();
        //        }
        //        catch (HttpRequestException ex) when (IsTransientError(ex))
        //        {
        //            attempt++;
        //            Console.WriteLine($"Retrying request ({attempt}/{_maxRetries}) due to: {ex.Message}");
        //            if (attempt >= _maxRetries)
        //                throw;
        //        }
        //        catch (TaskCanceledException ex) when (!ex.CancellationToken.IsCancellationRequested)
        //        {
        //            attempt++;
        //            Console.WriteLine($"Retrying request ({attempt}/{_maxRetries}) due to timeout.");
        //            if (attempt >= _maxRetries)
        //                throw;
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"Unhandled exception: {ex.Message}");
        //            throw;
        //        }

        //        await Task.Delay(GetRetryDelay(attempt));
        //    }
        //    throw new Exception("Max retry attempts reached.");
        //}

        //private bool IsTransientError(HttpRequestException ex)
        //{
        //    return ex.StatusCode == System.Net.HttpStatusCode.InternalServerError ||  // 500
        //           ex.StatusCode == System.Net.HttpStatusCode.Unauthorized ||         // 401
        //           ex.StatusCode == System.Net.HttpStatusCode.Forbidden;             // 403
        //}

        //private TimeSpan GetRetryDelay(int attempt)
        //{
        //    return TimeSpan.FromSeconds(Math.Pow(2, attempt)); // Exponential backoff (2, 4, 8 seconds)
        //}



    }
}
