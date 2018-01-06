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
using Windows.UI.Xaml.Navigation;

namespace MovieTime.ViewModels
{
    public class GestionFilmsViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _goToMainPageCommand;
        private ICommand _goToAjoutFilmCommand;
        private ICommand _goToSupprimerFilmCommand;
        private ICommand _goToModifierFilmCommand;
        private ICommand _goToRechercherFilmCommand;
        private INavigationService _navigationService;

        public GestionFilmsViewModel(INavigationService navigationService)
        {
            InitializeAsync();
            _navigationService = navigationService;

        }
        public async Task InitializeAsync()
        {
            var filmService = new FilmService();
            var film = await filmService.GetFilm();
            if (film != null)
            {
                FilmList = new ObservableCollection<Film>(film);
                FilmDefini = new ObservableCollection<Film>();
                ObservableCollection<int> listIndex = new ObservableCollection<int>();

                foreach (Film filmPropo in FilmList)
                {
                    Film _filmDefinitive = new Film(filmPropo.FilmId, filmPropo.Titre, filmPropo.Description, filmPropo.Duree, filmPropo.DateSortie, filmPropo.Realisateur, filmPropo.AvisDuSite, filmPropo.Categorie);
                    FilmDefini.Add(_filmDefinitive);
                }
                if (Recherche != null)
                {
                    listIndex.Clear();
                    for (int indiceNom = 0; indiceNom < FilmDefini.Count(); indiceNom++)
                    {
                        if (!FilmDefini[indiceNom].Titre.Equals((string)Recherche) && !FilmDefini[indiceNom].Realisateur.Equals((string)Recherche))
                        {
                            listIndex.Add(indiceNom);
                        }
                    }
                    for (int indexNom = listIndex.Count() - 1; indexNom > -1; indexNom--)
                    {
                        FilmDefini.RemoveAt(listIndex[indexNom]);
                    }
                }
                if (FilmDefini.Count() == 0)
                {
                    var dialogue = new Windows.UI.Popups.MessageDialog("Aucun résultat");
                    dialogue.ShowAsync();
                }
            }
            else
            {
                var dialogue = new Windows.UI.Popups.MessageDialog("Problème de connection");
                dialogue.ShowAsync();
            }
        }
        private ObservableCollection<Film> _filmList;
        public ObservableCollection<Film> FilmList
        {
            get { return _filmList; }
            set
            {

                _filmList = value;
                RaisePropertyChanged("FilmList");
            }
        }
        private ObservableCollection<Film> _filmDefini;
        public ObservableCollection<Film> FilmDefini
        {
            get { return _filmDefini; }
            set
            {
                _filmDefini = value;
                RaisePropertyChanged("FilmDefini");
            }
        }
        private Film _filmSelection;
        public Film FilmSelection
        {
            get { return _filmSelection; }
            set
            {

                _filmSelection = value;
                RaisePropertyChanged("FilmDefini");
            }
        }
        private String _titre;
        public String Titre
        {
            get { return _titre; }
            set
            {
                _titre = value;
                RaisePropertyChanged("Titre");
            }
        }
        private String _realisateur;
        public String Realisateur
        {
            get { return _realisateur; }
            set
            {
                _realisateur = value;
                RaisePropertyChanged("Realisateur");
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
        private DateTime _dateSortie;
        public DateTime DateSortie
        {
            get { return _dateSortie; }
            set
            {
                _dateSortie = value;
                RaisePropertyChanged("DateSortie");
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

        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set
            {

                _nom = value;
                RaisePropertyChanged("Nom");

            }
        }
        private string _recherche;
        public string Recherche
        {
            get { return _recherche; }
            set
            {

                _recherche = value;
                RaisePropertyChanged("Recherche");

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
        public ICommand GoToModifierFilmCommand
        {
            get
            {
                if (_goToModifierFilmCommand == null)
                    _goToModifierFilmCommand = new RelayCommand(() => GoToModifierFilmView());
                return _goToModifierFilmCommand;
            }
        }
        private void GoToModifierFilmView()
        {
            if (FilmSelection != null)
            {
               // FilmService filmService = new FilmService();
                _navigationService.NavigateTo("ModifierFilmView",FilmSelection);
            }
            else
            {
                var dialogue = new Windows.UI.Popups.MessageDialog("Un film doit être sélectionné");
                dialogue.ShowAsync();
            }
        }
        public ICommand GoToRechercherFilmCommand
        {
            get
            {
                if (_goToRechercherFilmCommand == null)
                    _goToRechercherFilmCommand = new RelayCommand(() => GoToRechercherFilmView());
                return _goToRechercherFilmCommand;

            }
        }
        private void GoToRechercherFilmView()
        {
            //Recherche pas vraiment utile mais si on souhaite étendre la recherche plud tard il faut créer un modèle correspondant ici et l'initialiser ici.
            String Recherche = Nom;
            _navigationService.NavigateTo("GestionFilmsView", Recherche);
        }
        public ICommand GoToSupprimerFilmCommand
        {
            get
            {
                if (_goToSupprimerFilmCommand == null)
                    _goToSupprimerFilmCommand = new RelayCommand(() => GoToSupprimerFilmAsync());
                return _goToSupprimerFilmCommand;
            }
        }
        private async Task GoToSupprimerFilmAsync()
        {

            if(FilmSelection!=null)
            {
                FilmService filmService = new FilmService();
                await filmService.DeleteFilm(FilmSelection.FilmId);
                _navigationService.NavigateTo("GestionFilmsView");
            }
            else
            {
                var dialogue = new Windows.UI.Popups.MessageDialog("Un film doit être sélectionné");
                dialogue.ShowAsync();
            }
        }
        public void OnNavigatedTo(NavigationEventArgs e)
        {
            Recherche = (String)e.Parameter;
        }
    }
}
