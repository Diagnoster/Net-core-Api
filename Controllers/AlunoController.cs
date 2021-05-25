using System.Collections.Generic;
using System.Linq; // first or default
using Microsoft.AspNetCore.Mvc; // referencia do controllerbase
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext _context;

        public AlunoController(SmartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(){
            return Ok(_context.Alunos);
        }

        // api/aluno/1
        [HttpGet("byId/{id}")] // rota vai ser um id mesmo nome do parametro \/
        public IActionResult GetById(int id){ 
            
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado"); // retorna bad request 400
             
            return Ok(aluno); // retorna status code 200ok response
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string Sobrenome){ 
            
            var aluno = _context.Alunos.FirstOrDefault(a => 
                a.Nome.Contains(nome) && a.Sobrenome.Contains(Sobrenome)
            );
            if (aluno == null) return BadRequest("Aluno não encontrado"); // retorna bad request 400
             
            return Ok(aluno); // retorna status code 200ok response
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno){ 
            
            _context.Add(aluno); // adicionando objeto, pode adicionar pq dentro do contexto o aluno é do tipo aluno, dado isso eu posso adicionar no aluno pq ele conhece este tipo
            _context.SaveChanges(); // salvando
            return Ok(aluno); // retorna status code 200ok response
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno){ 
            //asnotracking -> busca no banco de dados o recurso mas não bloqueia ele
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null ) return BadRequest("Aluno não encontrado!");
            
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno); // retorna status code 200ok response
        }

        
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno){ 
            
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null ) return BadRequest("Aluno não encontrado!");
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno); // retorna status code 200ok response
        }


        [HttpDelete("{id}")]
       
        public IActionResult Delete(int id){ 
            
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null ) return BadRequest("Aluno não encontrado!");
            _context.Remove(aluno);
            _context.SaveChanges();
            return Ok("Usuário removido com sucesso"); // retorna status code 200ok response
        }



        
    }
}