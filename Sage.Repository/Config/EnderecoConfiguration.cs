using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sage.Domain.Entities;

namespace Sage.Repository.Config
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(u => u.CEP).IsRequired().HasMaxLength(20);
            builder.Property(u => u.Estado).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Cidade).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Logradouro).IsRequired().HasMaxLength(200);
            builder.Property(u => u.Numero).IsRequired();
            builder.Property(u => u.Complemento).HasMaxLength(300);
        }
    }
}
