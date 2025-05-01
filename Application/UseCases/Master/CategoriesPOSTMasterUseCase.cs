

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class CategoriesPOSTMasterUseCase : ITBaseUseCase {

    private readonly IMasterRepository _repository;
    public CategoriesPOSTMasterUseCase(IMasterRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(string lg, CategoryCreate body, CancellationToken cancellationToken)
   {

    
          await _repository.CategoriesPOSTAsync(lg, body, cancellationToken);
        

   }


}
