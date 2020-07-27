using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Repositorio;
using System.Collections.Generic;
using ProjetoFinal.Models;

namespace ProjetoFinal.Controllers
{
    [Route("api/[Controller]")]
    public class ErrosController : Controller
    {
      
        private readonly IErrosRepositorio _erroRepositorio;
        public ErrosController(IErrosRepositorio errosRepos)
        {
            _erroRepositorio = errosRepos;
        }

        [HttpGet]
        public IEnumerable<Erros> GetAll(){
           return _erroRepositorio.GetAll();
        }

        [HttpGet("{id}", Name="GetErro")]
        public IActionResult GetById(int id){
            var erro = _erroRepositorio.Find(id);
            if(erro==null){
               return NotFound();  
            }

            return new ObjectResult(erro);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Erros erro){
            if(erro==null)
                return BadRequest();

            _erroRepositorio.Add(erro);

            return CreatedAtRoute("GetErro" , new {id=erro.ErrosId}, erro);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Erros erro){
            if(erro==null || erro.ErrosId != id)
                return BadRequest();
            var _erro = _erroRepositorio.Find(id);

            if(erro==null)
                return NotFound();    

            _erro.ErrosLog = erro.ErrosLog;

            _erro.ErrosLevel = erro.ErrosLevel;

            _erro.ErrosEvent = erro.ErrosEvent;

            _erro.ErrosDate = erro.ErrosDate;

            _erroRepositorio.Update(_erro);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var erro = _erroRepositorio.Find(id);

            if(erro==null)
                return NotFound();

            _erroRepositorio.Remove(id);

            return new NoContentResult();    
        }

    }
}