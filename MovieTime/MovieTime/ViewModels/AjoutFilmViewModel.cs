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
    public class AjoutFilmViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _goToGestionFilmsCommand;
       // private ICommand _goToGestionFilmsBackCommand;
        private ICommand _goToMainPageCommand;
        private INavigationService _navigationService;

        public AjoutFilmViewModel(INavigationService navigationService)
        {
            DateSortie = DateTime.Now;
            InitializeAsync();
            _navigationService = navigationService;

        }
        public async Task InitializeAsync()
        {
            var categorie = new CategorieService();
            var cat = await categorie.GetCategorie();
            if (cat != null)
            {
                CategorieList = new ObservableCollection<Categorie>(cat);
            }
            else
            {
                var dialogue = new Windows.UI.Popups.MessageDialog("Problème de connection");
                dialogue.ShowAsync();
            }
        }
        private string _titre;
        public string Titre
        {
            get { return _titre; }
            set
            {
                _titre = value;
                RaisePropertyChanged("Titre");
            }
        }
        private string _realisateur;
        public string Realisateur
        {
            get { return _realisateur; }
            set
            {
                _realisateur = value;
                RaisePropertyChanged("Realisateur");
            }
        }
        private ObservableCollection<Categorie> _categorieList;
        public ObservableCollection<Categorie> CategorieList
        {
            get { return _categorieList; }
            set
            {

                _categorieList = value;
                RaisePropertyChanged("CategorieList");
            }
        }
        private Categorie _categorie;
        public Categorie Categorie
        {
            get { return _categorie; }
            set
            {
                if (_categorie == value)
                {
                    return;
                }
                _categorie = value;
                RaisePropertyChanged("Categorie");
            }
        }
        private DateTimeOffset _dateSortie;
        public DateTimeOffset DateSortie
        {
            get { return _dateSortie; }
            set
            {
                _dateSortie = value;
                RaisePropertyChanged("DateSortie");
            }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged("Description");
            }
        }
        private int _duree;
        public int Duree
        {
            get { return _duree; }
            set
            {
                _duree = value;
                RaisePropertyChanged("Duree");
            }
        }
        private double _avisDuSite;
        public double AvisDuSite
        {
            get { return _avisDuSite; }
            set
            {
                _avisDuSite = value;
                RaisePropertyChanged("AvisDuSite");
            }
        }

       /* public ICommand GoToGestionFilmsBackCommand
        {
            get
            {
                if (_goToGestionFilmsBackCommand == null)
                    _goToGestionFilmsBackCommand = new RelayCommand(() => GoToGestionFilmsBack());
                return _goToGestionFilmsBackCommand;
            }
        }
        private void GoToGestionFilmsBack()
        {
            _navigationService.NavigateTo("GestionFilmsView");
        }*/
        public ICommand GoToGestionFilmsCommand
        {
            get
            {
                if (_goToGestionFilmsCommand == null)
                    _goToGestionFilmsCommand = new RelayCommand(() => GoToGestionFilmsPage());
                return _goToGestionFilmsCommand;
            }
        }
        private void GoToGestionFilmsPage()
        {
            DateTime TestDate = new DateTime(1895, 5, 25, 0, 0, 0);
            if (Duree < 0 || AvisDuSite < 0 || AvisDuSite > 10)
            {
                var dialogue = new Windows.UI.Popups.MessageDialog("La durée doit être supérieur à 0 et l'avis doit être entre 0 et 10(compris)");
                dialogue.ShowAsync();
            }
            else
            {
                if (DateSortie > TestDate)
                {
                    if ((String.IsNullOrWhiteSpace(Titre) == false && String.IsNullOrWhiteSpace(Realisateur) == false && Categorie != null && DateSortie != null && String.IsNullOrWhiteSpace(Description) == false))
                    {
                        // _navigationService.NavigateTo("GestionFilmsView");
                        CreateFilm nouveauFilm = new CreateFilm(Categorie.IdCategorie, Titre, Description, Duree, DateSortie.DateTime, Realisateur, AvisDuSite);
                        AjouterFilm(nouveauFilm);
                    }
                    else
                    {
                        var dialogue = new Windows.UI.Popups.MessageDialog("Il y a un champs qui n'a pas été remplis!!!");
                        dialogue.ShowAsync();

                    }
                }
                else
                {
                    var dialogue = new Windows.UI.Popups.MessageDialog("La date de sortie du film ne peut pas être inférieur à la date de sortie du premier film de l'Histoire(25 mai 1895).");
                    dialogue.ShowAsync();
                }
            }
        }
        public async void AjouterFilm(CreateFilm nouveauFilm)
        {
            var filmService = new FilmService();
            await filmService.AddFilm(nouveauFilm);
            _navigationService.NavigateTo("GestionFilmsView");

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
