using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _mvc_Sallon_Appointment.Data
{
    public class SallonappointmentDbContext : DbContext
    {
        public SallonappointmentDbContext(DbContextOptions<SallonappointmentDbContext> options)
            : base(options)
        {
        }
        public DbSet<_mvc_Sallon_Appointment.Models.Appointment> Appointment { get; set; }

        public DbSet<_mvc_Sallon_Appointment.Models.Client> Client { get; set; }

        public DbSet<_mvc_Sallon_Appointment.Models.Haircut> Haircut { get; set; }

        public DbSet<_mvc_Sallon_Appointment.Models.Hairdresser> Hairdresser { get; set; }
    }
}
