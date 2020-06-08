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
using Newtonsoft.Json;

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

        [HttpGet]
        [Route("Do")]
        public ActionResult<string> Do()
        {
            return Ok("server works");
        }


        [HttpPost]
        [Route("SignUp")]
        public ActionResult<User> SignUp(User user)
        {
            try
            {
                RegisterResult result = dataService.RegisterUser(user);
                if (!result.Exist) return BadRequest();
                return Ok(result.User);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("GetSavedGames")]
        public async Task<ActionResult<List<SavedGame>>> GetSavedGames()
        {
            try
            {
                IFormCollection req = await HttpContext.Request.ReadFormAsync();
                int userId = int.Parse(req["userId"]);
                List<SavedGame> savedGames = this.dataService.GetUserSavedGames(userId);
                return Ok(JsonConvert.SerializeObject(savedGames));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetRecords")]
        public ActionResult<List<Record>> GetRecords()
        {
            try
            {
                List<Record> records = this.dataService.GetRecords();
                return Ok(JsonConvert.SerializeObject(records));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
