using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjChoc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjChoc.Infra.Data.EntityConficuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(300).IsRequired();
            builder.Property(p => p.Price).HasPrecision(10,2);

            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Chocolate ao Leite",
                    Description = "Chocolate ao leite é uma variedade suave e cremosa de chocolate, com sabor doce e textura macia devido à adição de leite em pó ou leite condensado.",
                    Price = 25.50
                },
                new Product
                {
                    Id = 2,
                    Name = "Chocolate com Doce de Leite",
                    Description = "Um chocolate meio amargo excepcionalmente delicioso, recheado com doce de leite cremoso, oferece uma combinação perfeita de sabores intensos e suaves.",
                    Price = 50
                },
                new Product
                {
                    Id = 3,
                    Name = "Chocolate com Frutas Vermelhas",
                    Description = "Um chocolate exuberante e decadente, com uma mistura equilibrada de frutas vermelhas frescas e intensas, combinadas com a riqueza suave do chocolate.",
                    Price = 55
                }
                );
        }
    }
}
