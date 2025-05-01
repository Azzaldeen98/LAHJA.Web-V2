
using  System;
using System.Threading.Tasks;
using Infrastructure.Nswag;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
namespace Application.Services;


public class UserService : IUserService {


            
 private readonly AssignModelAiUserUseCase _assignModelAiUserUseCase;
 private readonly AssignRoleUserUseCase _assignRoleUserUseCase;
 private readonly AssignServiceUserUseCase _assignServiceUserUseCase;
 private readonly GetUserUseCase _getUserUseCase;


            public UserService(
AssignModelAiUserUseCase assignModelAiUserUseCase,
AssignRoleUserUseCase assignRoleUserUseCase,
AssignServiceUserUseCase assignServiceUserUseCase,
GetUserUseCase getUserUseCase){
                
      _assignModelAiUserUseCase=assignModelAiUserUseCase;
      _assignRoleUserUseCase=assignRoleUserUseCase;
      _assignServiceUserUseCase=assignServiceUserUseCase;
      _getUserUseCase=getUserUseCase;


            }

                

    public async Task<UserResponse> assignModelAiUserAsync(AssignModelAi body, CancellationToken cancellationToken)
   {

    

         return    await _assignModelAiUserUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<UserResponse> assignRoleUserAsync(RoleAssign body, CancellationToken cancellationToken)
   {

    

         return    await _assignRoleUserUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<UserResponse> assignServiceUserAsync(AssignService body, CancellationToken cancellationToken)
   {

    

         return    await _assignServiceUserUseCase.ExecuteAsync(body, cancellationToken);
        

   }



    public async Task<UserResponse> getUserAsync(string id, CancellationToken cancellationToken)
   {

    

         return    await _getUserUseCase.ExecuteAsync(id, cancellationToken);
        

   }





}
