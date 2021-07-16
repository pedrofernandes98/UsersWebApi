using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Domain.Entities;

namespace Users.Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Table
            builder.ToTable("USER");

            //PK - PrimaryKey
            builder.HasKey(x => x.Id);

            //Columns
            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .UseIdentityColumn() //AutoIncrement
                .HasColumnType("BIGINT");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("NAME")
                .HasColumnType("VARCHAR(150)")
                .HasMaxLength(150);
            //:TODO: -> Pegar valor das constantes das Entidades(UserValidation)?

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("EMAIL")
                .HasColumnType("VARCHAR(180)")
                .HasMaxLength(180);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasColumnName("PASSWORD")
                .HasColumnType("VARCHAR(180)")
                .HasMaxLength(180);

        }
    }
}