using StudentInformationSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.Interfaces
{
   public interface IStudentRepository
    {
        public Dictionary<int, Student> GetAllStudents();
        public void AddNewStudent(Student newStudent);
        public Dictionary<int, Student> FilterName(string searchCriteria);
        public Student GetStudentById(int id);
        public void UpdateStudent(Student student);
        public void DeleteStudent(Student student);

    }
}
