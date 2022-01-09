using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DataLayer.Entities;

public class UniversityUser:IdentityUser
{
    public int PersonId { get; set; }
    public Person Person { get; set; }
}

