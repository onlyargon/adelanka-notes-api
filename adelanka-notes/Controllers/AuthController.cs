using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using adelanka_notes.DbEntities;
using adelanka_notes.Repositories;
using adelanka_notes.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace adelanka_notes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        IAuthRepository authRepository = new AuthRepository();
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        #region LoginUser
        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser(User _input)
        {
            if (ModelState.IsValid)
            {
                return Ok(await Task.Run(() => authRepository.LoginUser(_input, _config.GetValue<string>("JwtSecretKey"))));
            }
            else
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("Response", "Error");
                data.Add("Code", "FCE00006");
                data.Add("Description", "Invalid JSON");
                data.Add("Data", null);
                return Ok(data);
            }
        }
        #endregion
    }
}