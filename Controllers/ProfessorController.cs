using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc; // referencia do controllerbase
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models; // 

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;

        public ProfessorController(SmartContext context){

             _context = context;
        }

        [HttpGet]
        public IActionResult Get(){
            return Ok(_context.Professores);
        }

         // api/professor/1
        [HttpGet("byId/{id}")] // rota vai ser um id mesmo nome do parametro \/
        public IActionResult GetById(int id){ 
            
            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);
            if (professor == null) return BadRequest("Professor não encontrado"); // retorna bad request 400
             
            return Ok(professor); // retorna status code 200ok response
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome){ 
            
            var professor = _context.Professores.FirstOrDefault(p => 
                p.Nome.Contains(nome));

            if (professor == null) return BadRequest("Professor não encontrado"); // retorna bad request 400
             
            return Ok(professor); // retorna status code 200ok response
        }

        [HttpPost]
        public IActionResult Post(Professor professor) {

            _context.Add(professor); // adiciona objeto
            _context.SaveChanges(); // salvando
            return Ok(professor); //retornando confirmação de sucesso
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor) {
            //asnotracking -> busca no banco de dados o recurso mas não bloqueia ele
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (prof == null) {
                return BadRequest("Professor não encontrado!");
            }
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);

        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor) {

            var prof = _context.Alunos.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (prof == null) return BadRequest("Professor não encontrado");
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor); // retorna status code 200 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {

            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);
            if (professor == null) return BadRequest("Professor não encontrado!"); // se o nome for igual a nulo
            _context.Remove(professor); // remove o professor
            _context.SaveChanges(); // salva as mudanças
            return Ok("Usuário removido com sucesso"); // retorna status code 200
        }
        
    }
}