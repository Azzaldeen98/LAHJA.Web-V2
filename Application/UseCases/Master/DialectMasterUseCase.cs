

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class DialectMasterUseCase : ITBaseUseCase {

    private readonly IMasterRepository _repository;
    public DialectMasterUseCase(IMasterRepository repository){
        _repository=repository;
    }

                
    public async Task<DialectView> ExecuteAsync(string languageId, string lg, CancellationToken cancellationToken)
   {

    
         return    await _repository.DialectAsync(languageId, lg, cancellationToken);
        

   }


}
