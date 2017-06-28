using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace dyplomowaApka00.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        
        [MaxLength(10)]
        [DisplayName("Status")]
        public string Nazwa { get; set; }

        virtual public ICollection<Mieszkanie> Mieszkania { get; set; }

        virtual public ICollection<Dom> Domy { get; set; }
    }
}