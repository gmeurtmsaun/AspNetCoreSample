using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSample.Models
{
    public class MyApplicationUser : IdentityUser
    {
        public string RecommendTravelDestination { get; set; }



        public ICollection<TravelDestination> LikeTravelDestinations { get; set; }
    }
}
