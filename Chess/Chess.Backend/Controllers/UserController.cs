using AuthSample.Backend.Entity;
using Chess.Backend.Db.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Chess.Backend.Controllers
{
    [Controller]
    [Route("/users")]
    public class UserController : ControllerBase
    {
        ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_context.Users.Select(u => new UserShortDto { Id = u.Id, Login = u.Login }).ToList());
        }

        [HttpGet("{id:guid}/info")]
        public IActionResult GetUserInfo([FromRoute] Guid id)
        {
            User? u = _context.Users.Where(u => u.Id == id).FirstOrDefault();
            if (u == null) return NotFound($"user with id \"{id}\" doesn't exist");
            else return Ok(new UserShortDto { Id = u.Id, Login = u.Login } );
        }

        [HttpGet("{id:guid}/matches")]
        public IActionResult GetUserMatches([FromRoute] Guid id)
        {
            User? u = _context.Users.Where(u => u.Id == id).FirstOrDefault();
            if (u == null) return NotFound($"user with id \"{id}\" doesn't exist");

            List<Match> matches = _context.Matches.Where(m => m.WhiteId == id || m.BlackId == id).
                Include(m => m.Moves).Include(m => m.White).Include(m => m.Black).ToList();
            return Ok(
                matches.Select(
                    m => new MatchDto
                    {
                        Id = m.Id,
                        UsersColor = GetPlayerColor(id,m.Black),
                        LastMoveBoard = m.Moves.Count == 0 ? null : m.Moves.OrderBy(m => m.MoveCount).Last().Board,
                        Black = m.BlackId == null ? null : new UserShortDto { Id = m.Black.Id, Login = m.Black.Login },
                        White = m.WhiteId == null ? null : new UserShortDto { Id = m.White.Id, Login = m.White.Login },
                        IsStarted = m.isStarted,
                        IsEnded = m.isEnded,
                    }));
        }

        private bool GetPlayerColor(Guid userId, User black)
        {
            if (black == null)
            {
                return false;
            }
            else
            {
                return black.Id == userId;
            }
        }

        public class UserShortDto
        {
            public Guid Id { get; set; }
            public string Login { get; set; }
        }

        public class MatchDto
        {
            public Guid Id { get; set; }
            //white -- false, black -- true
            public bool UsersColor { get; set; }
            public string? LastMoveBoard { get; set; }
            public UserShortDto? Black { get; set; }
            public UserShortDto? White { get; set; }
            public bool IsStarted { get; set; }
            public bool IsEnded { get; set; }

        }
    }
}
