
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public class PermissionService : IPermissionService {


            
 private readonly GetAllPermissionUseCase _getAllPermissionUseCase;


            public PermissionService(
GetAllPermissionUseCase getAllPermissionUseCase){
                
      _getAllPermissionUseCase=getAllPermissionUseCase;


            }

                

    public async Task getAllPermissionAsync(CancellationToken cancellationToken)
   {

    

          await _getAllPermissionUseCase.ExecuteAsync(cancellationToken);
        

   }





}
