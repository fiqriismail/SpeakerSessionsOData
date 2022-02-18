using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using SpeakerSessions.Api.Models;

namespace SpeakerSessions.Api.Controllers
{


    public class SessionsController : ODataController
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
        public IActionResult GetSessions()
        {
            return Ok(_context.Sessions);
        }

        [EnableQuery]
        public IActionResult GetSession(int key)
        {
            return Ok(_context.Sessions.Find(key));
        }

       
    }
}
