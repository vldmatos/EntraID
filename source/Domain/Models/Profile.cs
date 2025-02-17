using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Profile
    {
        public string? DisplayName { get; set; }
        public string? Country { get; set; }
        public string? Surname { get; set; }
        public string? Mail { get; set; }
        public string? UserPrincipalName { get; set; }
        public string? JobTitle { get; set; }
        public string? MobilePhone { get; set; }
        public string? OfficeLocation { get; set; }
        public string? Department { get; set; }
    }
}
