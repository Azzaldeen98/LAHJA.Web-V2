

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class TypesGETMasterUseCase : ITBaseUseCase {

    private readonly IMasterRepository _repository;
    public TypesGETMasterUseCase(IMasterRepository repository){
        _repository=repository;
    }

                
    public async Task<TypeModelView> ExecuteAsync(string name, string lg, CancellationToken cancellationToken)
   {

    
         return    await _repository.TypesGETAsync(name, lg, cancellationToken);
        

   }


}
