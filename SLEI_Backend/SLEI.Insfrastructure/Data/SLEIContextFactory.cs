using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SLEI.Insfrastructure.Data;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLEI.Insfrastructure.Data
{
    class SLEIContextFactory : IDesignTimeDbContextFactory<SLEIContext>
    {

        public SLEIContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SLEIContext>();

            // Ajoute ta chaîne de connexion ici
            optionsBuilder.UseSqlServer("Server=LAPTOP-073BIOPO\\SQLEXPRESS;Database=SLEIDatabase;Trusted_Connection=True;TrustServerCertificate=True");

            return new SLEIContext(optionsBuilder.Options);
        }
    }
}
