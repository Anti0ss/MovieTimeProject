using MovieTimeWebAPI.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace MovieTimeWebAPI.Controllers
{
    public class ListingsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Listings
        public IEnumerable<Listing> GetListing()
        {


            return db.Listing.ToList();
        }

        // GET: api/Listings/5
        [ResponseType(typeof(Listing))]
        public IHttpActionResult GetListing(int id)
        {
            Listing Listing = db.Listing.Find(id);
            if (Listing == null)
            {
                return NotFound();
            }

            return Ok(Listing);
        }
        // GET: api/Listings/?filmId=""&userId=""
        [ResponseType(typeof(Listing))]
        public IQueryable<Listing> GetListingByFilmIdandUserId(int filmId, string userId)
        {

            var listing = db.Listing.Include(c => c.Film).Include(c=> c.User).Include(c => c.Film.Categorie).Include(c => c.User.Claims).Include(c => c.User.Logins).Include(c => c.User.Roles).Where(p => p.Film.FilmId.Equals(filmId)&& p.User.Id.Contains(userId));
            //Include(c => c.Titre).Where(p => p.Titre.Contains(name)|| p.Realisateur.Contains(name) );

            return listing;
        }
        // GET: api/Listings/?filmId=
        [ResponseType(typeof(Listing))]
        public IQueryable<Listing> GetListingByFilmId(int filmId)
        {

            var listing = db.Listing.Include(c => c.Film).Include(c => c.User).Include(c=>c.Film.Categorie).Include(c => c.User.Claims).Include(c => c.User.Logins).Include(c => c.User.Roles).Where(p => p.Film.FilmId.Equals(filmId));
            //Include(c => c.Titre).Where(p => p.Titre.Contains(name)|| p.Realisateur.Contains(name) );

            return listing;
        }
        // GET: api/Listings/?UserId=
        [ResponseType(typeof(Listing))]
        public IQueryable<Listing> GetListingByUserId(string UserId)
        {
            var listing = db.Listing.Include(c => c.Film).Include(c => c.User).Include(c => c.Film.Categorie).Include(c=>c.User.Claims).Include(c=>c.User.Logins).Include(c=>c.User.Roles).Where(p => p.User.Id.Contains(UserId));
            //Include(c => c.Titre).Where(p => p.Titre.Contains(name)|| p.Realisateur.Contains(name) );

            return listing;
        }

        // PUT: api/Listings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutListing(int id, Listing Listing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Listing.ListingId)
            {
                return BadRequest();
            }

            db.Entry(Listing).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Listings
        [ResponseType(typeof(Listing))]
        public async Task<IHttpActionResult> PostListing(ListingCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var identity = User.Identity as ClaimsIdentity;
            Claim identityClaim = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            ApplicationUser user = db.Users.FirstOrDefault(u => u.Id == identityClaim.Value);
            Listing listing = new Listing() { AvisUtil = model.AvisUtil, Visionnage = model.Visionnage };
            listing.Film = await db.Film.FindAsync(model.FilmId);
            listing.User = user;
            db.Listing.Add(listing);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ListingExists(listing.ListingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return Created("api/Listings", listing);
        }

        // DELETE: api/Listings/5
        [ResponseType(typeof(Listing))]
        public IHttpActionResult DeleteListing(int id)
        {
            Listing Listing = db.Listing.Find(id);
            if (Listing == null)
            {
                return NotFound();
            }

            db.Listing.Remove(Listing);
            db.SaveChanges();

            return Ok(Listing);
        }
        // GET: api/Listings/?filmId=""&userId=""
        /*[ResponseType(typeof(bool))]
        public bool GetListingByFilmIdandUserId(int filmId, string userId)
        {
            bool exist = false;
            var listing = db.Listing.Include(c => c.Film).Include(c => c.User).Include(c => c.Film.Categorie).Include(c => c.User.Claims).Include(c => c.User.Logins).Include(c => c.User.Roles).Where(p => p.Film.FilmId.Equals(filmId) && p.User.Id.Contains(userId));
            //Include(c => c.Titre).Where(p => p.Titre.Contains(name)|| p.Realisateur.Contains(name) );

            if (listing != null)
            {
                exist = true;
            }
            return exist;
        }*/



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ListingExists(int id)
        {
            return db.Listing.Count(e => e.ListingId == id) > 0;
        }
    }
}