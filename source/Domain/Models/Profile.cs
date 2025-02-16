using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public record Profile
    (
        string DisplayName,
        string Country,
        string Surname,
        string Mail,
        string UserPrincipalName,
        string JobTitle,
        string MobilePhone,
        string OfficeLocation,
        string Department
    );
}
