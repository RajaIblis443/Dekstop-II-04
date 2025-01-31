using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dekatop_II_04.Models
{
    public class ParticipantEvent
    {
        public int Id { get; set; }
        public string? EventName { get; set; }
        public int DistanceKm { get; set; }

        public List<Participant> Participant { get; set; } = new List<Participant>();

    }
}
