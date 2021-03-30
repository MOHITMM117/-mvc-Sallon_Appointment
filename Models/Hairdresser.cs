using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _mvc_Sallon_Appointment.Models
{
    public class Hairdresser
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public bool IsPermanent { get; set; }
    }
}
