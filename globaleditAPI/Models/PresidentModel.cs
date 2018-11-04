using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CorcoranAPI.Models
{
    public class PresidentModel
    {
        public class President
        {
           
            [Key]
            public Guid Id { get; set; }
            public string president { get; set; } 
            public string birthday { get;  set; }
            public string birthplace { get; set; }
            // Intentionally declared as string instead datetime 
            public string deathday { get;  set; } 
            public string Deathplace { get;  set; }

        }

        public class PresidentContext : DbContext
        {
            public PresidentContext(DbContextOptions<PresidentContext> options) : base(options)
            {

            }

            public DbSet<President> Presidents { get; internal set; }


        }
    }

}  