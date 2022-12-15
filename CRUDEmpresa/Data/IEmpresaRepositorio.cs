using CRUDEmpresa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDEmpresa.Data
{
    public interface IEmpresaRepositorio
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangeAsync();

        //*** atenção para a necessidade de excluir  = false do trecho abaixo

        Task<Departamento[]> GetAllDepartamentos(bool incluirDepartamento = false);
        Task<Departamento> GetDepartamentoById(int id, bool incluirDepartamento = false);
        Task<Departamento[]> GetDepartamentosByNome(string nome, bool incluirDepartamento = false);

        Task<Funcionario[]> GetAllFuncionarios(bool incluirFuncionario = false);
        Task<Funcionario> GetFuncionarioById(int id, bool incluirFuncionario = false);
        Task<Funcionario[]> GetFuncionariosByNome(string nome, bool incluirFuncionario = false);
    }
}
