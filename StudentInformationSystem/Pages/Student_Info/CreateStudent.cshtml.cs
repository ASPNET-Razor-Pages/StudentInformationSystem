using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentInformationSystem.Model;
using StudentInformationSystem.Services;

namespace StudentInformationSystem.Pages.Student_Info
{
    public class CreateStudentModel : PageModel
    {
        private FakeRepository _repo;

        [BindProperty]
        public Student NewStudent { get; set; }

        public CreateStudentModel(FakeRepository repo)
        {
            _repo = repo;
            NewStudent = new Student();
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _repo.AddNewStudent(NewStudent);
            // retuen to Main Index Page .....S
            return RedirectToPage("GetAllStudents");
        }
    }
}
