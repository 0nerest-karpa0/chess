using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AuthSample.Backend.Entity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Chess.Backend.Dto;
using Microsoft.AspNetCore.SignalR;

namespace Chess.Backend.Controllers
{
    [Controller]
    [Route("/match")]
    public class MatchController : ControllerBase
    {
        private ApplicationDbContext _context;
        private IHubContext<MatchHub> _hub;
        public MatchController(ApplicationDbContext context, IHubContext<MatchHub> hub)
        {
            _context = context;
            _hub = hub;
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

            _hub.Groups.AddToGroupAsync(userId.ToString(), match.Id.ToString());
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

            _hub.Groups.AddToGroupAsync(userId.ToString(), match.Id.ToString());
            return NoContent();
        }

        [Authorize]
        [HttpPost("disconnect/{matchId:guid}")]
        public IActionResult Disconnect([FromRoute] Guid matchId)
        {
            Match? match = _context.Matches.Where(m => m.Id == matchId).FirstOrDefault();
            if (match == null) return NotFound("there is no match with this id");
            if (match.isStarted)
            {
                return BadRequest("You cant disconnect from stared match");
            }

            string userIdString = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First().Value;
            Guid userId = Guid.Parse(userIdString);

            if (match.HostId == userId)
            {
                _context.Matches.Remove(match);
            }
            else if(match.BlackId == userId)
            {
                match.BlackId = null;
            }
            else if(match.WhiteId == userId)
            {
                match.WhiteId = null;
            }
            else
            {
                BadRequest("You are not connected to this match");
            }
            _context.SaveChanges();
            _hub.Groups.RemoveFromGroupAsync(userId.ToString(), matchId.ToString());

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
        public IActionResult GetCurrentBoardState([FromRoute] Guid matchId)
        {
            Match? match = _context.Matches.Where(m => m.Id == matchId).Include(m => m.Moves).FirstOrDefault();
            if (match == null) return NotFound("there is no match with this id");

            if (!match.isStarted) return BadRequest("Match is not started yet");

            return Ok(match.Moves.OrderBy(m => m.MoveCount).Last().Board);
        }

        [Authorize]
        [HttpPost("makemove/{matchId:guid}")]
        public IActionResult MakeMove([FromRoute] Guid matchId, [FromBody]MoveDto moveDto)
        {
            Match? match = _context.Matches.Where(m => m.Id == matchId).Include(m => m.Moves).FirstOrDefault();
            if (match == null) return NotFound("there is no match with this id");
            if (!match.isStarted) return BadRequest("Match is not started yet");

            string userIdString = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First().Value;
            Guid userId = Guid.Parse(userIdString);
            string userColor = "";

            if(match.BlackId == userId) userColor = "b";
            else if(match.WhiteId == userId) userColor = "w";
            else return BadRequest("You are not connected to this match");

            Move lastMove = match.Moves.OrderBy(m => m.MoveCount).Last();
            string lastMoveFen = match.Moves.OrderBy(m => m.MoveCount).Last().Board;
            string[] fenFields = lastMoveFen.Split(' ');
            string lastMoveColor = fenFields[1];
            
            if(lastMoveColor == userColor)
            {
                return BadRequest("Its not your move yet");
            }

            Move move = new Move { Board = moveDto.Board, MatchId = match.Id, MoveCount = lastMove.MoveCount + 1, IsCheckmate = moveDto.IsCheckmate, IsDraw = moveDto.IsDraw };
            _context.Moves.Add(move);

            match.isEnded = moveDto.IsCheckmate || moveDto.IsDraw;
            _context.SaveChanges();

            _hub.Clients.Group(matchId.ToString()).SendAsync("ReceiveMove", moveDto);
            return NoContent();
        }
    }
}
