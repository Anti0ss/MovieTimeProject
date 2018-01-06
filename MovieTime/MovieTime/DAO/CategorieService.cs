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
    public class CategorieService
    {
        //affichage des categories
        public async Task<IEnumerable<Categorie>> GetCategorie()
        {
            var pc = new HttpClient();
            try
            {
                pc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AppApi.Token);
                var json = await pc.GetStringAsync(new Uri(AppApi.AddresseApi + "/api/Categories"));
                Categorie[] retourData = JsonConvert.DeserializeObject<Categorie[]>(json);
                return retourData;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
