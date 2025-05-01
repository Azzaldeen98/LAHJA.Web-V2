

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class ActiveMasterUseCase : ITBaseUseCase {

    private readonly IMasterRepository _repository;
    public ActiveMasterUseCase(IMasterRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<TypeModelView>> ExecuteAsync(string lg, CancellationToken cancellationToken)
   {

    
         return    await _repository.ActiveAsync(lg, cancellationToken);
        

   }


}
