

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class DialectsAllMasterUseCase : ITBaseUseCase {

    private readonly IMasterRepository _repository;
    public DialectsAllMasterUseCase(IMasterRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<DialectView>> ExecuteAsync(string languageId, string lg, CancellationToken cancellationToken)
   {

    
         return    await _repository.DialectsAllAsync(languageId, lg, cancellationToken);
        

   }


}
