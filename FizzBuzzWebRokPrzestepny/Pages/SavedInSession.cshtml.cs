using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzzWebRokPrzestepny.Forms;

namespace FizzBuzzWebRokPrzestepny.Pages
{
    public class SavedInSessionModel : PageModel
    {
		public RokPrzestepny FizzBuzz { get; set; }

		public void OnGet()
        {
			var Data = HttpContext.Session.GetString("Data");
			if (Data != null)
				FizzBuzz = JsonConvert.DeserializeObject<RokPrzestepny>(Data);
		}
    }
}
