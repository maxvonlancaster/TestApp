using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicTracks.Models
{
    public class UserIdentity : IdentityUser<string>
    {
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Rate { get; set; }
    }
}
