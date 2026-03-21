using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AuthSample.Backend.Entity;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Chess.Backend.Controllers
{
    [Controller]
    [Route("/match")]
    public class MatchController : ControllerBase
    {
        private ApplicationDbContext _context;
        public MatchController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("host/{color:alpha}")]
        public IActionResult HostMatch([FromRoute] char color)
        {
            if (color != 'w' && color != 'b') return BadRequest("color must be \"w\" for white or \"b\" for black");

            string userIdString = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First().Value;
            Guid userId = Guid.Parse(userIdString);
            Match match = new Match { Id = Guid.NewGuid(), HostId = userId };

            if (color == 'w')
            {
                match.WhiteId = userId;
            }
            else
            {
                match.BlackId = userId;
            }

            _context.Matches.Add(match);
            _context.SaveChanges();

            return Ok(match.Id);
        }

        [Authorize]
        [HttpPost("connect/{matchId:guid}")]
        public IActionResult Connect([FromRoute] Guid matchId)
        {
            Match? match = _context.Matches.Where(m => m.Id == matchId).FirstOrDefault();
            if (match == null) return NotFound("there is no match with this id");

            string userIdString = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First().Value;
            Guid userId = Guid.Parse(userIdString);

            if (match.BlackId == null && match.WhiteId != userId)
            {
                match.BlackId = userId;
            }
            else if (match.WhiteId == null && match.BlackId != userId)
            {
                match.WhiteId = userId;
            }
            else
            {
                return BadRequest("Match already has two players or you already part of it");
            }

            _context.SaveChanges();
            return NoContent();
        }

        [Authorize]
        [HttpPost("switchsides/{matchId:guid}")]
        public IActionResult SwitchSides([FromRoute] Guid matchId)
        {
            Match? match = _context.Matches.Where(m => m.Id == matchId).FirstOrDefault();
            if (match == null) return NotFound("there is no match with this id");

            string userIdString = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First().Value;
            Guid userId = Guid.Parse(userIdString);
            if (match.HostId == userId)
            {
                Guid? whiteId = match.WhiteId;
                match.WhiteId = match.BlackId;
                match.BlackId = whiteId;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return BadRequest("You can't switch side if you are not the host of the match");
            }
        }

        [Authorize]
        [HttpPost("start/{matchId:guid}")]
        public IActionResult Start([FromRoute] Guid matchId)
        {
            Match? match = _context.Matches.Where(m => m.Id == matchId).FirstOrDefault();
            if (match == null) return NotFound("there is no match with this id");

            string userIdString = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First().Value;
            Guid userId = Guid.Parse(userIdString);

            if (match.HostId != userId)
            {
                return BadRequest("You can't start match if you are not the host of the match");
            }

            if (match.BlackId == null || match.WhiteId == null)
            {
                return BadRequest("You need to have two players connected to match in order to start it");
            }

            match.isStarted = true;
            Move moves = new Move { Id = Guid.NewGuid(), MatchId = matchId };
            _context.Moves.Add(moves);

            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("board/{matchId:guid}")]
        public IActionResult GetCurrentBoardState([FromRoute]Guid matchId)
        {
            Match? match = _context.Matches.Where(m => m.Id == matchId).Include(m => m.Moves).FirstOrDefault();
            if (match == null) return NotFound("there is no match with this id");

            if (!match.isStarted) return BadRequest("Match is not started yet");

            return Ok(match.Moves.OrderBy(m => m.MoveCount).Last().Board);
        }
    }
}
