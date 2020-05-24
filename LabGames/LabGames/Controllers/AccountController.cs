using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabGames.API.Interfaces;
using LabGames.API.Results;
using LabGames.Core;
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
        public async Task<ActionResult<User>> LogIn()
        {
            IFormCollection req = await HttpContext.Request.ReadFormAsync();
            User user = dataService.LogIn(req["email"].ToString(), req["password"].ToString());
            return Ok(user);
        }

        [HttpPost]
        [Route("Do")]
        public async Task<ActionResult<string>> Do()
        {
            IFormCollection req = await HttpContext.Request.ReadFormAsync();
            string Id = req["Id"];
            //GameManager.Games[Id].p.isDrunk = true;
            return Ok("ok");
        }


        [HttpPost]
        [Route("SignUp")]
        public ActionResult<User> SignUp(User user)
        {
            RegisterResult result = dataService.RegisterUser(user);
            if (!result.Exist) return null;

            return Ok(result.User);
        }
       

    }
}
