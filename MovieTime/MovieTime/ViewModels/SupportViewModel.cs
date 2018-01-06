using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieTime.ViewModels
{
    public class SupportViewModel: ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _goToMainPageCommand;
        private INavigationService _navigationService;

        public SupportViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

        }
        public ICommand GoToMainPageCommand
        {
            get
            {
                if (_goToMainPageCommand == null)
                    _goToMainPageCommand = new RelayCommand(() => GoToMainPage());
                return _goToMainPageCommand;
            }
        }
        private void GoToMainPage()
        {
            _navigationService.NavigateTo("MainPage");
        }
    }
}
