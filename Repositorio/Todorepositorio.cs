using System.Collections.Generic;

namespace ApiRepositorio.Repositorio
{

    public class Todorepositorio : IRepositorio{

       private readonly repoDbContext _contexto;

       public Todorepositorio (repoDbContext ctx){

           _contexto = ctx;

       }

       public Repositorio Find (long id){
           return _contexto.Repositorio.FirstOrDefault(r=>r.idRepo == id);
       }

       public IEnumerable<Repositorio> GetAll(){
           return _contexto.Repositorio.ToList();
       }

       public void Read (Repositorio nomeRepo){
           _contexto.Repositorio.Read(nomeRepo);
           _contexto.SaveChanges();
       }

        public void Read (Repositorio descricaoRepo){
            _contexto.Repositorio.Read(descricaoRepo);
            _contexto.SaveChanges();
       }
    }

}