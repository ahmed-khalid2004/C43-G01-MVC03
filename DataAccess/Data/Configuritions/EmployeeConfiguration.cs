using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC03.DataAccess.Models.EmployeeModel;
using MVC03.DataAccess.Models.Shared.Enums;

namespace MVC03.DataAccess.Data.Configuritions
{
    public class EmployeeConfigurations : BaseEntityConfigurations<Employee>, IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).HasColumnType("varchar(50)");
            builder.Property(E => E.Address).HasColumnType("varchar(150)");
            builder.Property(E => E.Salary).HasColumnType("decimal(10,2)");
            builder.Property(E => E.Gender)
                .HasConversion(
                    EmpGender => EmpGender.ToString(),
                    _gender => (Gender)Enum.Parse(typeof(Gender), _gender)
                );
            builder.Property(E => E.EmployeeType)
                .HasConversion(
                    EmpType => EmpType.ToString(),
                    _Type => (EmployeeType)Enum.Parse(typeof(EmployeeType), _Type)
                );

            base.Configure(builder);
        }
    }

}
