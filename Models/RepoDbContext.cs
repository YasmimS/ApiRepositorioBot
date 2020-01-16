using Microsoft.EntityFrameworkCore;
using ApiRepositorio.Repositorio;
using ApiRepositorio.Models;

namespace ApiRepositorio.Models
{
    public class RepoDbContext : DbContext
    {
        public RepoDbContext(DbContextOptions<RepoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Repositorio> Repositorios { get; set; }
    }
}