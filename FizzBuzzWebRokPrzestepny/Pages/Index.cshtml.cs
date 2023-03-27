using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzzWebRokPrzestepny.Forms;

namespace FizzBuzzWebRokPrzestepny.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		[BindProperty]
        public RokPrzestepny FizzBuzz
        {
            get; set;
        }

        public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{

		}
		public IActionResult OnPost()
		{
            string rok_przestepny;
            string session_year;
            List<RokPrzestepny> tescikowo = new List<RokPrzestepny>();
            if ((FizzBuzz.Rok % 4 == 0 && FizzBuzz.Rok % 100 != 0) || FizzBuzz.Rok % 400 == 0)
            {
                rok_przestepny = "To był rok przestępny."; session_year = "rok przestępny";
            }
            else
            {
                rok_przestepny = "To nie był rok przestępny."; session_year = "rok nieprzestępny";
            }

            string result = FizzBuzz.Imie + " urodził się w " + FizzBuzz.Rok + " roku. " + rok_przestepny;
            if (ModelState.IsValid)
			{ tescikowo.Add(FizzBuzz);
                ViewData["message"] = result;
                HttpContext.Session.SetString("imie", FizzBuzz.Imie);
                HttpContext.Session.SetInt32("rok", FizzBuzz.Rok);
                HttpContext.Session.SetString("rok_przestepny", session_year);
               
            }
			return Page();
		}

	}
}