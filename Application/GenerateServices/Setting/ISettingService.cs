
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public interface ISettingService :  ITBaseService ,  ITScope  
{

    public Task<ICollection<object>> settingAllAsync(CancellationToken cancellationToken);


    public Task settingDELETEAsync(string name, CancellationToken cancellationToken);


    public Task<ServiceResponse> settingGETAsync(string name, CancellationToken cancellationToken);


    public Task<ServiceResponse> settingPOSTAsync(SettingCreate body, CancellationToken cancellationToken);


    public Task settingPUTAsync(string name, SettingUpdate body, CancellationToken cancellationToken);




}

