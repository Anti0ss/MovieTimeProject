using MovieTime.Erreur;
using MovieTime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MovieTime.DAO
{
    public class UtilisateurService
    {
        private HttpClient pc;
        private ApplicationErreur erreur;
        // gérer la connexion de l'administrateur (vérification connexion api et rôle=il faut qu'il soit admin)

        public async Task<ApplicationErreur>UtilisateurToken(string username,string password)
        {
            erreur = new ApplicationErreur();
            var form = new Dictionary<string, string>
            {
                 {"grant_type","password"},
                 {"username",username},
                 {"password",password},
            };
            pc = new HttpClient();
            try
            {
                var tokenResponse = pc.PostAsync(new Uri(AppApi.AddresseApi + "/token"), new FormUrlEncodedContent(form)).Result;        
                if (tokenResponse.IsSuccessStatusCode)
                {
                    var token = tokenResponse.Content.ReadAsAsync<Token>(new[] { new JsonMediaTypeFormatter() }).Result;
                    AppApi.Token = token.AccessToken;
                    erreur.MessageErreur = tokenResponse.Content.ReadAsStringAsync().Result;
                    erreur.Ok = tokenResponse.IsSuccessStatusCode;
                    return erreur;
                }
                else
                {
                    erreur.MessageErreur = tokenResponse.Content.ReadAsStringAsync().Result;
                    erreur.Ok = tokenResponse.IsSuccessStatusCode;
                    return erreur;
                }
            }
            catch(Exception e)
            {
                erreur.MessageErreur = e.ToString();
                erreur.Ok = false;
                return erreur;
            }
        }





        // recherche un ou plusieurs utilisateur modification du "rôle" d'un utilisateur suppression d'un utilisateur 
        public UtilisateurService()
        {
            pc = new HttpClient();
            erreur = new ApplicationErreur();
        }

        //utiliser ApplicationErreur 
        //verifier que l'utilisateur soit bien un administrateur pour login et qu'il ne soit pas déjà admin pour la modification en administrateur
        public async Task <IEnumerable<ApplicationUser>> GetUtilisateur()
        {
            pc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AppApi.Token);
            var json = await pc.GetStringAsync(new Uri(AppApi.AddresseApi + "/api/Users"));
            ApplicationUser[] dataRetour = JsonConvert.DeserializeObject<ApplicationUser[]>(json);
            return dataRetour;
        }

        public async Task DeleteUtilisateur(int Id)
        {
            pc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AppApi.Token);
            await pc.DeleteAsync(new Uri(AppApi.AddresseApi + "/api/utilisateur/" + Id));
        }

        //manque promotion utilisateur
    }
}
