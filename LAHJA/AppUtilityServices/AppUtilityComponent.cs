using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shared.Constants;
using System.Globalization;


namespace LAHJA.ContextServices
{
    public class AppUtilityComponentService
    {
        private readonly NavigationManager Navigation;
        private readonly ISnackbar snackbar;

        public string lg { get => _lg; }

        private string _lg = string.IsNullOrWhiteSpace(CultureInfo.CurrentUICulture.Name)
                                 ? ConstantsApp.DEFAULT_LANGUAGE
                                 : CultureInfo.CurrentUICulture.Name;

        public AppUtilityComponentService(NavigationManager navigation, ISnackbar snackbar)
        {
            Navigation = navigation;
            this.snackbar = snackbar;
        }

        public void GoToWithReload(string url)
        {
            Navigation.NavigateTo(url, true);
        }

        public void GoTo(string url)
        {
            Navigation.NavigateTo(url);
        }


        public void ShowErrorNotify(string message)
        {

            snackbar.Add(message, severity: Severity.Error);
        }

        public void ShowSuccessNotify(string message)
        {

            snackbar.Add(message, severity: Severity.Success);
        }
        public void ShowWarningNotify(string message)
        {

            snackbar.Add(message, severity: Severity.Warning);
        }
    }


    public class AppUtilityComponent : ComponentBase
    {
        [Inject] public AppUtilityComponentService AppUtilityService { get; set; }
  

     
        

     
    }
}
