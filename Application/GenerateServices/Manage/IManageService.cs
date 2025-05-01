
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public interface IManageService :  ITBaseService ,  ITScope  
{

    public Task<InfoResponse> infoGETManageAsync(CancellationToken cancellationToken);


    public Task<InfoResponse> infoPOSTManageAsync(InfoRequest body, CancellationToken cancellationToken);


    public Task<TwoFactorResponse> twofaManageAsync(TwoFactorRequest body, CancellationToken cancellationToken);




}

