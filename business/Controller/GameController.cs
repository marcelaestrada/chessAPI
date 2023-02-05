using Microsoft.AspNetCore.Mvc;
using chessAPI.business.interfaces;
//using chessAPI.models.player;
using chessAPI.models.game;
using Microsoft.AspNetCore.Authorization;


namespace chessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameBusiness<int> bs;

        public GameController(IGameBusiness<int> bs)
        {
            this.bs = bs;
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("PostGame")]
        [AllowAnonymous]
        public async Task<IActionResult> postGame(clsNewGame newGame)
        {
            var result = Results.Ok(await bs.addGame(newGame));
            return Ok(result);
        }

        [HttpPut]
        [Produces("application/json")]
        [Route("UpdateGame")]
        [AllowAnonymous]
        public async Task<IActionResult> updateGame(clsNewGame newGame)
        {
            var result = Results.Ok(await bs.updateGame(newGame));
            return Ok(result);
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("GetGames")]
        [AllowAnonymous]
        public async Task<IActionResult> getGames()
        {
            var result = Results.Ok(await bs.getGames());
            return Ok(result);
        }

        [HttpDelete]
        [Produces("application/json")]
        [Route("GetGames")]
        [AllowAnonymous]
        public async Task<IActionResult> deleteGames(clsGame<int> game)
        {
            var result = Results.Ok(await bs.deleteGame(game));
            return Ok(result);
        }

    }
}

