using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shared.Constants.Router;

namespace LAHJA.Helpers
{

    public interface IExecutiveProceduresForProcessingErrors
    {
        public void Logout();
        public void NavigationTo(string url, Dictionary<string, object> parametrs);
        public void ShowSnackBar(string message);
        public void ShowNotify(string message);
        public void ShowMessageBox(string title,string message);


    }

    public class ExecutiveProceduresForProcessingErrors : IExecutiveProceduresForProcessingErrors
    {
        private readonly NavigationManager navigation;
        private readonly ISnackbar snackbar;
        private readonly IDialogService dialog;
        public ExecutiveProceduresForProcessingErrors(NavigationManager navigation, ISnackbar snackbar, IDialogService dialog)
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

        public void Logout()
        {
            navigation?.NavigateTo($"{RouterPage.LOGOUT}/",true);
        }

        public void ShowMessageBox(string title, string message)
        {
            dialog?.ShowMessageBox(title, message);
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
