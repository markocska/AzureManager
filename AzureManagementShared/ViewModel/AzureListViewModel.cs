using AzureManagementLib.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using AzureManagementLib.Models;
using Microsoft.Practices.ServiceLocation;

namespace AzureManagementShared.ViewModel
{
    public class AzureListViewModel<T, K> : ViewModelBase
        where T : IAzureResource
        where K : AzureViewModelBase
    {

        private readonly IAzureService<T> _azureService;
        private readonly INavigationService _navigationService;
        private bool _isLoading;
        private RelayCommand _refreshCommand;
        private RelayCommand<K> _showDetailsCommand;

        Func<T, K> resourceConstructor;

        public ObservableCollection<K> Resources { get; private set; }

        public RelayCommand RefreshCommand { 
            get
            {
                return _refreshCommand
                    ?? (_refreshCommand = new RelayCommand(
                        async () =>
                        {
                            Resources.Clear();
                            _isLoading = true;

                            try
                            {
                                var resourceList = await _azureService.GetResourcesAsync();

                                foreach (var resource in resourceList)
                                {
                                    //TODO szebben
                                    Resources.Add(resourceConstructor(resource));
                                }

                            }
                            catch (Exception ex)
                            {
                                var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                                dialog.ShowError(ex, "Error when refreshing :-(", "OK", null);
                            }
                            RaisePropertyChanged("Resources");
                            _isLoading = false;
                        }
                        ));
            }
        }

        public RelayCommand<K> ShowDetailsCommand
        {
            get
            {
                return _showDetailsCommand
                    ?? (_showDetailsCommand = new RelayCommand<K>(
                        resource =>
                        {
                            if (!ShowDetailsCommand.CanExecute(resource))
                            {
                                return;
                            }

                            _navigationService.NavigateTo(
                                ViewModelLocator.searchPageByViewModelType(
                                    typeof(K)),resource);
                        },
                        resource => resource != null));
            }
        }



        public AzureListViewModel(
            INavigationService navigationService,
            IAzureService<T> azureService,
            Func<T,K> resourceConstructor
            ) 
        {
            _azureService = azureService;
            _navigationService = navigationService;
            this.resourceConstructor = resourceConstructor;
            Resources = new ObservableCollection<K>();
        }


    }
}
