using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Contex1;
using WebApplication2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmaciaController : ControllerBase
    {
        private readonly AppDbContext context;

        public EntityState EntytiState { get; private set; }

        public FarmaciaController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<FarmaciaController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Clientes.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<FarmaciaController>/5
        [HttpGet("{id}", Name = "GetCliente")]
        public ActionResult Get(string id)
        {
            try
            {
                var cliente = context.Clientes.FirstOrDefault(f => f.cod_cli == id);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<FarmaciaController>
        [HttpPost]
        public ActionResult Post([FromBody]Farmacia Cliente)
        {
            try
            {
                context.Clientes.Add(Cliente);
                context.SaveChanges();
                return CreatedAtRoute("GetCliente", new { id = Cliente.cod_cli }, Cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<FarmaciaController>
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody]Farmacia Cliente)
        {
            try
            {
                if(Cliente.cod_cli == id)
                {
                    context.Entry(Cliente).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetCliente", new { id = Cliente.cod_cli }, Cliente);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<FarmaciaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                var cliente = context.Clientes.FirstOrDefault(f => f.cod_cli == id);
                if(cliente != null)
                {
                    context.Clientes.Remove(cliente);
                    context.SaveChanges();
                    return Ok(cliente);
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
