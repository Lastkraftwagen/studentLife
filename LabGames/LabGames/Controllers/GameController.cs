using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabGames.Core;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using LabGames.API.Interfaces;

namespace LabGames.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IDataService dataService;
        public GameController(IDataService dataService)
        {
            this.dataService = dataService;
        }

        [HttpPost]
        [Route("StartGame")]
        public ActionResult<Player> StartGame(GamePair gamePair)
        {
            try
            {
                Player p = gamePair.Player;
                string Id = gamePair.Id;
                p.Place = PlaceType.Home;
                p.Company = CompanyType.Alone;

                Game game = new Game();
                switch (p.RandomSkill)
                {
                    case RandomSkill.Reach:
                        p.ChangeMoney(500);
                        break;
                    case RandomSkill.Happy:
                        p.ChangeHappines(10);
                        break;
                    case RandomSkill.Strong:
                        p.ChangePower(10);
                        break;
                    default:
                        break;
                }
                game.p = p;
                if (!GameManager.Games.ContainsKey(Id))
                    GameManager.Games.Add(Id, game);
                else if (GameManager.Games.ContainsKey(Id))
                {
                        GameManager.Games.Remove(Id);
                    GameManager.Games.Add(Id, game);
                }
                return p;
            }
            catch (Exception ex)
            {
                return null;
            }
            //return GameManager.Games["1"].p;
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
                    return BadRequest("No game with this ID started.");

                var result = game.GetCurrentEvents();
                return Ok(JsonConvert.SerializeObject(game.GetCurrentEvents().ToArray())); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("GetPlayer")]
        public async Task<ActionResult<Player>> GetPlayer()
        {
            try
            {
                IFormCollection req = await HttpContext.Request.ReadFormAsync();
                string Id = req["gameId"].ToString();
                Game game = null;
                if (GameManager.Games.ContainsKey(Id))
                    game = GameManager.Games[Id];
                else
                    return BadRequest();

                Player result = game.p;
                return Ok(JsonConvert.SerializeObject(result));

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("GetTime")]
        public async Task<ActionResult<Time>> GetTime()
        {
            try
            {
                IFormCollection req = await HttpContext.Request.ReadFormAsync();
                string Id = req["gameId"].ToString();
                Game game = null;
                if (GameManager.Games.ContainsKey(Id))
                    game = GameManager.Games[Id];
                else
                    return BadRequest();

                Time result = game.GetCurrentTime().CurrentTime;
                return Ok(JsonConvert.SerializeObject(result));

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("SaveGame")]
        public async Task<ActionResult<string>> SaveGame()
        {
            try
            {
                IFormCollection req = await HttpContext.Request.ReadFormAsync();
                string Id = req["gameId"].ToString();
                int userId = int.Parse(req["userId"]);
                string saveName = req["saveName"].ToString();
                Game game = null;
                if (GameManager.Games.ContainsKey(Id))
                    game = GameManager.Games[Id];
                else
                    return BadRequest();

                if (dataService.SaveGame(game, userId, saveName))
                    return Ok(JsonConvert.SerializeObject("Saved"));
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("LoadGame")]
        public async Task<ActionResult<bool>> LoadGame()
        {
            try
            {
                IFormCollection req = await HttpContext.Request.ReadFormAsync();
                string gameId = req["gameId"].ToString();
                int userId = int.Parse(req["userId"]);
                int savedGameId = int.Parse(req["savedGameId"]);
                Game game = dataService.LoadGame(userId, savedGameId);
                if (GameManager.Games.ContainsKey(gameId))
                    GameManager.Games.Remove(gameId);
                GameManager.Games.Add(gameId, game);
                return true;

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("WorkDone")]
        public async Task<ActionResult<Player>> WorkDone()
        {
            try
            {
                IFormCollection req = await HttpContext.Request.ReadFormAsync();
                string Id = req["gameId"].ToString();
                Game game = null;
                if (GameManager.Games.ContainsKey(Id))
                    game = GameManager.Games[Id];
                else
                    return BadRequest();

                game.p.WorkTiles += 1;
                return Ok(JsonConvert.SerializeObject(game.p));

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("SelectEvent")]
        public ActionResult<EventResponce> SelectEvent(StringIntPair formData)
        {
            EventResponce response = new EventResponce();
            try
            {
                string Id = formData.gameId;
                int eventId = formData.selectedEvent;
                Game game = null;
                if (GameManager.Games.ContainsKey(Id))
                    game = GameManager.Games[Id];
                else
                    return BadRequest();

                ExecutionResult result = game.ExecuteEvent(eventId);
                if (result.Win)
                {
                    response.status = Statuses.WIN;
                    response.result = result.Result;
                    response.message = result.message;
                    return Ok(JsonConvert.SerializeObject(response));
                }
                else if (result.IsExecuted)
                {
                    response.status = Statuses.SUCCESS;
                    response.result = result.Result;
                    if(game.actionEventsIds.Contains(eventId))
                    {
                        response.isAction = true;
                        response.actionId = eventId;
                    }
                    return Ok(JsonConvert.SerializeObject(response));
                }
                else if (result.Continued)
                {
                    response.status = Statuses.CONTINUED;
                    response.result = result.Result;
                    return Ok(JsonConvert.SerializeObject(response));
                }
                else if (result.Dead)
                {
                    response.status = Statuses.DEAD;
                    response.result = result.Result;
                    response.message = result.message;
                    return Ok(JsonConvert.SerializeObject(response));
                }
                else
                {
                    response.status = Statuses.FAIL;
                    return BadRequest(JsonConvert.SerializeObject(response));
                }
            }
            catch (Exception ex)
            {
                response.status = Statuses.FAIL;
                response.message = ex.Message;
                return BadRequest(JsonConvert.SerializeObject(response));
            }
        }
    }


    public class GamePair
    {
        public string Id;
        public Player Player;
    }

    public class StringIntPair
    {
        public string gameId;
        public int selectedEvent;
    }

    public class EventResponce
    {
        public string status;
        public string message;
        public bool isAction = false;
        public int actionId = 0;
        public List<string> result;
    }

}