﻿using System;
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

        public int? InwestycjaId { get; set; }

        [ForeignKey("InwestycjaId")]
        [DisplayName("Inwestycja")]
        public virtual Inwestycja Inwestycja { get; set; }

        public int? StatusId { get; set; }

        [ForeignKey("StatusId")]
        [DisplayName("Status mieszkania")]
        public virtual Status Status { get; set; }

        [DisplayName("Cena w zł")]
        [Required(ErrorMessage = "Proszę podać cenę mieszkania")]
        [DataType(DataType.Currency)]
        public decimal Cena { get; set; }
        //public uint Cena { get; set; }

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

        /*public int? Rodzaj { get; set; }



        [DisplayName("Powierzchnia w metrach kwadratowych")]
        public short Powierzchnia { get; set; }

        [DisplayName("Ilość pokoi")]
        public char IloscPokoi { get; set; }

        public char Kondygnacja { get; set; }

        [DisplayName("Cena w PLN")]
        public int Cena { get; set; }

        public bool Wolne { get; set; }

        [DisplayName("Ogród")]
        public bool Ogrod { get; set; }

        public bool Antresola { get; set; }
    }
}

/*MieszkanieID PK int
SybolMieszkania string
Inwestycja string FK >- Inwestycja.InwestycjaID
Status string FK >- Status.StatusID
Cena int
Poziom char
Powierzchnia short
Pokoje char
Ogrod int
Antresola bool
Garaz bool
TerminRealizacji data
MiejscePostojowe bool
KomorkaLokatorska bool
DodatkoweInfo string

        
        */
