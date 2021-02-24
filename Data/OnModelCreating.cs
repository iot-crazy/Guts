using Data.ModelBuilders;
using Microsoft.EntityFrameworkCore;
namespace Data
{
    public partial class DataContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.BuildAuthor();
            modelBuilder.BuildEmployee();
        }
    }
}
