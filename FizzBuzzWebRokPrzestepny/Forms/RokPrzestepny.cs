using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FizzBuzzWebRokPrzestepny.Forms
{
    public class RokPrzestepny
    {
        [DisplayName("Rok")]
        [Required, Range(1899, 2022, ErrorMessage = "Oczekiwana wartość {0} z zakresu {1} i {2}.")]
        public int Rok { get; set; }
        [DisplayName("Imie użytkownika")]
        public string Imie { get; set; }
    }
}
