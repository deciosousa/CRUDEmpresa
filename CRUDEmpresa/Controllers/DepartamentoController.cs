using CRUDEmpresa.Data;
using CRUDEmpresa.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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
        // criando uma requisição Get para retornar todos os registros
        // <IActionResult> indica a possibilidade de mais de um tipo de retorno possível . Neste caso: cód.200 = ok; cód: 400 BadRequest
        // async / await são responsáveis por tornar a requisição assíncrona (executada em segundo plano).
        public async Task<IActionResult> Get()
        {
            //chamada do método GetAllDepartamentos
            try
            {
                //criando a variável 'departamentos' para guardar os dados 
                var departamentos = await _repo.GetAllDepartamentos(true);

                return Ok(departamentos);
            }
            
            //tratamento da exceção
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

        }

        // GET api/<DepartamentoController>/5
        // roteamento de atributo = atribuindo um atributo (id) a ação da controller
        [HttpGet("{id}", Name = "GetDepartamento")]

        // criando uma requisição Get para retornar um registro específico, conforme parâmetro(id).
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                //criando a variável 'departamentos' para guardar os dados recebidos
                var departamentos = await _repo.GetDepartamentoById(id, true);

                return Ok(departamentos);
            }
            //tratamento da exceção
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // POST api/<DepartamentoController>
        [HttpPost]
        
        // criando uma requisição Post, cujo parâmetro é um model da classe Departamento 
        public async Task<IActionResult> Post(Departamento model)
        {
            try
            {
                _repo.Add(model);

                //Salvando, de forma assíncrona, as alterações feitas nesse contexto no banco de dados.
                if (await _repo.SaveChangeAsync())

                return Ok(new { message = "Sucesso" });
            }
            //tratamento da exceção
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Não Salvou");
        }

        // PUT api/<DepartamentoController>/5
        [HttpPut("{id}")]
        
        // criando uma requisição Put, cujos parâmetros são: o id e o model da classe Departamento
        public async Task<IActionResult> Put(int id, Departamento model)
        {
            try
            {
                //criada a variável 'departamento' para armazenar os valores recebidos do repositório
                var departamento = await _repo.GetDepartamentoById(id);
                
                //caso nenhum valor seja recebido, retornará a exceção NotFound (cód.404)
                if(departamento == null) return NotFound();
                {
                     // caso valores sejam recebidos pela variável 'departamento', chamar o método update para promover alterações e passar o model como parâmetro. 
                    _repo.Update(model);

                    //salvando/atualizando as alterações no repositório.
                    if (await _repo.SaveChangeAsync())
                   
                    return Ok(new { message = "Sucesso" });
                }
            }
            //tratamento da exceção
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return Ok("Não Encontrado!");
        }

        // DELETE api/<DepartamentoController>/5
        // criando uma requisição Delete, cujo parâmetro é o id.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                //criada a variável 'departamento' para armazenar os valores recebidos do repositório
                var departamento = await _repo.GetDepartamentoById(id);

                //caso nenhum valor seja recebido, retornará a exceção NotFound (cód.404)
                if (departamento == null) return NotFound();
                {
                    // caso valores sejam recebidos pela variável 'departamento', chamar o método Delete para promover a exclusão do registro.
                    _repo.Delete(departamento);

                    if (await _repo.SaveChangeAsync())

                        return Ok(new { message = "Deletado" });
                }
            }
            //tratamento da exceção
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest($"Não Deletado!");
        }
    }
}
