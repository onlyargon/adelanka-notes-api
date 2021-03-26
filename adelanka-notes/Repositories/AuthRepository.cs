using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using adelanka_notes.DbEntities;
using adelanka_notes.Repositories.IRepositories;
using Microsoft.IdentityModel.Tokens;

namespace adelanka_notes.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        public AuthRepository()
        {
        }

        public async Task<Dictionary<string, object>> LoginUser(User _input, string secretKey)
        {
            Dictionary<string, object> jsonObj = new Dictionary<string, object>();

            try
            {
                using (var _DbEntity = new adelankanotesContext())
                {
                    var _username = Encoding.ASCII.GetString(Convert.FromBase64String(_input.Username));
                    var _password = Encoding.ASCII.GetString(Convert.FromBase64String(_input.Password));

                    var user = _DbEntity.Users.Where(x => x.IsDeleted == false && x.Username.Equals(_username) && x.Password.Equals(_password)).FirstOrDefault();
                    if (user != null)
                    {
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var key = Encoding.ASCII.GetBytes(secretKey);
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                            {
                            new Claim(ClaimTypes.Name, user.UserId.ToString())
                            }),
                            Expires = DateTime.UtcNow.AddDays(7),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                            SecurityAlgorithms.HmacSha256Signature)
                        };

                        var token = tokenHandler.CreateToken(tokenDescriptor);
                        var resp = new
                        {
                            userId = user.UserId,
                            token = tokenHandler.WriteToken(token)
                        };

                        jsonObj.Add("Code", 0);
                        jsonObj.Add("Status", "Success");
                        jsonObj.Add("Message", "Valid User");
                        jsonObj.Add("Data", resp);
                    }
                    else
                    {
                        jsonObj.Add("Code", 1);
                        jsonObj.Add("Status", "Fail");
                        jsonObj.Add("Message", "Invalid User");
                        jsonObj.Add("Data", null);
                    }
                }
            }
            catch (Exception ex)
            {
                jsonObj.Add("Code", 1);
                jsonObj.Add("Status", "Fail");
                jsonObj.Add("Message", $"{ex.Message}");
                jsonObj.Add("Data", null);
            }

            return await Task.FromResult(jsonObj);

        }
    }
}
