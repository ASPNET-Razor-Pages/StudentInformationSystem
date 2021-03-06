using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentInformationSystem.Model;
using StudentInformationSystem.Services;
using StudentInformationSystem.Interfaces;

namespace StudentInformationSystem.Pages.Student_Info
{
    public class EditStudentModel : PageModel
    {
        private IStudentRepository _repo;

        [BindProperty]
        public Student Student { get; set; }

        public EditStudentModel(IStudentRepository repo)
        {
             Student = new Student();
            _repo = repo;
        }
        public IActionResult OnGet(int id)
        {
            Student = _repo.GetStudentById(id);
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
           _repo.UpdateStudent(Student);
            return RedirectToPage("GetAllStudents");
        }
    }
}
