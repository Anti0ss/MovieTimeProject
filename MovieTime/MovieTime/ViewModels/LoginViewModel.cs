using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using MovieTime.DAO;
using MovieTime.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieTime.ViewModels
{
    public class LoginViewModel:ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _goToMainPageCommand;
        private INavigationService _navigationService;
        private string _token;

        public LoginViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
        }


        private String _pseudo;
        public String Pseudo
        {
            get { return _pseudo; }
            set
            {
                _pseudo = value;
                RaisePropertyChanged("Pseudo");
            }
        }

        private String _mdp;
        public String Mdp
        {
            get { return _mdp; }
            set
            {
                _mdp = value;
                RaisePropertyChanged("Mdp");
            }
        }

        public string Token
        {
            get { return _token; }
            set
            {
                _token = value;
                RaisePropertyChanged("Token");
            }
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
            if(Pseudo !=null && Mdp != null)
            {
                UtilisateurToken(Pseudo, Mdp);
            }
            else
            {
                var dialogue = new Windows.UI.Popups.MessageDialog("Les champs Pseudo et Password doivent être remplis");
                dialogue.ShowAsync();
            }
        }
        public async Task UtilisateurToken(string pseudo, string mdp)
        {
            UtilisateurService utilService = new UtilisateurService();
            var util = await utilService.UtilisateurToken(pseudo, mdp);

            if (util.Ok)
            {
                _navigationService.NavigateTo("MainPage", Token);
            }
            else
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Le login ou le mot de passe est incorrect");
                dialog.ShowAsync();
            }
        }
    }
}
