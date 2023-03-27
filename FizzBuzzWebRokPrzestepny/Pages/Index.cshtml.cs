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
        } = new RokPrzestepny();
        
        public Session FizzBuzzSession {  get; set; } = new Session();

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


            if ((FizzBuzz.Rok % 4 == 0 && FizzBuzz.Rok % 100 != 0) || FizzBuzz.Rok % 400 == 0)
            {
                rok_przestepny = "To był rok przestępny."; FizzBuzz.czy_przestepny = "rok przestępny";
            }
            else
            {
                rok_przestepny = "To nie był rok przestępny."; FizzBuzz.czy_przestepny = "rok nieprzestępny";
            }

            string result = FizzBuzz.Imie + " urodził się w " + FizzBuzz.Rok + " roku. " + rok_przestepny;

            if (!String.IsNullOrEmpty(FizzBuzz.Imie) && !String.IsNullOrEmpty(FizzBuzz.Rok.ToString()))
            { ViewData["message"] = result; 
                var CurrentData = HttpContext.Session.GetString("CurrentData");
                if (CurrentData != null)
                {
                    FizzBuzzSession = JsonConvert.DeserializeObject<Session>(CurrentData);
                }
                FizzBuzzSession.SessionList.Add(FizzBuzz);
                HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(FizzBuzzSession));
                HttpContext.Session.SetString("CurrentData", JsonConvert.SerializeObject(FizzBuzzSession));

            }
            return Page();
		}

	}
}