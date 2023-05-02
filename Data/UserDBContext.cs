using EmployeeWebAPIforJWTtoken.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPIforJWTtoken.Data
{
    public class UserDBContext:DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext>options):base(options)
        {

        }
        public DbSet<EmployeeModel> EmployeeModel { get; set; }
        public DbSet<CountryModel> CountryModel { get; set; }
        public DbSet<StatesModel> StatesModel { get; set; }
        public DbSet<ManagerDetails> ManagerDetails { get; set; }
        public DbSet<Departments> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeModel>().ToTable("Employee_Personal");
            modelBuilder.Entity<CountryModel>().ToTable("Country_List");
            modelBuilder.Entity<StatesModel>().ToTable("Countries_State");
            modelBuilder.Entity<ManagerDetails>().ToTable("Manager_details");
            modelBuilder.Entity<Departments>().ToTable("Departments");
        }
      
    }
}
