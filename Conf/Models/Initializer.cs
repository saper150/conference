using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conf.Models {
    public class DbInitializer {
        public static void Initialize(ConferenceContext ctx) {

            ctx.Database.EnsureCreated();
    
            if (!ctx.Cities.Any()) {
                ctx.Cities.Add(new City() {
                    Name= "Bielsko",
                });

                ctx.Cities.Add(new City() {
                    Name = "Warszawa",
                });

                ctx.Cities.Add(new City() {
                    Name = "Zabrze",
                });

                ctx.SaveChanges();
            }
        }
    }
}
