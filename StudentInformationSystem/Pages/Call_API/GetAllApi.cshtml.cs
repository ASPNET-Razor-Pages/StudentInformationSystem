using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentInformationSystem.Services;
using StudentInformationSystem.Model;
using System.Net.Http;
using System.Net.Http.Json;

namespace StudentInformationSystem.Pages.Call_API
{
    public class GetAllApiModel : PageModel
    {
        private IHttpClientFactory _clientFactory;
        public GetAllApiModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public Dictionary<int, Student> Students { get; set; }
        public string ErrorMsg { get; set; } = null;
        public async Task OnGet()
        {
            // Get base address from starup file
            var client = _clientFactory.CreateClient("base");
            try
            {  
                // only call here specific service method here such as ( Get all Student) 
                Students = await client.GetFromJsonAsync<Dictionary<int,Student>>("Student");               
            }
            catch(Exception ex)
            {
                ErrorMsg = $"There was an error getting our API services {ex.Message}";
            }
        }
    }
}
