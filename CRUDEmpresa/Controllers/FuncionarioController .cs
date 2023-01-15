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
        private readonly IEmpresaRepositorio _repo;

        public FuncionarioController(IEmpresaRepositorio repo)
        {
            _repo = repo;
        }
        // GET: api/<FuncionarioController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var funcionarios = await _repo.GetAllFuncionarios(true);

                return Ok(funcionarios);
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET api/<FuncionarioController>/5
        [HttpGet("{id}", Name = "GetFuncionario")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var funcionarios = await _repo.GetFuncionarioById(id, true);

                return Ok(funcionarios);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // POST api/<FuncionarioController>
        [HttpPost]
        public async Task<IActionResult> Post(Funcionario model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangeAsync())

                    return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Não Salvou");
        }

        // PUT api/<FuncionarioController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Funcionario model)
        {
            try
            {
                var funcionario = await _repo.GetFuncionarioById(id);
                if (funcionario == null) return NotFound();
                {
                    _repo.Update(model);

                    if (await _repo.SaveChangeAsync())

                        return Ok(new { message = "Sucesso" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return Ok("Não Encontrado!");
        }

        // DELETE api/<FuncionarioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var funcionario = await _repo.GetFuncionarioById(id);
                if (funcionario == null) return NotFound();
                {
                    _repo.Delete(funcionario);

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
