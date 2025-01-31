using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Dekatop_II_04.Models
{
    public class Participant
    {
        public int? ParticipantId {  get; set; }
        public int? EventId {  get; set; }
        public string? Name {  get; set; }
        public int? Age { get; set; }
        public decimal? Speed { get; set; }
    }
}
