

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class DeleteServiceUseCase : ITBaseUseCase {

    private readonly IServiceRepository _repository;
    public DeleteServiceUseCase(IServiceRepository repository){
        _repository=repository;
    }

                
    public async Task<DeletedResponse> ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.DeleteServiceAsync(id, cancellationToken);
        

   }


}
