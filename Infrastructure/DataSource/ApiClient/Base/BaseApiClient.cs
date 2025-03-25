using AutoMapper;
using Domain.Entities.Billing.Request;
using Domain.ShareData.Base;
using Domain.Wrapper;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Models.Billing.Response;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DataSource.ApiClient.Base
{



    public interface IBuildApiClient<T> {

        public string DevelopmentMessage { get; }


        public  Task<T> GetApiClient();
       
    }



   
        
    

    public class BuildApiClient<T>: IBuildApiClient<T> where T : class
    {

        public  string DevelopmentMessage => "The service is still under development From  Api !! ";

        protected readonly ClientFactory _clientFactory;
        protected readonly IMapper _mapper;
        protected readonly IConfiguration _config;
        public BuildApiClient(
                    ClientFactory clientFactory,
                    IMapper mapper,
                    IConfiguration config)
        {
            _clientFactory = clientFactory;
            _mapper = mapper;
            _config = config;
        }



        public async Task<T> ExecuteWithRetryAsync<T>(Func<Task<T>> action)
        {

            int _maxRetries = 3;
            int attempt = 0;
            while (attempt < _maxRetries)
            {
                try
                {
                    return await action();
                }
                catch (HttpRequestException ex) when (IsTransientError(ex))
                {
                    attempt++;
                    Console.WriteLine($"Retrying request ({attempt}/{_maxRetries}) due to: {ex.Message}");
                    if (attempt >= _maxRetries)
                        throw;
                }
                catch (TaskCanceledException ex) when (!ex.CancellationToken.IsCancellationRequested)
                {
                    attempt++;
                    Console.WriteLine($"Retrying request ({attempt}/{_maxRetries}) due to timeout.");
                    if (attempt >= _maxRetries)
                        throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unhandled exception: {ex.Message}");
                    throw;
                }

                await Task.Delay(GetRetryDelay(attempt));
            }
            throw new Exception("Max retry attempts reached.");
        }

        private bool IsTransientError(HttpRequestException ex)
        {
            return ex.StatusCode == System.Net.HttpStatusCode.InternalServerError ||  // 500
                   ex.StatusCode == System.Net.HttpStatusCode.Unauthorized ||         // 401
                   ex.StatusCode == System.Net.HttpStatusCode.Forbidden;             // 403
        }

        private TimeSpan GetRetryDelay(int attempt)
        {
            return TimeSpan.FromSeconds(Math.Pow(2, attempt)); // Exponential backoff (2, 4, 8 seconds)
        }

        public  async Task<T>  GetApiClient()
        {
            var client = await _clientFactory.CreateClientWithAuthAsync<T>("ApiClient");
            return client;
        }

      
    }
}
