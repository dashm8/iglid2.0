using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iglid.Models.TournamentsModels
{
    public class tourInv
    {
        public long id { get; set; }
        public Team team { get; set; }
        public tournament tourid { get; set; }
        public ApplicationUser sender { get; set; }

    }
}
