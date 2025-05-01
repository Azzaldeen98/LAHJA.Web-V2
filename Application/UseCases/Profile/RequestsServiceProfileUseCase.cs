

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class RequestsServiceProfileUseCase : ITBaseUseCase {

    private readonly IProfileRepository _repository;
    public RequestsServiceProfileUseCase(IProfileRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<RequestResponse>> ExecuteAsync(string serviceId, CancellationToken cancellationToken)
   {

    
         return    await _repository.RequestsServiceAsync(serviceId, cancellationToken);
        

   }


}
