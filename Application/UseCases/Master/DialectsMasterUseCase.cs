

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class DialectsMasterUseCase : ITBaseUseCase {

    private readonly IMasterRepository _repository;
    public DialectsMasterUseCase(IMasterRepository repository){
        _repository=repository;
    }

                
    public async Task<DialectView> ExecuteAsync(string lg, DialectCreate body, CancellationToken cancellationToken)
   {

    
         return    await _repository.DialectsAsync(lg, body, cancellationToken);
        

   }


}
