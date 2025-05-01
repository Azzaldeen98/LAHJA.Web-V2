

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class TypesPOSTMasterUseCase : ITBaseUseCase {

    private readonly IMasterRepository _repository;
    public TypesPOSTMasterUseCase(IMasterRepository repository){
        _repository=repository;
    }

                
    public async Task<TypeModelView> ExecuteAsync(string lg, TypeModelCreate body, CancellationToken cancellationToken)
   {

    
         return    await _repository.TypesPOSTAsync(lg, body, cancellationToken);
        

   }


}
