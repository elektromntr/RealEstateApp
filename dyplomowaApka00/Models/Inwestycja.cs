using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dyplomowaApka00.Models
{
    public class Inwestycja
    {
        [Key]
        public int InwestycjaId { get; set; }

        [MaxLength(19)]
        [DisplayName("Inwestycja")]
        public string Nazwa { get; set; }

        /*[DisplayName("Data rozpoczęcia inwestycji")]
        [DataType(DataType.Date)]
        public DateTime DataRozpoczecia { get; set; }*/

        virtual public ICollection<Mieszkanie> Mieszkania { get; set; }

        virtual public ICollection<Dom> Domy { get; set; }
    }
}