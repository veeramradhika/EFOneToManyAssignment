using EFOneToManyAssignment.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFOneToManyAssignment.Data
{
    public class DemoDbContext : DbContext
    {
        public DbSet<Employee> Employees { set; get; }
        public DbSet<EmployeeOrganizations> employeeOrganizations { set; get; }
        public DemoDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
        {
            OptionsBuilder.UseSqlServer(@"Data Source=RADHIKA;Initial Catalog=EmployeeDb;Integrated Security=True");
        }
    }
}
