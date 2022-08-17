using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Unifenas.Models;

namespace Desafio_Unifenas.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            using (var servicesope = app.ApplicationServices.CreateScope())
            {
                var context = servicesope.ServiceProvider.GetService<_DbContext>();
                if (!context.alunos.Any())
                {
                    context.alunos.AddRange(
                        new Aluno { Nome = "Guilherme Marques Paulino da Costa", NomedaMae = "Simone Marques Costa", Cpf = "157704566 - 12", Endereco = "Henrique Carivaldo de Miranda" },
                        new Aluno { Nome = "Pedro Neto de Oliveira", NomedaMae = "Gisele Oliveira", Cpf = "256235147 - 65", Endereco = "PiuXII" },
                        new Aluno { Nome = "Paulo Nobre de Castro", NomedaMae = "Paula Nobre", Cpf = "154238794 - 54", Endereco = "Afonso Pena" }
                        );
                    context.SaveChanges();
                }
            }
                
        }
    }
}
