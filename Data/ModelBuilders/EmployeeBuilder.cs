using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Data.ModelBuilders
{
    static class EmployeeBuilder
    {
        public static ModelBuilder BuildEmployee(this ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<Employee>(entity =>
            {

                entity.ToTable("Employees").HasKey(e => e.ID);

                /* Properties */
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.Property(e => e.Created).HasDefaultValue(DateTime.UtcNow);
                entity.Property(e => e.RowVersion).IsRowVersion();
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
                entity.Property(e => e.DepartmentID);
            });
        }
    }
}