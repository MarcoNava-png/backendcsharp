using WebApplication2.Core.Models;
using WebApplication2.Data.DbContexts;

namespace WebApplication2.Data.Seed
{
    internal class CatalogosSeed
    {
        public static void Seed(ApplicationDbContext dbContext)
        {
            if (!dbContext.DiaSemana.Any())
            {
                var items = new List<DiaSemana>()
                {
                    new DiaSemana { IdDiaSemana = 1, Nombre = "Lunes" },
                    new DiaSemana { IdDiaSemana = 2, Nombre = "Martes" },
                    new DiaSemana { IdDiaSemana = 3, Nombre = "Miércoles" },
                    new DiaSemana { IdDiaSemana = 4, Nombre = "Jueves" },
                    new DiaSemana { IdDiaSemana = 5, Nombre = "Viernes" },
                    new DiaSemana { IdDiaSemana = 6, Nombre = "Sábado" },
                    new DiaSemana { IdDiaSemana = 7, Nombre = "Domingo" },
                };

                dbContext.DiaSemana.AddRange(items);
                dbContext.SaveChanges();
            }

            if (!dbContext.Genero.Any())
            {
                var items = new List<Genero>()
                {
                    new Genero { DescGenero = "Masculino" },
                    new Genero { DescGenero = "Femenino" },
                    new Genero { DescGenero = "No especifica" },
                };

                dbContext.Genero.AddRange(items);
                dbContext.SaveChanges();
            }

            if (!dbContext.EstadoCivil.Any())
            {
                var items = new List<EstadoCivil>()
                {
                    new EstadoCivil { DescEstadoCivil = "Soltero(a)" },
                    new EstadoCivil { DescEstadoCivil = "Casado(a)" },
                };

                dbContext.EstadoCivil.AddRange(items);
                dbContext.SaveChanges();
            }
        }
    }
}
