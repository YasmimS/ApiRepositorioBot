using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ApiRepositorio.Repositorio;

namespace ApiRepositorio.Models
{
    public class Repositorio
    {
        public long idRepo { get; set; }
        public string nomeRepo { get; set; }
        public string descricaoRepo { get; set; }
        public bool IsComplete { get; set; }
    }
}