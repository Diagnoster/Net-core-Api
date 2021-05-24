using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc; // referencia do controllerbase
using SmartSchool.WebAPI.Models; // 

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        public ProfessorController(){}

        [HttpGet]
        public IActionResult Get(){
            return Ok("Professores: Marta, Paula, Lucas, James");
        }
    }
}