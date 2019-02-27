using Sheekr.Domain.Entities.Enum;

namespace Sheekr.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public Role Role { get; set; }
        public byte[] HashedPassword { get; set; }
        public byte[] Salt { get; set; }       
    }
}
