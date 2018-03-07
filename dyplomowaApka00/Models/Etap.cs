using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dyplomowaApka00.Models
{
    public class Etap
    {
        [Key]
        public int EtapId { get; set; }

        [MaxLength(20)]
        public string Nazwa { get; set; }

        // tutaj zapisujemy Inwestycje: Lutynia, Smolec, Krzeptów itp.
        public int? InwestycjaId { get; set; }

        [ForeignKey("InwestycjaId")]
        [DisplayName("Inwestycja")]
        public virtual Inwestycja Inwestycja { get; set; }
        
        virtual public ICollection<Mieszkanie> Mieszkania { get; set; }
    }
}