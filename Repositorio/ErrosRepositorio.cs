using System.Collections.Generic;
using ProjetoFinal.Models;
using System.Linq;

namespace ProjetoFinal.Repositorio
{
    public class ErrosRepositorio : IErrosRepositorio
    {
        private readonly ErrosDbContext _contexto;
        public ErrosRepositorio(ErrosDbContext ctx)
        {
           _contexto = ctx; 
        }
        public void Add(Erros erro)
        {
           _contexto.Erros.Add(erro);
           _contexto.SaveChanges();
        }

        public Erros Find(int id)
        {
            return _contexto.Erros.FirstOrDefault(e => e.ErrosId == id);
        }

        public IEnumerable<Erros> GetAll()
        {
            return _contexto.Erros.ToList();
        }

        public void Remove(int id)
        {
           var dado = _contexto.Erros.First(e => e.ErrosId == id);
           _contexto.Erros.Remove(dado);
           _contexto.SaveChanges();
        }

        public void Update(Erros erro)
        {
           _contexto.Erros.Update(erro);
           _contexto.SaveChanges();
        }
    }
}