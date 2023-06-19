using CRUDEmpresa.Models;
using System.Threading.Tasks;

namespace CRUDEmpresa.Data;

//IRepository é um recurso do .Net Web Api que permite criar uma interface que injeta o repositório utilizado para dentro da controller. Uma das vantagens desse padrão: maior desacoplamento da camada em que os dados são persistidos, facilitando a troca de um ORM (biblioteca/framework) por outro. 
public interface IEmpresaRepositorio
{
    void Add<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;

    //detectando se foram feitas alterações e, caso verdadeiro, gravando-as no banco de dados.
    Task<bool> SaveChangeAsync();

    Task<Departamento[]> GetAllDepartamentos(bool incluirDepartamento = false);
    Task<Departamento> GetDepartamentoById(int id, bool incluirDepartamento = false);

    Task<Funcionario[]> GetAllFuncionarios(bool incluirFuncionario = false);
    Task<Funcionario> GetFuncionarioById(int id, bool incluirFuncionario = false);
}
