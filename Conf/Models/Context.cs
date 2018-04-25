using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Conf.Models {
    public class ConferenceContext : DbContext {
        public DbSet<ConferenceUser> ConferenceUsers { get; set; }
        public DbSet<City> Cities { get; set; }

        public ConferenceContext(DbContextOptions<ConferenceContext> options) : base(options) { }

    }
}
