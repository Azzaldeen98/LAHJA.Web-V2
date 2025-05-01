

using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Infrastructure.Repositories;
namespace Application.UseCases;


public class TwofaManageUseCase : ITBaseUseCase {

    private readonly IManageRepository _repository;
    public TwofaManageUseCase(IManageRepository repository){
        _repository=repository;
    }

                
    public async Task<TwoFactorResponse> ExecuteAsync(TwoFactorRequest body, CancellationToken cancellationToken)
   {

    
         return    await _repository.TwofaAsync(body, cancellationToken);
        

   }


}
