using EntityDepartment = MVC03.DataAccess.Models.DepartmentModel.Department;
using MVC03.DataAccess.Models.DepartmentModel;

namespace MVC03.DataAccess.Data.Configuritions
{
    public class DepartmentConfigurations : BaseEntityConfigurations<EntityDepartment>, IEntityTypeConfiguration<EntityDepartment>
    {
        public new void Configure(EntityTypeBuilder<EntityDepartment> builder)
        {
            builder.Property(D => D.Id).UseIdentityColumn(10, 10);
            builder.Property(D => D.Name).HasColumnType("varchar(20)");
            builder.Property(D => D.Code).HasColumnType("varchar(20)");
            builder.HasMany(D => D.Employees)
               .WithOne(E => E.Department)
               .HasForeignKey(E => E.DepartmentId)
               .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
