

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class LanguagesGETMasterUseCase : ITBaseUseCase {

    private readonly IMasterRepository _repository;
    public LanguagesGETMasterUseCase(IMasterRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(string code, string lg, CancellationToken cancellationToken)
   {

    
          await _repository.LanguagesGETAsync(code, lg, cancellationToken);
        

   }


}
