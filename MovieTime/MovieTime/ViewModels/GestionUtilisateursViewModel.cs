using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using MovieTime.DAO;
using MovieTime.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieTime.ViewModels
{
    public class GestionUtilisateursViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _goToMainPageCommand;
        private INavigationService _navigationService;

        public GestionUtilisateursViewModel(INavigationService navigationService)
        {
            InitializeAsync();
            _navigationService = navigationService;

        }
        public async Task InitializeAsync()
        {
            var utilisateurService = new UtilisateurService();
            var util = await utilisateurService.GetUtilisateur();
            UtilisateurList = new ObservableCollection<ApplicationUser>(util);
            UtilisateurDefini = new ObservableCollection<ApplicationUser>();


            foreach (ApplicationUser utilPropo in UtilisateurList)
            {
                ApplicationUser _utilisateurDefinitive = new ApplicationUser(utilPropo.Id, utilPropo.Pseudo, utilPropo.Nom, utilPropo.Prenom, utilPropo.Mdp, utilPropo.Mail, utilPropo.NumTel);
                UtilisateurDefini.Add(_utilisateurDefinitive);
            }
            if (UtilisateurDefini.Count() == 0)
            {
                var dialogue = new Windows.UI.Popups.MessageDialog("Aucun résultat");
                dialogue.ShowAsync();
            }
        }

        private ObservableCollection<ApplicationUser> _utilisateurList;
        public ObservableCollection<ApplicationUser> UtilisateurList
        {
            get { return _utilisateurList; }
            set
            {

                _utilisateurList = value;
                RaisePropertyChanged("UtilisateurList");
            }
        }
        private ObservableCollection<ApplicationUser> _utilisateurDefini;
        public ObservableCollection<ApplicationUser> UtilisateurDefini
        {
            get { return _utilisateurDefini; }
            set
            {
                _utilisateurDefini = value;
                RaisePropertyChanged("UtilisateurDefini");
            }
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

        private String _nom;
        public String Nom
        {
            get { return _nom; }
            set
            {
                _nom = value;
                RaisePropertyChanged("Nom");
            }
        }

        private String _prenom;
        public String Prenom
        {
            get { return _prenom; }
            set
            {
                _prenom = value;
                RaisePropertyChanged("Prenom");
            }
        }
        private String _mail;
        public String Mail
        {
            get { return _mail; }
            set
            {
                _mail = value;
                RaisePropertyChanged("Mail");
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
            _navigationService.NavigateTo("MainPage");
        }
    }
}
