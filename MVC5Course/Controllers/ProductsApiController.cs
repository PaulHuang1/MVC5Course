﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class ProductsApiController : ApiController
    {
        private FabricsEntities db = new FabricsEntities();

        public ProductsApiController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        [Route("prods")]
        // GET: api/ProductsApi
        public IQueryable<Product> GetProduct()
        {
            return db.Product;
        }

        [Route("prods/{id}")]
        // GET: api/ProductsApi/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [Route("prods/{id}/orderlines")]
        public IHttpActionResult GetProductOrderLine(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Product product = db.Product.Include("OrderLine").FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            //db.OrderLine.Where(p => p.ProductId == id).ToList();

            return Ok(product.OrderLine.ToList());
        }

        // PUT: api/ProductsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/ProductsApi
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Product.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.ProductId }, product);
        }

        // DELETE: api/ProductsApi/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Product.Remove(product);
            db.SaveChanges();
            
            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Product.Count(e => e.ProductId == id) > 0;
        }
    }
}