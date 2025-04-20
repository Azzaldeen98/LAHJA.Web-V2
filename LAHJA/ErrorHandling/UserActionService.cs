﻿using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shared.Constants.Router;
using System.Threading.Tasks;

namespace LAHJA.ErrorHandling
{

    public interface IUserActionService
    {

        public void NavigationTo(string url, Dictionary<string, object>? parametrs=null);
        public void ShowSnackBar(string message);
        public void ShowNotify(string message);
        public  Task<bool?> ShowMessageBox(string title,string message, string? yesText = "", string? noText = "", string? cancelText = "");
        public  Task<bool?> ShowMessageBox(string message, string? yesText = "", string? noText = "", string? cancelText = "");


    }

    public class UserActionService : IUserActionService
    {
        private readonly NavigationManager navigation;
        private readonly ISnackbar snackbar;
        private readonly IDialogService dialog;
        public UserActionService(NavigationManager navigation, ISnackbar snackbar, IDialogService dialog)
        {
            this.navigation = navigation;
            this.snackbar = snackbar;
            this.dialog = dialog;
        }

        public void NavigationTo(string url, Dictionary<string,object>? parametrs=null)
        {
              if(parametrs!=null && parametrs.Any())
                    foreach (var parametr in parametrs)
                    {
                        url += $" {parametr.Key}={parametr.Value}&";
                    }

                navigation?.NavigateTo(url,true);
        }


        public async Task<bool?> ShowMessageBox(string message, string yesText = "", string noText = "",string cancelText="")
        {
            return await ShowMessageBox("",message, yesText,noText, cancelText);
        }

        public async Task<bool?> ShowMessageBox(string title, string message, string yesText="", string noText="",string cancelText="")
        {
            var options = new DialogOptions { FullWidth = false, MaxWidth= MaxWidth.Small }; 
           return await dialog?.ShowMessageBox(title, message,yesText: yesText, noText: noText,cancelText: cancelText, options: options);
           
        }

        public void ShowNotify(string message)
        {
            throw new NotImplementedException();
        }

        public void ShowSnackBar(string message)
        {
            snackbar?.Add(message, Severity.Error);
        }
    }






}
