
using  System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.AutoGenerator.Interfaces;
using Infrastructure.DataSource.ApiClient2.Base;
using Infrastructure.DataSource.ApiClient2;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repositories;


public interface IManageRepository :  ITBaseRepository ,  ITScope  
{
public Task<TwoFactorResponse> TwofaAsync(TwoFactorRequest body, CancellationToken cancellationToken);

public Task<InfoResponse> InfoGETAsync(CancellationToken cancellationToken);

public Task<InfoResponse> InfoPOSTAsync(InfoRequest body, CancellationToken cancellationToken);

}

