using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Xml.Linq;

namespace AssignmentForKYC360.Models
{
    public class Entity : IEntity
    {
        public string? Id { get; set; }
        public List<Name>? Names { get; set; }
        public List<Address>? Addresses { get; set; }
        public List<Date>? Dates { get; set; }
        public bool Deceased { get; set; }
        public string? Gender { get; set; }
    }
}
