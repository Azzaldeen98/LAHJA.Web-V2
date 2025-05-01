

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class InfoPOSTManageUseCase : ITBaseUseCase {

    private readonly IManageRepository _repository;
    public InfoPOSTManageUseCase(IManageRepository repository){
        _repository=repository;
    }

                
    public async Task<InfoResponse> ExecuteAsync(InfoRequest body, CancellationToken cancellationToken)
   {

    
         return    await _repository.InfoPOSTAsync(body, cancellationToken);
        

   }


}
