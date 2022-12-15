using CRUDEmpresa.Data;
using CRUDEmpresa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUDEmpresa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly EmpresaContexto _context;

        public FuncionarioController(EmpresaContexto context)
        {
            _context = context;
        }
        // GET: api/<FuncionarioController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Funcionario());
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET api/<FuncionarioController>/5
        [HttpGet("{id}", Name = "GetFuncionario")]
        public ActionResult Get(int id)
        {
            return Ok("value");
        }

        // POST api/<FuncionarioController>
        [HttpPost]
        public ActionResult Post(Funcionario model)
        {
            try
            {
                _context.Funcionarios.Add(model);
                _context.SaveChanges();

                return Ok("SUCESSO!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // PUT api/<FuncionarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Funcionario model)
        {
            try
            {
                if(_context.Funcionarios.AsNoTracking().FirstOrDefault(
                    f => f.ID ==id
                    ) != null)
                {
                    _context.Funcionarios.Update(model);
                    _context.SaveChanges();

                    return Ok("SUCESSO!");
                }
                return Ok("Não Encontrado!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // DELETE api/<FuncionarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
