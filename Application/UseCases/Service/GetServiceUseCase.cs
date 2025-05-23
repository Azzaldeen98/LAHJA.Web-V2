﻿

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetServiceUseCase : ITBaseUseCase {

    private readonly IServiceRepository _repository;
    public GetServiceUseCase(IServiceRepository repository){
        _repository=repository;
    }

                
    public async Task<ServiceResponse> ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetServiceAsync(id, cancellationToken);
        

   }


}
