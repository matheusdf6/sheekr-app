using System.Threading.Tasks;
using System;
using Sheekr.Data;
using BC = BCrypt.Net.BCrypt;
using Sheekr.Domain.Entities;
using Sheekr.Domain.Entities.Enum;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace Sheekr.Application.Security
{
    public class UserService : IUserService
    {
        private const int _workFactor = 10;
        private readonly SheekrDbContext _db;
        private readonly SecuritySettings _secSettings;

        public UserService(SheekrDbContext db, IOptions<SecuritySettings> secSettings)
        {
            this._db = db;
            this._secSettings = secSettings.Value;
        }

        public async Task<UsuarioDto> AuthenticateAsync(string username, string password)
        {
            var user = await _db.Usuarios.SingleOrDefaultAsync(u => u.UserName == username);

            if (user == null)
                return null;
       
            var isUser = BC.Verify(password, Encoding.ASCII.GetString(user.HashedPassword));

            if (!isUser)
                return null;
            user.HashedPassword = null;

            //Autenticar Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new UsuarioDto {
                Id = user.Id,
                UserName = user.UserName,
                Token = tokenHandler.WriteToken(token),
                Password = null
            };
        }

        public async Task<bool> CreateUserAsync(Usuario user, string password, Role role = Role.NaoAutorizado)
        {
            var salt = BC.GenerateSalt(_workFactor);
            var hash = BC.HashPassword(password, salt);

            user.HashedPassword = Encoding.ASCII.GetBytes(hash);
            user.Salt = Encoding.ASCII.GetBytes(salt);
            user.Role = role;

            _db.Usuarios.Add(user);

            return (await _db.SaveChangesAsync() == 1); 
        }
    }
}
