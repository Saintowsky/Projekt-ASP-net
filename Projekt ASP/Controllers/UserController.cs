using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Projekt_ASP.Areas.Identity.Data;
using Projekt_ASP.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private AuthDbContext _dbContext;
        public UserController(AuthDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("GetUsers")]
        public IActionResult Get()
        {
            try
            {
                var users = _dbContext.Users.ToList();
                if(users.Count == 0)
                {
                    return StatusCode(404, "No user found");
                }

                return Ok(users);

            }
            catch (Exception)
            {
                return StatusCode(500, "An error has ocured");
            }
        }



    }
}
