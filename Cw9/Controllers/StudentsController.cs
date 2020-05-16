using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw9.Models;
using Cw9.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cw9.Controllers
{
    [Route("api/cw9")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentDbService StudentDbService;

        public StudentsController(IStudentDbService service)
        {
            StudentDbService = service;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            List<Student> res = StudentDbService.GetStudents();
            return Ok(res);
        }

        [HttpPost]
        public IActionResult ModifyStudent(Student student)
        {
            var stu = student;
            var res = StudentDbService.ModifyStudent(stu);
            if(res == "Brak studenta o podanym id w bazie")
            {
                return BadRequest("Brak studenta w bazie");
            }else if(res == "Blad transakcji")
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(string id)
        {
            var res = StudentDbService.DeleteStudent(id);
            if (res == "Brak studenta o podanym id w bazie")
            {
                return BadRequest("Brak studenta o podanym id w bazie");
            }
            else
                return Ok("Usunieto studenta o id " + id);

        }

    }
}