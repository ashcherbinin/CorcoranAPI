using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CorcoranAPI.Models
{
    public class PresidentModel
    {
        public class PresidentList
        {
           
            [Key]
            public Guid Id { get; set; }
            public string president { get; internal set; } 
            public string birthday { get; internal set; }
            public string birthplace { get; internal set; }
            // Intentionally declared as string instead datetime 
            public string deathday { get; internal set; } 
            public string Deathplace { get; internal set; }

        }

        public class PresidentContext : DbContext
        {
            public PresidentContext(DbContextOptions<PresidentContext> options) : base(options)
            {

            }

            public DbSet<PresidentList> Presidents { get; set; }


        }
    }

}  