using System.Collections.Generic;

namespace CRUDEmpresa.Models
{
    // criação da classe Funcionario
    public class Funcionario 
    {
        public int ID { get; set; }
        public string NomeFunc { get; set; }
        public string DataContratacao { get; set; }

        //referência direta à classe Departamento
        public List<Departamento> Departamento { get; set; }
        public string NomeDepto { get; set; }
    }
}
