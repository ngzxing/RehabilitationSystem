using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.ViewModels.Session;

namespace RehabilitationSystem.Controllers.ApiControllers
{
    [Route("api/Session")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionRepository _sessionRepo;

        public SessionController(ISessionRepository sessionRepo)
        {
            _sessionRepo = sessionRepo;
        }

        // GET: api/Session/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById( [FromRoute] string id)
        {
            List<string> includes = new List<string> { "Therapists", "Slots" };
            GetSession? session = await _sessionRepo.GetByIdAsync(id, includes);

            if (session == null)
            {
                return NotFound();
            }

            return Ok(session);
        }

    }
}