using Chess.Backend.Db;
using Microsoft.AspNetCore.Mvc;
using Chess.Backend.Db.Entities;

namespace Chess.Backend.Controllers
{
    [Controller]
    [Route("/board")]
    public class BoardController : Controller
    {
        ApplicationDbContext _context;
        public BoardController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("")]
        public ActionResult CreateMatch()
        {

        }

        [HttpGet("/match/{matchId:int}")]
        public ActionResult<List<string>> GetMatch([FromRoute]int matchId)
        {
            Match? match = _context.Matches.Where(m => m.Id == matchId).FirstOrDefault();
            if(match == null)
            {
                return NotFound("There is no match with this id");
            }
            else
            {
                return match.Moves.Select(mv => mv.Board).ToList();
            }
        }
    }
}
