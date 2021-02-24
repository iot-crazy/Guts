using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Data.ModelBuilders
{
    static class DepartmentBuilder
    {
        public static ModelBuilder BuildAuthor(this ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<Department>(entity =>
            {

                entity.ToTable("Departments").HasKey(e => e.ID);

                /* Associations */
                entity.HasMany(p => p.Employees).WithOne(p => (Department)p.Department)
                    .HasForeignKey(p => p.DepartmentID).OnDelete(DeleteBehavior.NoAction);

                /* Properties */
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.Property(e => e.Created).HasDefaultValue(DateTime.UtcNow);
                entity.Property(e => e.RowVersion).IsRowVersion();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Description);
            });
        }
    }
}
