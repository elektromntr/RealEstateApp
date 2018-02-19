using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dyplomowaApka00.Models
{
    public class Mieszkanie  
    {
        [Key]
        public int MieszkanieId { get; set; }

        [DisplayName("Symbol mieszkania")]
        [MaxLength(10)]
        [Required(ErrorMessage = "Proszę podać symbol mieszkania")]
        public string SymbolMieszkania { get; set; }

        // tutaj zapisujemy Etapy: Rondo XI, Rondo XII, Pogodna, Tarasy itp
        public int? EtapId { get; set; }

        [ForeignKey("EtapId")]
        [DisplayName("Etap")]
        public virtual Etap Etap { get; set; }

        // tutaj zapisujemy Inwestycje: Lutynia, Smolec, Krzeptów itp.
        public int? InwestycjaId { get; set; }

        [ForeignKey("InwestycjaId")]
        [DisplayName("Inwestycja")]
        public virtual Inwestycja Inwestycja { get; set; }

        // tutaj zapisuje Statusy nieruchomości
        public int? StatusId { get; set; }

        [ForeignKey("StatusId")]
        [DisplayName("Status mieszkania")]
        public virtual Status Status { get; set; }

        [DisplayName("Cena w zł")]
        [Required(ErrorMessage = "Proszę podać cenę mieszkania")]
        [DataType(DataType.Currency)]
        public decimal Cena { get; set; }
        

        [Required(ErrorMessage = "Proszę podać poziom mieszkania")]
        public byte Poziom { get; set; }

        [Required(ErrorMessage = "Proszę podać powierzchnię mieszkania")]
        public byte Powierzchnia { get; set; }

        [Required(ErrorMessage = "Proszę podać ilość pokoi w mieszkaniu")]
        public byte Pokoje { get; set; }

        [DisplayName("Powierzchnia ogrodu")]
        public byte? Ogrod { get; set; }

        public bool Antresola { get; set; }

        [DisplayName("Garaż")]
        public bool Garaz { get; set; }

        [DisplayName("Miejsce postojowe")]
        public bool MiejscePostojowe { get; set; }

        [DisplayName("Komórka lokatorska")]
        public bool KomorkaLokatorska { get; set; }

        [DisplayName("Termin realizacji")]
        [DataType(DataType.Date)]
        public DateTime TerminRealizacji { get; set; }

        [DisplayName("Rzut")]
        public string ImageFile  
        {
            get
            {
                return "/Rzuty/" + SymbolMieszkania + ".jpg"; 
            }
            set
            {

            }
        }

        [MaxLength(222)]
        [DisplayName("Dodatkowe informacje")]
        [DataType(DataType.MultilineText)]
        public string DodatkoweInfo { get; set; }

        //public virtual ICollection<Klient> Klienci { get; set; }

    } //class Mieszkanie
} //namespace

        