
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public interface IPermissionService :  ITBaseShareService  
{

    public Task getAllPermissionAsync(CancellationToken cancellationToken);




}

