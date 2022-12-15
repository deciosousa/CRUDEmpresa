using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDEmpresa.Models
{
    public class Funcionario
    {
        public int ID { get; set; }
        public string NomeFunc { get; set; }
        public DateTime DataContratacao { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoID { get; set; }
    }
}
