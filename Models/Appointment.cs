using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _mvc_Sallon_Appointment.Models
{
    public class Appointment
    {

        public int Id { get; set; }

        public int ClientId { get; set; }

        public int HairDresserId { get; set; }

        public int HairDressingOptionId { get; set; }

        public Client Client { get; set; }

        public Hairdresser Hairdresser { get; set; }

        public Haircut Haircut { get; set; }
    }
}
