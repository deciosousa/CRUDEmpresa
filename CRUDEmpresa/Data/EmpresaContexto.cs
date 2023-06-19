using CRUDEmpresa.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDEmpresa.Data;

public class EmpresaContexto : DbContext
{
    //construtor do contexto e encapsulamento das suas entidades. Indicando as classes dos objetos que serão manipulados.
    
    //implementação base do método chamado para instanciação do contexto. 
    public EmpresaContexto(DbContextOptions<EmpresaContexto> options) : base(options) {}

    //permitindo consultar e salvar instâncias
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
}
