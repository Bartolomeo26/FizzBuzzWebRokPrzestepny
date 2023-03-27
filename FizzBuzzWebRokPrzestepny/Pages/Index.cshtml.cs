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
			if (ModelState.IsValid)
			{
				HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(FizzBuzz));
				return RedirectToPage("./SavedInSession");
			}
			return Page();
		}

	}
}