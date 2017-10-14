using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dyplomowaApka00.Models
{
    public class Dom
    {
        [Key]
        public int DomId { get; set; }

        [Display(Name ="Symbol domu")]
        [MaxLength(10)]
        [Required(ErrorMessage ="Proszę podać symbol domu")]
        public string SymbolDomu { get; set; }

        [Display(Name ="Inwestycja")]
        public int? InwestycjaId { get; set; }

        [ForeignKey("InwestycjaId")]
        public virtual Inwestycja Inwestycja { get; set; }

        [Display(Name ="Status domu")]
        public int? StatusId { get; set; }

        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }

        [Display(Name = "Cena w zł")]
        [Required(ErrorMessage = "Proszę podać cenę mieszkania")]
        [DataType(DataType.Currency)]
        public decimal Cena { get; set; }
        
        [Required(ErrorMessage = "Proszę podać powierzchnię domu")]
        public byte Powerzchnia { get; set; }

        [Required(ErrorMessage = "Proszę podać ilość pokoi w domu")]
        public byte Pokoje { get; set; }

        [Display(Name = "Powierzchnia ogrodu")]
        public byte? Ogrod { get; set; }
        
        [Display(Name = "Garaż")]
        public bool Garaz { get; set; }

        [Display(Name = "Miejsce postojowe")]
        public bool MiejscePostojowe { get; set; }

        [Display(Name = "Komórka lokatorska")]
        public bool KomorkaLokatorska { get; set; }

        [Display(Name = "Termin realizacji")]
        [DataType(DataType.Date)]
        public DateTime TerminRealizacji { get; set; }

        public string ImageFile
        {
            get
            {
                return SymbolDomu;
            }
            set
            {

            }
        }

        [MaxLength(222)]
        [Display(Name = "Dodatkowe informacje")]
        [DataType(DataType.MultilineText)]
        public string DodatkoweInfo { get; set; } 

        //public virtual ICollection<Klient> Klienci { get; set; }

    } //class Dom
} // namespace