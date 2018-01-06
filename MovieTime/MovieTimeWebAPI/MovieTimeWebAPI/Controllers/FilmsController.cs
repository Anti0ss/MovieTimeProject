using MovieTimeWebAPI.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace MovieTimeWebAPI.Controllers
{
    public class FilmsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Films
        public IEnumerable<Film> GetFilms()
        {     
            return db.Film.ToList();
        }

        // GET: api/Films/5
        [ResponseType(typeof(Film))]
        public IHttpActionResult GetFilm(int id)
        {
            Film Film = db.Film.Find(id);
            if (Film == null)
            {
                return NotFound();
            }

            return Ok(Film);
        }
        // GET: api/Films/?name=
        [ResponseType(typeof(Film))]
        public IQueryable<Film> GetFilmByTitleOrReal(string name)
        {
            
            var films = db.Film.Include(c=>c.Categorie).Where(p => p.Titre.Contains(name)|| p.Realisateur.Contains(name));
            //Include(c => c.Titre).Where(p => p.Titre.Contains(name)|| p.Realisateur.Contains(name) );

            return films;
        }
        // GET: api/Films/?nomCategorie=
        [ResponseType(typeof(Film))]
        public IQueryable<Film> GetFilmByNomCategorie(string nomCategorie)
        {
            //filmDb.Categorie = await db.Categorie.FindAsync(model.IdCategorie)
            //Categorie categorie=await db.Categorie.FindAsync(nomCategorie);
            var films = db.Film.Include(c => c.Categorie).Where(p=>p.Categorie.NomCategorie.Contains(nomCategorie));
            //Include(c => c.Titre).Where(p => p.Titre.Contains(name)|| p.Realisateur.Contains(name) );

            return films ;
        }


        // PUT: api/Films/5
        [ResponseType(typeof(Film))]
        public IHttpActionResult PutFilm(int id, Film filmDb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != filmDb.FilmId)
            {
                return BadRequest();
            }
            db.Entry(filmDb).State = EntityState.Modified;
            /* //inutile de faire filmDb on peut passer directement model dans db.Entry(filmDb).State = EntityState.Modified; 
             Film filmDb = new Film();
             filmDb.FilmId = model.FilmId;
             filmDb.Titre = model.Titre;
             filmDb.Categorie = model.Categorie;
             filmDb.AvisDuSite = model.AvisDuSite;
             filmDb.DateSortie = model.DateSortie;
             filmDb.Description = model.Description;
             filmDb.Realisateur = model.Realisateur;
             filmDb.Duree = model.Duree;
             db.Entry(filmDb).State = EntityState.Modified;*/
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
                /* Film Film = await db.Film.FindAsync(id);

                 //db.Entry(Film).State = EntityState.Modified;

                 try
                 {
                     Film filmDb = new Film();
                     filmDb.FilmId = id;
                     filmDb.Titre = model.Titre;
                     filmDb.Categorie = await db.Categorie.FindAsync(model.IdCategorie);
                     filmDb.AvisDuSite = model.AvisDuSite;
                     filmDb.DateSortie = model.DateSortie;
                     filmDb.Description = model.Description;
                     filmDb.Realisateur = model.Realisateur;
                     filmDb.Duree = model.Duree;
                     db.Entry(filmDb).State = EntityState.Modified;
                     await db.SaveChangesAsync();
                  }
                  catch (DbUpdateConcurrencyException)
                  {
                      if (!FilmExists(id))
                      {
                          return NotFound();
                      }
                      else
                      {
                          throw;
                      }
                  }

                 return StatusCode(HttpStatusCode.NoContent);*/
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Films
        [ResponseType(typeof(Film))]
        public async Task <IHttpActionResult> PostFilm(CreateFilm @film)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Film filmDb = new Film();
            filmDb.Titre = @film.Titre;
            filmDb.Categorie=await db.Categorie.FindAsync(@film.IdCategorie);
            filmDb.AvisDuSite = @film.AvisDuSite;
            filmDb.DateSortie = @film.DateSortie;
            filmDb.Description = @film.Description;
            filmDb.Realisateur = @film.Realisateur;
            filmDb.Duree = @film.Duree;
            db.Film.Add(filmDb);
            await db.SaveChangesAsync();

            return Created("api/Films", filmDb);
        }

        // DELETE: api/Films/5
        [ResponseType(typeof(Film))]
        public async Task <IHttpActionResult> DeleteFilm(int id)
        {
            Film @film = await db.Film.FindAsync(id);
            if (@film == null)
            {
                return NotFound();
            }

            db.Film.Remove(@film);
            await db.SaveChangesAsync();

            return Ok(@film);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FilmExists(int id)
        {
            return db.Film.Count(e => e.FilmId == id) > 0;
        }
    }
}
