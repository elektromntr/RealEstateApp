using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace dyplomowaApka00.Models
{
    public class EmailFormModel
    {
        [Display(Name = "Twoje imię")]
        public string FromName { get; set; }

        [Display(Name = "Twój email")]
        public string FromEmail { get; set; }

        [Required, Display(Name = "Twój numer telefonu"), Phone]
        [RegularExpression(@"\d{9}", ErrorMessage = "Podaj 9-cyfrowy numer telefonu komórkowego")]
        public string FromPhone { get; set; }

        public string Message { get; set; }
    }
}