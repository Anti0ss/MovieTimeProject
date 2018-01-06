using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using MovieTime.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTime.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            //IoC, c'est pour stocker l'instance qui implémente l'interface.
            //avantage est que tu peux alors changer l'instance sans changer le code
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<GestionFilmsViewModel>();
            SimpleIoc.Default.Register<GestionUtilisateursViewModel>();
            SimpleIoc.Default.Register<SupportViewModel>();
            SimpleIoc.Default.Register<AjoutFilmViewModel>();
            SimpleIoc.Default.Register<ModifierFilmViewModel>();
            NavigationService navigationPages = new NavigationService();
            SimpleIoc.Default.Unregister<INavigationService>();
            SimpleIoc.Default.Register<INavigationService>(() => navigationPages);

            navigationPages.Configure("LoginView", typeof(LoginView));
            navigationPages.Configure("MainPage", typeof(MainPage));
            navigationPages.Configure("GestionFilmsView", typeof(GestionFilmsView));
            navigationPages.Configure("GestionUtilisateursView", typeof(GestionUtilisateursView));
            navigationPages.Configure("SupportView", typeof(SupportView));
            navigationPages.Configure("AjoutFilmView", typeof(AjoutFilmView));
            navigationPages.Configure("ModifierFilmView", typeof(ModifierFilmView));
        }
        //Propriétées
        public MainViewModel MainPage
        {
            get
            {
                SimpleIoc.Default.Unregister<MainViewModel>();
                SimpleIoc.Default.Register<MainViewModel>();
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public LoginViewModel LoginView
        {
            get
            {
                SimpleIoc.Default.Unregister<LoginViewModel>();
                SimpleIoc.Default.Register<LoginViewModel>();
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }
        public GestionFilmsViewModel GestionFilmsView
        {
            get
            {
                SimpleIoc.Default.Unregister<GestionFilmsViewModel>();
                SimpleIoc.Default.Register<GestionFilmsViewModel>();
                return ServiceLocator.Current.GetInstance<GestionFilmsViewModel>();
            }
        }
        public GestionUtilisateursViewModel GestionUtilisateursView
        {
            get
            {
                SimpleIoc.Default.Unregister<GestionUtilisateursViewModel>();
                SimpleIoc.Default.Register<GestionUtilisateursViewModel>();
                return ServiceLocator.Current.GetInstance<GestionUtilisateursViewModel>();
            }
        }
        public SupportViewModel SupportView
        {
            get
            {
                SimpleIoc.Default.Unregister<SupportViewModel>();
                SimpleIoc.Default.Register<SupportViewModel>();
                return ServiceLocator.Current.GetInstance<SupportViewModel>();
            }
        }
        public AjoutFilmViewModel AjoutFilmView
        {
            get
            {
                SimpleIoc.Default.Unregister<AjoutFilmViewModel>();
                SimpleIoc.Default.Register<AjoutFilmViewModel>();
                return ServiceLocator.Current.GetInstance<AjoutFilmViewModel>();
            }
        }
        public ModifierFilmViewModel ModifierFilmView
        {
            get
            {
                SimpleIoc.Default.Unregister<ModifierFilmViewModel>();
                SimpleIoc.Default.Register<ModifierFilmViewModel>();
                return ServiceLocator.Current.GetInstance<ModifierFilmViewModel>();
            }
        }

    }
}
