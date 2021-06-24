using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Lab5WebApi.Models;

namespace Lab5WebApi.Controllers
{
    public class CocktailController : ApiController
    {
        private CocktailContext db = new CocktailContext();

        // GET: api/Cocktail
        public IQueryable<Cocktail> GetCocktailSet()
        {
            return db.CocktailSet;
        }

        // GET: api/Cocktail/5
        [ResponseType(typeof(Cocktail))]
        public IHttpActionResult GetCocktail(int id)
        {
            Cocktail Cocktail = db.CocktailSet.Find(id);
            if (Cocktail == null)
            {
                return NotFound();
            }

            return Ok(Cocktail);
        }

        // PUT: api/Cocktail/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCocktail(int id, Cocktail Cocktail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Cocktail.Id)
            {
                return BadRequest();
            }

            db.Entry(Cocktail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CocktailExists(id))
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

        // POST: api/Cocktail
        [ResponseType(typeof(Cocktail))]
        public IHttpActionResult PostCocktail(Cocktail Cocktail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CocktailSet.Add(Cocktail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = Cocktail.Id }, Cocktail);
        }

        // DELETE: api/Cocktail/5
        [ResponseType(typeof(Cocktail))]
        public IHttpActionResult DeleteCocktail(int id)
        {
            Cocktail Cocktail = db.CocktailSet.Find(id);
            if (Cocktail == null)
            {
                return NotFound();
            }

            db.CocktailSet.Remove(Cocktail);
            db.SaveChanges();

            return Ok(Cocktail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CocktailExists(int id)
        {
            return db.CocktailSet.Count(e => e.Id == id) > 0;
        }
    }
}