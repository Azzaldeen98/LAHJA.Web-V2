

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class LanguagesPOSTMasterUseCase : ITBaseUseCase {

    private readonly IMasterRepository _repository;
    public LanguagesPOSTMasterUseCase(IMasterRepository repository){
        _repository=repository;
    }

                
    public async Task ExecuteAsync(string lg, LanguageCreate body, CancellationToken cancellationToken)
   {

    
          await _repository.LanguagesPOSTAsync(lg, body, cancellationToken);
        

   }


}
