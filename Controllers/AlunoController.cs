using System.Collections.Generic;
using System.Linq; // first or default
using Microsoft.AspNetCore.Mvc; // referencia do controllerbase
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public AlunoController(){}

       public List<Aluno> Alunos = new List<Aluno>() {
            new Aluno() { 
                Id = 1,
                Nome = "Marcos",
                Sobrenome = "Silva",
                Telefone = "12345695"
            },
            new Aluno() { 
                Id = 2,
                Nome = "James",
                Sobrenome = "Rovel",
                Telefone = "56236589"
            },
            new Aluno() { 
                Id = 3,
                Nome = "Laura",
                Sobrenome = "Figueiredo",
                Telefone = "45678956"
            },
        };

        [HttpGet]
        public IActionResult Get(){
            return Ok(Alunos);
        }

        // api/aluno/1
        [HttpGet("byId/{id}")] // rota vai ser um id mesmo nome do parametro \/
        public IActionResult GetById(int id){ 
            
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado"); // retorna bad request 400
             
            return Ok(aluno); // retorna status code 200ok response
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string Sobrenome){ 
            
            var aluno = Alunos.FirstOrDefault(a => 
                a.Nome.Contains(nome) && a.Sobrenome.Contains(Sobrenome)
            );
            if (aluno == null) return BadRequest("Aluno não encontrado"); // retorna bad request 400
             
            return Ok(aluno); // retorna status code 200ok response
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno){ 
        
            return Ok(aluno); // retorna status code 200ok response
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno){ 
        
            return Ok(aluno); // retorna status code 200ok response
        }

        
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno){ 
        
            return Ok(aluno); // retorna status code 200ok response
        }


        [HttpDelete("{id}")]
       
        public IActionResult Delete(int id){ 
        
            return Ok(); // retorna status code 200ok response
        }



        
    }
}