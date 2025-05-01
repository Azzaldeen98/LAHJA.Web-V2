

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class CreateRequestUseCase : ITBaseUseCase {

    private readonly IRequestRepository _repository;
    public CreateRequestUseCase(IRequestRepository repository){
        _repository=repository;
    }

                
    public async Task<ServiceDataTod> ExecuteAsync(RequestCreate body, CancellationToken cancellationToken)
   {

    
         return    await _repository.CreateRequestAsync(body, cancellationToken);
        

   }


}
