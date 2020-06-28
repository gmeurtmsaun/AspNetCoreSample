using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSample.Models
{
    public class TravelDestinations
    {
        public int Id { get; set; }

        public string Destination { get; set; }

        public string MyApplicationUserId { get; set; }

        public MyApplicationUser User { get; set; }
    }
}
