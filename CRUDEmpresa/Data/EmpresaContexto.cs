using CRUDEmpresa.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDEmpresa.Data
{
    public class EmpresaContexto : DbContext
    {
        public EmpresaContexto(DbContextOptions<EmpresaContexto> options) : base(options) {}

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}
