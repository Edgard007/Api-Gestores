using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiGestores.Context;
using apiGestores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiGestores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestoresController : ControllerBase
    {

        private readonly AppDBContext context;

        public GestoresController(AppDBContext context)
        {
            this.context = context;
        }

        //* ==> GET All <== *//
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<List<Gestores_DB>>> GetAll()
        {
            try
            {
                return await context.gestores_db.ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        //* ==> GET By Id <== *//
        // GET api/<ValuesController>/5
        [HttpGet("{id}", Name = "GetGestor")]
        public async Task<ActionResult<Gestores_DB>> GetById(int id)
        {
            try
            {
                return await context.gestores_db.FirstOrDefaultAsync(g => g.id == id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        //* ==> Save record <== *//
        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<Gestores_DB>> Post([FromBody]Gestores_DB gestores)
        {
            try
            {
                context.gestores_db.Add(gestores);
                await context.SaveChangesAsync();
                return CreatedAtRoute("GetGestor", new { id = gestores.id }, gestores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        //* ==> Modify record <== *//
        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Gestores_DB gestor)
        {
            try
            {
                if(gestor.id == id)
                {
                    context.Entry(gestor).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        //* ==> Delete record <== *//
        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var gestor = await context.gestores_db.FirstOrDefaultAsync(g => g.id == id);
                if(gestor != null)
                {
                    context.gestores_db.Remove(gestor);
                    await context.SaveChangesAsync();
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }
    }
}
