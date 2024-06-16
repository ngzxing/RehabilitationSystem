using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.ViewModels.Program;
using RehabilitationSystem.ViewModels.Session;


namespace RehabilitationSystem.Controllers.ApiControllers
{
    [Route("api/Program")]
    [ApiController]
    public class ApiProgramController : ControllerBase
    {
        private readonly IProgramRepository _programRepo;
        private readonly ISessionRepository _sessionRepo;

        public ApiProgramController(IProgramRepository programRepo, ISessionRepository sessionRepo)
        {
            _programRepo = programRepo;
            _sessionRepo = sessionRepo;
        }

        // GET: api/ApiProgram
        [HttpGet]
        public async Task<IActionResult> GetAll( [FromQuery] ProgramQuery dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<string> includes = new List<string> { "Sessions" };
            List<GetProgram> programVM = await _programRepo.GetAllAsync(dto, includes);

            if (programVM == null)
            {
                return NotFound();
            }

            return Ok(programVM);
        }

        // GET: api/ApiProgram/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById( [FromRoute] string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            GetProgram programVM = await _programRepo.GetByIdAsync(id, new List<string> { "Sessions" });

            if (programVM == null)
            {
                return NotFound();
            }

            ICollection<GetSession>? allSession = new List<GetSession>();

            foreach (var session in programVM.Sessions)
            {
                GetSession detailedSession = await _sessionRepo.GetByIdAsync(session.SessionId , new List<string>() { "Therapists", "Slots" });

                if (detailedSession != null)
                {
                    allSession.Add(detailedSession);
                }

                programVM.Sessions = allSession;
            }
           
            return Ok(programVM);
        }

    }
}