

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetRequestUseCase : ITBaseUseCase {

    private readonly IRequestRepository _repository;
    public GetRequestUseCase(IRequestRepository repository){
        _repository=repository;
    }

                
    public async Task<RequestResponse> ExecuteAsync(string id, CancellationToken cancellationToken)
   {

    
         return    await _repository.GetRequestAsync(id, cancellationToken);
        

   }


}
