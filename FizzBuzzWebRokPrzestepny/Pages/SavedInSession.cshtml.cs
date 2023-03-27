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
        
        public Session FizzBuzzSession { get; set; } = new Session();
        
        public void OnGet()
        {
            var Data = HttpContext.Session.GetString("Data");
            if (Data != null)
            {
                FizzBuzzSession = JsonConvert.DeserializeObject<Session>(Data);
                HttpContext.Session.SetString("CurrentData", JsonConvert.SerializeObject(FizzBuzzSession));

            }   
        }
        public IActionResult OnPost()
        {   
            return Page();
        }
    }
}

