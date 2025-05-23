
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public class SettingService : ISettingService {


        
     private readonly SettingAllUseCase _settingAllUseCase;
     private readonly SettingDELETEUseCase _settingDELETEUseCase;
     private readonly SettingGETUseCase _settingGETUseCase;
     private readonly SettingPOSTUseCase _settingPOSTUseCase;
     private readonly SettingPUTUseCase _settingPUTUseCase;


    public SettingService(   
            SettingAllUseCase settingAllUseCase,
            SettingDELETEUseCase settingDELETEUseCase,
            SettingGETUseCase settingGETUseCase,
            SettingPOSTUseCase settingPOSTUseCase,
            SettingPUTUseCase settingPUTUseCase)
    {
                        
          _settingAllUseCase=settingAllUseCase;
          _settingDELETEUseCase=settingDELETEUseCase;
          _settingGETUseCase=settingGETUseCase;
          _settingPOSTUseCase=settingPOSTUseCase;
          _settingPUTUseCase=settingPUTUseCase;


    }

                

    public async Task<ICollection<object>> settingAllAsync(CancellationToken cancellationToken)
   {

    

         return   await _settingAllUseCase.ExecuteAsync(cancellationToken);
        

   }



    public async Task settingDELETEAsync(string name, CancellationToken cancellationToken)
   {

    

         await _settingDELETEUseCase.ExecuteAsync(name, cancellationToken);
        

   }



    public async Task<ServiceResponse> settingGETAsync(string name, CancellationToken cancellationToken)
   {

    

         return   await _settingGETUseCase.ExecuteAsync(name, cancellationToken);
        

   }



    public async Task<ServiceResponse> settingPOSTAsync(SettingCreate body, CancellationToken cancellationToken)
   {

    

         return   await _settingPOSTUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task settingPUTAsync(string name, SettingUpdate body, CancellationToken cancellationToken)
   {

    

         await _settingPUTUseCase.ExecuteAsync(name, body, cancellationToken);
        

   }





}
