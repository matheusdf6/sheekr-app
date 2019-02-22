using Microsoft.AspNetCore.Identity;

namespace Sheekr.Data
{
    public class SheekrUser : IdentityUser
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }

        public string NomeCompleto { get => PrimeiroNome + " " + UltimoNome; }
    }
}

