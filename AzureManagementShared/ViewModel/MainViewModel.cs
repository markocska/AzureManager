using Android.App;
using AzureManagementLib;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureManagementShared.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private RelayCommand<string> _navigateToPage;
        private RelayCommand<PlatformParameters> _loginCommand;
        private RelayCommand<PlatformParameters> _logoutCommand;

        private AzureResourceManager resourceManager;

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
        
        private RelayCommand<PlatformParameters> LoginCommand
        {
            get
            {
                return _loginCommand
                    ?? (new RelayCommand<PlatformParameters>(
                        async (PlatformParameters platformParams) =>
                        {
#if __ANDROID__

                            resourceManager = await AuthenticationManager.Authenticate(platformParams);
#endif
                        }
                        ));
            }
        }
    }
}
