using Cw9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw9.Services
{
    public interface IStudentDbService
    {
        public List<Student> GetStudents();
        public string ModifyStudent(Student student);
        public string DeleteStudent(string id);
    }
}
