using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Shared.UI.Services.DialogBox
{
    public interface IConfirmationDialogService : IDialogServiceBase<bool?>
    {
        Task<bool?> ShowAsync(string title, string message, string confirmText , string cancelText);
    }




public class ConfirmationDialogService : IConfirmationDialogService
    {
        private readonly IDialogService _dialogService;

        public ConfirmationDialogService(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public async Task<bool?> ShowAsync(string message, string title, string confirmText, string cancelText)
        {
            var parameters = new DialogParameters
            {
                ["ContentText"] = message,
                ["ButtonText"] = confirmText,
                ["CancelButtonText"] = cancelText,
                ["Color"] = Color.Primary
            };

            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small };

            var dialog = await _dialogService.ShowAsync<MudDialog>(title, parameters, options);
            return (await dialog.Result)?.Canceled == false;
        }

        public async Task<bool?> ShowAsync(string message, string? title = null)
        {
           return await ShowAsync(title ?? "",message, "Yes", "No");
        }

    }

}
