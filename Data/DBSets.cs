using Microsoft.EntityFrameworkCore;

namespace Data
{
    public partial class DataContext
    {
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}
