using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzzWebRokPrzestepny.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

namespace FizzBuzzWebRokPrzestepny.Pages
{
    public class SavedInSessionModel : PageModel
    {
        
        public string Name { get; set; }
        public int? Year { get; set; }
        public string Result { get; set; }
        public List<RokPrzestepny> testowe = new List<RokPrzestepny>();
        public void OnGet()
        {

            Name = HttpContext.Session.GetString("imie");
            Year = HttpContext.Session.GetInt32("rok");
            Result = HttpContext.Session.GetString("rok_przestepny");
     
            var Data = HttpContext.Session.GetString("Data");
			
            
        }
        public IActionResult OnPost()
        {   
            return Page();
        }
    }
}

