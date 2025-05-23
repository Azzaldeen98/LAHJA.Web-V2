﻿

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class RolesDELETEUseCase : ITBaseUseCase {

    private readonly IRolesRepository _repository;
    public RolesDELETEUseCase(IRolesRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
          await _repository.RolesDELETEAsync(id, cancellationToken);
        

   }


}
