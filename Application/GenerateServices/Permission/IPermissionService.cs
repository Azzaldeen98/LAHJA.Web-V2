
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public interface IPermissionService :  ITBaseService ,  ITScope  
{

    public Task getAllPermissionAsync(CancellationToken cancellationToken);




}

