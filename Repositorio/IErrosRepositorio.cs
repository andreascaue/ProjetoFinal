using ProjetoFinal.Models;
using System.Collections.Generic;

namespace ProjetoFinal.Repositorio
{
    public interface IErrosRepositorio
    {
       void Add(Erros erro); 

       IEnumerable<Erros> GetAll();

       Erros Find(int id);

       void Remove(int id);

       void Update(Erros erro);
    }
}