using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INS_FInal.Models
{
    public class AplicationUser : IdentityUser
    {
        private readonly PrivateFiles privateFiles;
        public string DepId { get; set; }

        public PrivateFiles getPrivateFiles()
        {
            return privateFiles;
        }

    }
}
