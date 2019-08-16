using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateDataBaseProject_DotNetCore.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options)
           : base(options)
        { }

        public DbSet<MyTestTable1> MyTestTable_1 { get; set; }
        public DbSet<MyTestTable2> MyTestTable_2 { get; set; }
    }
}
