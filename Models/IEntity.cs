using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Xml.Linq;

namespace AssignmentForKYC360.Models
{
    public interface IEntity
    {
        List<Address> Addresses { get; set; }
        List<Date> Dates { get; set; }
        bool Deceased { get; set; }
        string Gender { get; set; }
        string Id { get; set; }
        List<Name> Names { get; set; }
    }
}
