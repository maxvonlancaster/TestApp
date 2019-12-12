using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Forum.DAL.Entities
{
    public class User : IdentityUser<string>
    {
        public int Rating { get; set; }
        public byte[] Picture { get; set; }
    }
}
