using Model2;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataAccessLayer;

public class StudentContext : DbContext
{
    public StudentContext() : base("DBConnection") { }
    
    public DbSet<Student>? students { get; set; }
}