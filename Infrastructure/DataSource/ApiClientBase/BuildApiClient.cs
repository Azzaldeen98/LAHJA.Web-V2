using AutoMapper;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Share.Invoker;
using Microsoft.Extensions.Configuration;
using Shared.Interfaces;

namespace Infrastructure.DataSource.ApiClientBase
{

        public interface IBuildApiClient<T> : ITBaseApiClient
        {
            public Task<T> GetApiClient();

        }


        public class BuildApiClient<T> : IBuildApiClient<T> where T : class
        {



            protected readonly ClientFactory _clientFactory;
            protected readonly IMapper _mapper;
            protected readonly IConfiguration _config;
            protected readonly IApiInvoker apiInvoker;

            public BuildApiClient(
                            ClientFactory clientFactory,
                            IMapper mapper,
                            IConfiguration config,
                            IApiInvoker apiInvoker)
            {
                _clientFactory = clientFactory;
                _mapper = mapper;
                _config = config;
                this.apiInvoker = apiInvoker;
            }


            public async Task<T> GetApiClient()
            {
                var client = await _clientFactory.CreateClientWithAuthAsync<T>("ApiClient");
                return client;
            }


        }
    
}
