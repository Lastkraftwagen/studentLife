using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabGames.Core;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace LabGames.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class GameController : ControllerBase
    {

        [HttpPost]
        [Route("StartGame")]
        public ActionResult<Player> StartGame(GamePair gamePair)
        {
            try
            {
                //IFormCollection req = await HttpContext.Request.ReadFormAsync();
                //string Id = req["Id"].ToString();
                //Player p = JsonConvert.DeserializeObject<Player>(req["name"].ToString());

                //Stream req = Request.Body;
                //req.Seek(0, System.IO.SeekOrigin.Begin);
                //string json = new StreamReader(req).ReadToEnd();

                //try
                //{
                //    input = JsonConvert.DeserializeObject<InputClass>(json);
                //}

                //catch (Exception ex)
                //{
                //    // Try and handle malformed POST body
                //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //}
                Player p = gamePair.Player;
                string Id = gamePair.Id;
                p.Place = PlaceType.Home;
                p.Company = CompanyType.Alone;
                
                Game game = new Game();
                game.p = p;
                if (!GameManager.Games.ContainsKey(Id))
                    GameManager.Games.Add(Id, game);
                return p;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("GetEvents")]
        public ActionResult<EventModel> GetEvents(GamePair gamePair)
        {
            try
            {
                Player p = gamePair.Player;
                string Id = gamePair.Id;
                Game game = null;
                if (GameManager.Games.ContainsKey(Id))
                    game = GameManager.Games[Id];
                else
                    return BadRequest();

                var result = game.GetCurrentEvents();

                return Ok(JsonConvert.SerializeObject(game.GetCurrentEvents().ToArray())); 

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }


    public class GamePair
    {
        public string Id;
        public Player Player;
    }
}