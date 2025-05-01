

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class CategoriesGETMasterUseCase : ITBaseUseCase {

    private readonly IMasterRepository _repository;
    public CategoriesGETMasterUseCase(IMasterRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(string name, string lg, CancellationToken cancellationToken)
   {

    
          await _repository.CategoriesGETAsync(name, lg, cancellationToken);
        

   }


}
