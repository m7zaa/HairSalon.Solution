using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairSalon.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public int StylistId { get; set; }
        [ForeignKey("StylistId")]
        public virtual Stylist Stylist { get; set; }
    }
}