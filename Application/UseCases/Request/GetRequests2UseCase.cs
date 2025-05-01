

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetRequests2UseCase : ITBaseUseCase {

    private readonly IRequestRepository _repository;
    public GetRequests2UseCase(IRequestRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<RequestResponse>> ExecuteAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.GetRequests2Async(cancellationToken);
        

   }


}
