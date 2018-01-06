using MovieTime.Erreur;
using MovieTime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MovieTime.DAO
{
    public class FilmService
    {
        // affichag tout les film ou un film (recherche) suppression un film ajout un film modification un film

        private HttpClient pc;
        private ApplicationErreur erreur;

        public FilmService()
        {
            pc = new HttpClient();
            erreur = new ApplicationErreur();
        }

        //utiliser ApplicationErreur 
       
        public async Task<IEnumerable<Film>> GetFilm()
        {
            pc = new HttpClient();
            try
            {
                pc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AppApi.Token);
                var json = await pc.GetStringAsync(new Uri(AppApi.AddresseApi + "/api/Films"));
                Film[] dataRetour = JsonConvert.DeserializeObject<Film[]>(json);
                return dataRetour;
            }catch(Exception e)
            {
                return null;
            }
        }

        public async Task DeleteFilm (int Id)
        {

                pc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AppApi.Token);
                await pc.DeleteAsync(new Uri(AppApi.AddresseApi + "/api/Films/" + Id));
                
        }

        public async Task AddFilm( CreateFilm film)
        {
                pc.BaseAddress = new Uri(AppApi.AddresseApi + "/api/Films");
                pc.DefaultRequestHeaders.Authorization= new AuthenticationHeaderValue("Bearer", AppApi.Token);
                var httpResponse = await pc.PostAsJsonAsync(pc.BaseAddress, film);
                

        }
        public async Task ModifierFilm(int idFilm,Film film)
        {
                pc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AppApi.Token);
                var httpResponse = await pc.PutAsJsonAsync(new Uri(AppApi.AddresseApi + "/api/Films/"+idFilm),film);


        }

    }
}
