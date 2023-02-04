using CRUDEmpresa.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDEmpresa.Data
{
    public class EmpresaRepositorio : IEmpresaRepositorio
    {
        private readonly EmpresaContexto _contexto;

        public EmpresaRepositorio(EmpresaContexto contexto)
        {
            //injeção de dependência: trazendo o _contexto para a classe EmpresaRepositorio 
            _contexto = contexto;
        }

        // criando os métodos Add, Update e Delete usando parâmetros do tipo genérico, permitindo que a classe seja passada no momento sua instanciação
        public void Add<T>(T entity) where T : class
        {
            _contexto.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _contexto.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _contexto.Remove(entity);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _contexto.SaveChangesAsync()) > 0;
        }

        // criando os métodos de leitura (Get), de acordo com a classe: Departamento || Funcionario

        //*** DEPARTAMENTOS***
        public async Task<Departamento[]> GetAllDepartamentos(bool incluirDepartamento = false)
        {
            //definindo que apenas os elementos necessários sejam retornados
            IQueryable<Departamento> query = _contexto.Departamentos;

            // AsNotracking = indica ao contexto que o objeto da consulta não será modificado, ou seja, é apenas para leitura, isso resulta em ganho de performance.
            
            // OrderBy = método usado para organizar os elementos da consulta, neste caso, por nome. 
            query = query.AsNoTracking().OrderBy(d => d.Nome);
            
            //convertendo a resposta da requisição em uma matriz (array). 
            return await query.ToArrayAsync();
        }

        public async Task<Departamento> GetDepartamentoById(int id, bool incluirDepartamento = false)
        {
            IQueryable<Departamento> query = _contexto.Departamentos;
            
            //organizando os elementos da consulta por id
            query = query.AsNoTracking().OrderBy(d => d.ID);

            //definindo que a consulta deve retornar apenas o primeiro elemento encontrado
            return await query.FirstOrDefaultAsync(d => d.ID == id);
        }

        //***FUNCIONÁRIOS****

        public async Task<Funcionario[]> GetAllFuncionarios(bool incluirFuncionario = false)
        {
            IQueryable<Funcionario> query = _contexto.Funcionarios;

            //organizando os elementos da consulta por id
            query = query.AsNoTracking().OrderBy(f => f.ID);

            //convertendo a resposta da requisição em uma matriz (array).
            return await query.ToArrayAsync();
        }

        public async Task<Funcionario> GetFuncionarioById(int id, bool incluirFuncionario = false)
        {
            IQueryable<Funcionario> query = _contexto.Funcionarios;

            //organizando os elementos da consulta por id
            query = query.AsNoTracking().OrderBy(f => f.ID);

            //definindo que a consulta deve retornar apenas o primeiro elemento encontrado
            return await query.FirstOrDefaultAsync(f => f.ID == id);
        }
    }
}
