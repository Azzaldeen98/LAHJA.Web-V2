

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetServiceMethodsUseCase : ITBaseUseCase {

    private readonly IServiceMethodRepository _repository;
    public GetServiceMethodsUseCase(IServiceMethodRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<ServiceMethodResponse>> ExecuteAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.GetServiceMethodsAsync(cancellationToken);
        

   }


}
