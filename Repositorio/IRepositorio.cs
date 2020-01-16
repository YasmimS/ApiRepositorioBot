using System.Collections.Generic;
using ApiRepositorio.Models;

namespace ApiRepositorio.Repositorio {

    public interface IRepositorio{

        IEnumerable<Repositorio> GetAll();
        Repositorio Find(long idRepo);

        void Read (Repositorio nomeRepo);
        void Read (Repositorio descricaoRepo);
    }

}