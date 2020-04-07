using LibraryDomain.Repositorios;
using LibraryDomain.Services;
using LibraryInfrastructure.Repositorios;
using LibraryInfrastructure.Servicios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Utility
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegistroServiciosNegocio(this IServiceCollection services)
        {
            services.AddScoped<IAutorService, AutorService>();
            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ILibroService, LibroService>();
            services.AddScoped<ILibroRepository, LibroRepository>();
            return services;
        }

    }
}
