

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class DeleteRequestUseCase : ITBaseUseCase {

    private readonly IRequestRepository _repository;
    public DeleteRequestUseCase(IRequestRepository repository){
        _repository=repository;
    }

                
    public async Task<DeletedResponse> ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.DeleteRequestAsync(id, cancellationToken);
        

   }


}
