

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class UpdateServiceUseCase : ITBaseUseCase {

    private readonly IServiceRepository _repository;
    public UpdateServiceUseCase(IServiceRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(string id, ServiceUpdate body, CancellationToken cancellationToken)
   {

    
          await _repository.UpdateServiceAsync(id, body, cancellationToken);
        

   }


}
