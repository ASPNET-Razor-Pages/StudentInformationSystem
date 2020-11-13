using StudentInformationSystem.Interfaces;
using StudentInformationSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.Services
{
    public class FakeRepository : IStudentRepository
    {
        public Dictionary<int, Student> Students { get; set; }
        public FakeRepository()
        {
            // first object reference
            Students = new Dictionary<int, Student>();
            Students.Add(1, new Student(1, "ajohn", "jh@gmail.com", "john.jpg", Profession.Administration));
            Students.Add(2, new Student(2, "alex", "al@gmail.com", "alex.jpg", Profession.Production));
            Students.Add(3, new Student(3, "malina", "ma@gmail.com", "malina.jpg", Profession.Business));
            Students.Add(4, new Student(4, "nilma", "ni@gmail.com", "nilma.jpg", Profession.Accounting));

        }
        // Return all GetStudents
        public Dictionary<int, Student> GetAllStudents()
        {
            return Students;
        }

        // Add New Resource 
        public void AddNewStudent(Student newStudent)
        {
            Student stuAutoId = IncrementId(newStudent);   
            Students.Add(stuAutoId.Id, stuAutoId);
        }

        public Student IncrementId(Student student)
        {
            List<int> studentId = new List<int>();
            foreach (var stu in Students.Values)
            {
                studentId.Add(stu.Id);
            }
            if (studentId.Count != 0)
            {
                // take last value from list and add 1 for next increment
                int inc = studentId.Max() + 1;
                // add this next increment into Id
                student.Id = inc;
            }
            else
            {
                student.Id = 1;
            }
            return student;
        }

        // Search Mechanism
        public Dictionary<int, Student> FilterName(string searchCriteria)
        {
            Dictionary<int, Student> result = new Dictionary<int, Student>();
            foreach (var student in Students.Values)
            {
                if (student.Name.StartsWith(searchCriteria))
                {
                    result.Add(student.Id, student);
                }
            }

            return result;
        }

        // Get Student By ID 
        public Student GetStudentById(int id)
        {
            if (Students.ContainsKey(id))
            {
                return Students[id];
            }
            return new Student();
        }

        // Update student

        public void UpdateStudent(Student student)
        {
            if(student !=null)
            {
                Students[student.Id].Id = student.Id;
                Students[student.Id].Name = student.Name;
                Students[student.Id].Email = student.Email;
                Students[student.Id].Image = student.Image;
                Students[student.Id].Profession = student.Profession;
            }
        }

        // Delete student
        public void DeleteStudent(Student student)
        {
            if (student != null)
            {
                Students.Remove(student.Id);
            }
        }


    }
}
