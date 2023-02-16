using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolandGarros.Data
{
    public class TennisContextFactory : IDesignTimeDbContextFactory<TennisContext>
    {
        public TennisContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TennisContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RolandGarros;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new TennisContext(optionsBuilder.Options);
        }
    }
}
