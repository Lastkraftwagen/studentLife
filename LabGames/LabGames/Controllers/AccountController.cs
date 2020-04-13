using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabGames.API.Interfaces;
using LabGames.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabGames.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IDataService dataService;
        public AccountController(IDataService dataService)
        {
            this.dataService = dataService;
        }
        [HttpPost]
        [Route("LogIn")]
        public ActionResult<User> LogIn(string email, string password)
        {
            User user = dataService.LogIn(email, password);
            return Ok(user);
        }
        [HttpGet]
        public ActionResult<bool> LogIn()
        {

                return Ok(true);
        }

    }
}
