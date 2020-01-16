using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ApiRepositorio.Repositorio;
using ApiRepositorio.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRepositorio.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class RepositorioController : Controller {

        private readonly IRepositorio _repositorio;
        
        public RepositorioController (IRepositorio repositorio){
            _repositorio = repositorio;
        }

        [HttpGet]

        public IEnumerable<> GetAll ()
        {
            return _repositorio.GetAll();
        }

         [HttpGet("{id}", Name="GetRepositorio")]

         public IActionResult GetById (long id)
         {
             id = 8d87f54b03bbfe69fd76a467ae6b91383605f902;
             var repositorio = _repositorio.Find(id);
             if (repositorio==null)
             return NotFound();

             return new ObjectResult (repositorio);
         }
    }
}