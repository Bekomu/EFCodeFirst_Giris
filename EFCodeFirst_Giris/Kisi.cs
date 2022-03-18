using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst_Giris
{
    // * * * * * * * * * * * * * * * * * * * * BU CLASS A ENTITY CLASS DİYORUZ... 

    [Table("Kisiler")]
    public class Kisi
    {
        public int Id { get; set; }

        [Required]
        public string Ad { get; set; }

        public bool EvliMi { get; set; }
    }
}
