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
    public class MainViewModel:ViewModelBase,INotifyPropertyChanged
    {
        private ICommand _goToGestionFilmsCommand;
       // private ICommand _goToGestionUtilisateursCommand;
        private ICommand _goToAjoutFilmCommand;
        private ICommand _goToSupportCommand;
        private INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public ICommand GoToGestionFilmsCommand
        {
            get
            {
                if (_goToGestionFilmsCommand == null)
                    _goToGestionFilmsCommand = new RelayCommand(() => GoToGestionFilmsView());
                return _goToGestionFilmsCommand;  
            }
        }
        private void GoToGestionFilmsView()
        {
            _navigationService.NavigateTo("GestionFilmsView");
        }

       /* public ICommand GoToGestionUtilisateursCommand
        {
            get
            {
                if (_goToGestionUtilisateursCommand == null)
                    _goToGestionUtilisateursCommand = new RelayCommand(() => GoToGestionUtilisateursView());
                return _goToGestionUtilisateursCommand;
            }
        }
        private void GoToGestionUtilisateursView()
        {
            _navigationService.NavigateTo("GestionUtilisateursView");
        }*/
        public ICommand GoToSupportCommand
        {
            get
            {
                if (_goToSupportCommand == null)
                    _goToSupportCommand = new RelayCommand(() => GoToSupportView());
                return _goToSupportCommand;
            }
        }
        private void GoToSupportView()
        {
            _navigationService.NavigateTo("SupportView");
        }
        public ICommand GoToAjoutFilmCommand
        {
            get
            {
                if (_goToAjoutFilmCommand == null)
                    _goToAjoutFilmCommand = new RelayCommand(() => GoToAjoutFilmView());
                return _goToAjoutFilmCommand;
            }
        }
        private void GoToAjoutFilmView()
        {
            _navigationService.NavigateTo("AjoutFilmView");
        }

    }
}
