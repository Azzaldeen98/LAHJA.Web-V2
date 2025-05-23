
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public interface ICheckoutService :  ITBaseShareService  
{

    public Task<CheckoutResponse> createCheckoutAsync(CheckoutOptions body, CancellationToken cancellationToken);


    public Task<CheckoutResponse> manageCheckoutAsync(SessionCreate body, CancellationToken cancellationToken);




}

