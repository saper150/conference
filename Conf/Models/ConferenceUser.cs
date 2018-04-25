using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Conf.Models {
    public class ConferenceUser {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }
    }
}
