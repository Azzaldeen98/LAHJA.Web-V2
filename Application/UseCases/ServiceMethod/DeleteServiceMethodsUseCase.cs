

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class DeleteServiceMethodsUseCase : ITBaseUseCase {

    private readonly IServiceMethodRepository _repository;
    public DeleteServiceMethodsUseCase(IServiceMethodRepository repository){
        _repository=repository;
    }

                
    public async Task<DeletedResponse> ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.DeleteServiceMethodsAsync(id, cancellationToken);
        

   }


}
