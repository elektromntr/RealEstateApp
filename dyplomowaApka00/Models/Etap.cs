using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace dyplomowaApka00.Models
{
    public class Etap
    {
        [Key]
        public int EtapId { get; set; }

        [MaxLength(20)]
        public string Nazwa { get; set; }

        virtual public ICollection<Mieszkanie> Mieszkania { get; set; }
    }
}