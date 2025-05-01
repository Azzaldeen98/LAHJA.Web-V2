

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetAllPermissionUseCase : ITBaseUseCase {

    private readonly IPermissionRepository _repository;
    public GetAllPermissionUseCase(IPermissionRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(CancellationToken cancellationToken)
   {

    
          await _repository.GetAllAsync(cancellationToken);
        

   }


}
