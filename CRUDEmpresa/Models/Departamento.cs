using System.Collections.Generic;

namespace CRUDEmpresa.Models;

// criação da classe Departamento
public class Departamento
{
    public int ID { get; set; }
    public string Nome { get; set; }
    //referência direta à classe Funcionarios, resultando numa tabela de intersecção chamada DepartamentoFuncionario em que 
    public List<Funcionario> Funcionarios { get; set; }
}

