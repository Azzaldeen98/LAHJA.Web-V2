

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class LanguagesAllMasterUseCase : ITBaseUseCase {

    private readonly IMasterRepository _repository;
    public LanguagesAllMasterUseCase(IMasterRepository repository){
        _repository=repository;
    }

                
    public async Task<ICollection<LanguageView>> ExecuteAsync(string lg, CancellationToken cancellationToken)
   {

    
         return    await _repository.LanguagesAllAsync(lg, cancellationToken);
        

   }


}
