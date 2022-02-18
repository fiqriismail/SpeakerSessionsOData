using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SpeakerSessions.Api.Models;
using System.Linq;

namespace SpeakerSessions.Api.Controllers
{
    [Route("/api/sessions")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly SpeakerSessionsDbContext _context;


        public SessionsController(SpeakerSessionsDbContext context)
        {
            _context = context;

            if (!_context.Sessions.Any())
            {
                foreach (var session in DataSource.GetSessions())
                {
                    _context.Sessions.Add(session);
                    _context.Speakers.Add(session.Speaker);
                }

                _context.SaveChanges();
            }
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult GetSessions()
        {
            return Ok(_context.Sessions);
        }

        [EnableQuery]
        [HttpGet("{id}", Name = "GetOneSession")]
        public IActionResult GetSession(int id)
        {
            return Ok(_context.Sessions.Find(id));
        }

        [HttpPost]
        public IActionResult PostSession([FromBody] Session session)
        {
            _context.Sessions.Add(session);
            _context.SaveChanges();

            return CreatedAtRoute("GetOneSession", new { id = session.Id }, session);
        }

        [HttpDelete]
        public IActionResult DeleteSession(int id)
        {
            var session = _context.Sessions.Find(id);

            if (session == null) return NotFound();

            _context.Sessions.Remove(session);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut]
        public IActionResult PutSession([FromBody] Session session)
        {
            _context.Update(session);
            _context.SaveChanges();
            return CreatedAtRoute("GetOneSession", new { id = session.Id }, session);
        }
    }
}
