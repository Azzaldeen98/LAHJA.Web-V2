
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public class ManageService : IManageService {


            
 private readonly InfoGETManageUseCase _infoGETManageUseCase;
 private readonly InfoPOSTManageUseCase _infoPOSTManageUseCase;
 private readonly TwofaManageUseCase _twofaManageUseCase;


            public ManageService(
InfoGETManageUseCase infoGETManageUseCase,
InfoPOSTManageUseCase infoPOSTManageUseCase,
TwofaManageUseCase twofaManageUseCase){
                
      _infoGETManageUseCase=infoGETManageUseCase;
      _infoPOSTManageUseCase=infoPOSTManageUseCase;
      _twofaManageUseCase=twofaManageUseCase;


            }

                

    public async Task<InfoResponse> infoGETManageAsync(CancellationToken cancellationToken)
   {

    

         return    await _infoGETManageUseCase.ExecuteAsync(cancellationToken);
        

   }



    public async Task<InfoResponse> infoPOSTManageAsync(InfoRequest body, CancellationToken cancellationToken)
   {

    

         return    await _infoPOSTManageUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<TwoFactorResponse> twofaManageAsync(TwoFactorRequest body, CancellationToken cancellationToken)
   {

    

         return    await _twofaManageUseCase.ExecuteAsync(body, cancellationToken);
        

   }





}
