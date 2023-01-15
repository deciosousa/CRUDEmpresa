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
        public string DataContratacao { get; set; }
        public List<Departamento> Departamento { get; set; }
        public string NomeDepto { get; set; }
    }
}
