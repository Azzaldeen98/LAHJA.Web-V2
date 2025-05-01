

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class InfoGETManageUseCase : ITBaseUseCase {

    private readonly IManageRepository _repository;
    public InfoGETManageUseCase(IManageRepository repository){
        _repository=repository;
    }

                
    public async Task<InfoResponse> ExecuteAsync(CancellationToken cancellationToken)
   {

    
         return    await _repository.InfoGETAsync(cancellationToken);
        

   }


}
