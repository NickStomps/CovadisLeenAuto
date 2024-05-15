using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCovadis.Shared
{
    public class AuthResponse
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
