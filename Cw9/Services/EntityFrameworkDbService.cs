using Cw9.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw9.Services
{
    public class EntityFrameworkDbService : IStudentDbService
    {
        private s17025Context _context { get; set; }
        
        public EntityFrameworkDbService(s17025Context context)
        {
            _context = context;
        }

        public List<Student> GetStudents()
        {
            var res = _context.Student.ToList();
            return res;
        }

        public string ModifyStudent(Student student)
        {
            try
            {
                var st = _context
                    .Student
                    .Where(d => d.IndexNumber == student.IndexNumber)
                    .ToList();

                if(st.Count == 0)
                {
                    return "Student nie istnieje!";
                }
                var stu = st[0];

                _context.Entry(stu).State = EntityState.Modified;
                _context.SaveChanges();
                return "Student o indeksie " + student.IndexNumber + " zostal zmodyfikowany.";
            }catch(Exception e)
            {
                return "Blad transakcji";
            }
        }

        public string DeleteStudent(string id)
        {
            var student = _context.Student.Where(
                d => d.IndexNumber == id
                ).ToList();

            if(student.Count == 0)
            {
                return "Brak studenta o podanym id w bazie";
            }
            else
            {
                var res = student[0];
                _context.Remove(res);
                _context.SaveChanges();
                return "Usunieto studenta o id" + id;
            }
            
        }       

        
    }
}
