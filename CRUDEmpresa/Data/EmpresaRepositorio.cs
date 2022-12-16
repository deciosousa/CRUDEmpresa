using CRUDEmpresa.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDEmpresa.Data
{
    public class EmpresaRepositorio : IEmpresaRepositorio
    {
        private readonly EmpresaContexto _contexto;

        public EmpresaRepositorio(EmpresaContexto contexto)
        {
            _contexto = contexto;
        }
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

        //*** DEPARTAMENTOS***
        public async Task<Departamento[]> GetAllDepartamentos(bool incluirDepartamento = false)
        {
            IQueryable<Departamento> query = _contexto.Departamentos;

            query = query.AsNoTracking().OrderBy(d => d.ID);

            return await query.ToArrayAsync();
        }

        public async Task<Departamento> GetDepartamentoById(int id, bool incluirDepartamento = false)
        {
            IQueryable<Departamento> query = _contexto.Departamentos;

            query = query.AsNoTracking().OrderBy(d => d.ID);

            return await query.FirstOrDefaultAsync(d => d.ID == id);
        }

        public async Task<Departamento[]> GetDepartamentosByNome(string nome, bool incluirDepartamento = false)
        {
            IQueryable<Departamento> query = _contexto.Departamentos;
                //.Include(d => d.Funcionarios);

            query = query.AsNoTracking()
                         .Where(d => d.Nome.Contains(nome))
                         .OrderBy(d => d.ID);

            return await query.ToArrayAsync();
        }

        //***FUNCIONÁRIOS****

        public async Task<Funcionario[]> GetAllFuncionarios(bool incluirFuncionario = false)
        {
            IQueryable<Funcionario> query = _contexto.Funcionarios;
                //.Include(f => f.NomeFunc);

            query = query.AsNoTracking().OrderBy(f => f.ID);

            return await query.ToArrayAsync();
        }

        public async Task<Funcionario> GetFuncionarioById(int id, bool incluirFuncionario = false)
        {
            IQueryable<Funcionario> query = _contexto.Funcionarios;

            query = query.AsNoTracking().OrderBy(f => f.ID);

            return await query.FirstOrDefaultAsync(f => f.ID == id);
        }

        public async Task<Funcionario[]> GetFuncionariosByNome(string nome, bool incluirFuncionario = false)
        {
            IQueryable<Funcionario> query = _contexto.Funcionarios;

            query = query.AsNoTracking()
                         .Where(f => f.NomeFunc.Contains(nome))
                         .OrderBy(f => f.ID);

            return await query.ToArrayAsync();
        }
    }
}
