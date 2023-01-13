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
    public class DepartamentoController : ControllerBase
    {
        private readonly IEmpresaRepositorio _repo;

        public DepartamentoController(IEmpresaRepositorio repo)
        {
            _repo = repo;
        }
        // GET: api/<DepartamentoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var departamentos = await _repo.GetAllDepartamentos(true);
                
                return Ok(departamentos);
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            
        }

        // GET api/<DepartamentoController>/5
        [HttpGet("{id}", Name = "GetDepartamento")]
        public async Task <IActionResult> Get(int id)
        {
            try
            {
                var departamentos = await _repo.GetDepartamentoById(id, true);

                return Ok(departamentos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // POST api/<DepartamentoController>
        [HttpPost]
        public async Task<IActionResult> Post(Departamento model)
        {
            try
            {
                _repo.Add(model);
                
                if(await _repo.SaveChangeAsync())

                return Ok(new { message = "Sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Não Salvou");
        }

        // PUT api/<DepartamentoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Departamento model)
        {
            try
            {
                var departamento = await _repo.GetDepartamentoById(id);
                if(departamento == null) return NotFound();
                {
                    _repo.Update(model);
                    
                    if(await _repo.SaveChangeAsync())
                   
                    return Ok(new { message = "Sucesso" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return Ok("Não Encontrado!");
        }

        // DELETE api/<DepartamentoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var departamento = await _repo.GetDepartamentoById(id);
                if (departamento == null) return NotFound();
                {
                    _repo.Delete(departamento);

                    if (await _repo.SaveChangeAsync())

                        return Ok(new { message = "Deletado" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest($"Não Deletado!");
        }
    }
}
