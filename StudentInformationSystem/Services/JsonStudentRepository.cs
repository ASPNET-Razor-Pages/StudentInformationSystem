using StudentInformationSystem.Helpers;
using StudentInformationSystem.Interfaces;
using StudentInformationSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.Services
{
    public class JsonStudentRepository : IStudentRepository
    {
        string filePath = @".\Data\JsonStudent.json";

        //string filePath = @"C:\Users\zk222\source\repos\StudentInformationSystem\StudentInformationSystem\Data\JsonStudent.json";
        public Dictionary<int,Student> Students { get; set; }
        public JsonStudentRepository()
        {
            Students = GetAllStudents();
        }

        // Get all Students
        public Dictionary<int, Student> GetAllStudents()
        {
            return JsonFileReaderWriter.ReadFromJsonDeSerialization(filePath);
        }
        // Add New Resource 
        public void AddNewStudent(Student newStudent)
        {
            // Call this method for auto increment manually ( when we use SQL server then we disable this on that time) 
            var student = AutoIncrementId(newStudent);
            // step 1: Add new Student in the existing list of Getallstudents
            Students.Add(student.Id, student);
            // Step 3: Save file with added students into File 
            JsonFileReaderWriter.WriteToJsonSerialization(Students, filePath);
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
            Student getStudent = null; 
            if (Students.ContainsKey(id))
            {
                getStudent = Students[id];
            }
            return getStudent;
        }

        // Update student

        public void UpdateStudent(Student student)
        {
            // Step 1 : Update specific student
          if(student != null)
            {
                Students[student.Id].Id = student.Id;
                Students[student.Id].Name = student.Name;
                Students[student.Id].Image = student.Image;
                Students[student.Id].Email = student.Email;
                Students[student.Id].Profession = student.Profession;
            }
            // Step 2: Save students after updated 
            JsonFileReaderWriter.WriteToJsonSerialization(Students, filePath);
        }

        // Delete student
        public void DeleteStudent(Student student)
        {
            if(student !=null)
            {
                Students.Remove(student.Id);
            }
            // Step 2: Save students after updated 
            JsonFileReaderWriter.WriteToJsonSerialization(Students, filePath);
        }

        // Increment Id
        public Student AutoIncrementId(Student student)
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

    }
}
