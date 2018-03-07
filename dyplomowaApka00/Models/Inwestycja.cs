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

        [MaxLength(140)]
        [DataType(DataType.MultilineText)]
        public string HeaderOne { get; set; }

        [DataType(DataType.MultilineText)]
        public string DescOne { get; set; }

        [MaxLength(140)]
        [DataType(DataType.MultilineText)]
        public string HeaderTwo { get; set; }

        [DataType(DataType.MultilineText)]
        public string DescTwo { get; set; }

        [MaxLength(140)]
        [DataType(DataType.MultilineText)]
        public string HeaderThree { get; set; }

        [DataType(DataType.MultilineText)]
        public string DescThree { get; set; }

        [MaxLength(140)]
        [DataType(DataType.MultilineText)]
        public string HeaderFour { get; set; }

        [DataType(DataType.MultilineText)]
        public string DescFour { get; set; }

        virtual public ICollection<Mieszkanie> Mieszkania { get; set; }

        virtual public ICollection<Etap> Etapy { get; set; }
    }
}