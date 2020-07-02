using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSample.Models
{
    public class TravelMemory
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("出発日")]
        public DateTime StartDate { get; set; }

        [Remote(action: "VerifyTravelDate", controller: "TravelMemories", AdditionalFields = nameof(StartDate))]
        [DataType(DataType.Date)]
        [DisplayName("帰宅日")]
        public DateTime EndDate { get; set; }

        [Remote(action: "VerifyComment", controller: "TravelMemories", AdditionalFields = nameof(StartDate) + "," + nameof(EndDate) + "," + nameof(Id))]
        [DisplayName("コメント")]
        public string Comment { get; set; }

        public int? TravelDestinationId { get; set; }

        public TravelDestination TravelDestination { get; set; }
    }
}
