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
using BO;

namespace WebAPI.Controllers
{
    public class SuppliersController : ApiController
    {
        private INTECEcommerceEntities db = new INTECEcommerceEntities();

        // GET: api/Suppliers
        public IQueryable<Supplier> GetSupplier()
        {
            return db.Supplier;
        }

        // GET: api/Suppliers/5
        [ResponseType(typeof(Supplier))]
        public IHttpActionResult GetSupplier(int id)
        {
            Supplier supplier = db.Supplier.Find(id);
            if (supplier == null)
            {
                return NotFound();
            }

            return Ok(supplier);
        }

        // PUT: api/Suppliers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSupplier(int id, Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != supplier.Id)
            {
                return BadRequest();
            }

            supplier.CreatedDate = DateTime.Now;
            db.Entry(supplier).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(id))
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

        // POST: api/Suppliers
        [ResponseType(typeof(Supplier))]
        public IHttpActionResult PostSupplier(Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            supplier.Enabled = false;
            supplier.CreatedDate = DateTime.Now;

            db.Supplier.Add(supplier);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = supplier.Id }, supplier);
        }

        // DELETE: api/Suppliers/5
        [ResponseType(typeof(Supplier))]
        public IHttpActionResult DeleteSupplier(int id)
        {
            Supplier supplier = db.Supplier.Find(id);
            if (supplier == null)
            {
                return NotFound();
            }

            db.Supplier.Remove(supplier);
            db.SaveChanges();

            return Ok(supplier);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SupplierExists(int id)
        {
            return db.Supplier.Count(e => e.Id == id) > 0;
        }
    }
}