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
using MVCwithTDD.Dto;
using MVCwithTDD.Repository;
using MVCwithTDD.Service;

namespace MVCwithTDD.Controllers
{
    public class CompactDiscsController : ApiController
    {
        // eventually needs to be removed
        private musicEntities db = new musicEntities();
        
        public  ICompactDiscService Service { get; set; }

        public CompactDiscsController(ICompactDiscService service)
        {
            this.Service = service;
        }

        public CompactDiscsController()
        {
            
        }


        // GET: api/CompactDiscs
        public List<CompactDisc> Getcompact_discs()
        {
            //return null;
            return Service.GetAllCompactDiscs();
        }

        // GET: api/CompactDiscs/5
        [ResponseType(typeof(compact_discs))]
        public IHttpActionResult Getcompact_discs(int id)
        {
            compact_discs compact_discs = db.compact_discs.Find(id);
            if (compact_discs == null)
            {
                return NotFound();
            }

            return Ok(compact_discs);
        }

        // PUT: api/CompactDiscs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcompact_discs(int id, compact_discs compact_discs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != compact_discs.id)
            {
                return BadRequest();
            }

            db.Entry(compact_discs).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!compact_discsExists(id))
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

        // POST: api/CompactDiscs
        [ResponseType(typeof(compact_discs))]
        public IHttpActionResult Postcompact_discs(compact_discs compact_discs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.compact_discs.Add(compact_discs);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = compact_discs.id }, compact_discs);
        }

        // DELETE: api/CompactDiscs/5
        [ResponseType(typeof(compact_discs))]
        public IHttpActionResult Deletecompact_discs(int id)
        {
            compact_discs compact_discs = db.compact_discs.Find(id);
            if (compact_discs == null)
            {
                return NotFound();
            }

            db.compact_discs.Remove(compact_discs);
            db.SaveChanges();

            return Ok(compact_discs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool compact_discsExists(int id)
        {
            return db.compact_discs.Count(e => e.id == id) > 0;
        }
    }
}