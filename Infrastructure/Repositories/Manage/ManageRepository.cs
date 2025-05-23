
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Infrastructure.DataSource.ApiClientBase;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


 public  class ManageRepository : IManageRepository {

    private readonly IManageApiClient _apiClient;
    public ManageRepository(IManageApiClient apiClient){
        _apiClient=apiClient;
    }
                

    public async Task<TwoFactorResponse> TwofaAsync(TwoFactorRequest body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.TwofaAsync(body, cancellationToken);
                

   }


    public async Task<InfoResponse> InfoGETAsync(CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.InfoGETAsync(cancellationToken);
                

   }


    public async Task<InfoResponse> InfoPOSTAsync(InfoRequest body, CancellationToken cancellationToken)
   {

    
                
     return    await _apiClient.InfoPOSTAsync(body, cancellationToken);
                

   }


}

