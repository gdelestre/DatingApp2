using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Entities;
using API.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class TokenService : ITokenService
    {
        //Symmetric key : clé utiliser pour encrypter et décrypter électronique information
        // Différent de SSL (clé asynchrone)
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            //
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        public string CreateToken(AppUser user)
        {
            // Claim : pair de clé/valeur que va contenir le token
            // Dans ce cas, le token contient juste le nom
            // Il pourrait aussi contenir le role de l'utilisateur par exemple
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
            };

            //Indique la clé et l'algorithm 
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            //Description du token. Spécifie ce que va contenir le token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            //Va permettre de créer le token
            var tokenHandler = new JwtSecurityTokenHandler();

            //Création du token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            //Retourne le token qui est écrit
            return tokenHandler.WriteToken(token);

        }
    }
}