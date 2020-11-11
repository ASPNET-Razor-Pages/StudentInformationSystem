using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentInformationSystem.Model;
using StudentInformationSystem.Services;

namespace StudentInformationSystem.Pages.Student_Info
{
    public class GetAllStudentsModel : PageModel
    {
        // Target property for UI 
        // This property we use when we display collection of objects first time in a Page
         public Dictionary<int, Student> Students { get; set; }

        // Target property for Post Method 
        // This property we use when we make a Post request of form
        // Adding new Resource information 
        [BindProperty]public Student NewStudent { get; set; }

        // search criteri property - target property
         [BindProperty(SupportsGet =true)]
        // This property we use when we make a Search of specific objects
        public string SearchCriteria { get; set; }

        public FakeRepository _repo;
        // one your registered your DI service in startup class- configure method
        public GetAllStudentsModel(FakeRepository repo)
        {
            _repo = repo;
            // Here are we call the GetAllStudents method to retrieve current Dictionary Object List
            Students = _repo.GetAllStudents();
        }
        public IActionResult OnGet()
        {
            if (!String.IsNullOrEmpty(SearchCriteria))
            {
                // Here we update Students property with current searching criteria
                  Students = _repo.FilterName(SearchCriteria);
            }
            // fill up with data or information
            return Page();
        }

       

        public IActionResult OnPostDelete(int id)
        {
            return Page();
        }

    }
}
