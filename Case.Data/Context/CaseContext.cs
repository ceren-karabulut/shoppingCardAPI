using Case.Data.Enitites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Case.Data.Context
{
    public class CaseContext : DbContext
    {
        public CaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
    }
}
