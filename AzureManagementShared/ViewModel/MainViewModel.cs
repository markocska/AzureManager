using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureManagementShared.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private RelayCommand<string> _navigateToPage;
        private RelayCommand _loginCommand;
        private RelayCommand _logoutCommand;

        private RelayCommand<string> NavigateToPageCommand
        {
            get
            {
                return _navigateToPage
                    ?? (new RelayCommand<string>(
                        page =>
                        {
                            if (!NavigateToPageCommand.CanExecute(page))
                            {
                                return;
                            }
                            _navigationService.NavigateTo(page);
                        },
                        page => ViewModelLocator.PageExists(page)
                        ));
            }
        }

        private RelayCommand LoginCommand
        {
            get
            {
                return _loginCommand
                    ?? ( new RelayCommand(
                        () =>
                        {

                        }
                        )
                    
                    )
            }
        }
    }
}
