

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class GetCustomerProfileUseCase : ITBaseUseCase {

    private readonly IProfileRepository _repository;
    public GetCustomerProfileUseCase(IProfileRepository repository){
        _repository=repository;
    }

                
    public async Task<CustomerResponse> ExecuteAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.GetCustomerAsync(cancellationToken);
        

   }


}
