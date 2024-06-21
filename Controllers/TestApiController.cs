using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RehabilitationSystem.Data;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.ViewModels.Report;
using RehabilitationSystem.ViewModels.ReportSkill;
using RehabilitationSystem.ViewModels.Skill;

namespace RehabilitationSystem.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class TestApiController: ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IReportRepository _reportRepo;
        private readonly ISkillRepository _skillRepo;

        public TestApiController( ApplicationDbContext context, IReportRepository reportRepo, ISkillRepository skillRepo ){
            
            _context = context;
            _reportRepo = reportRepo;
            _skillRepo = skillRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string id){

            return Ok( await _skillRepo.GetSetByIdAsync(id, ["SkillCategories", "SkillLineItems"]));
        }

        [HttpPost("Set")]
        public async Task<IActionResult> Add( [FromBody]AddSet vm ){

            var (err_msg, result) = await _skillRepo.AddSetAsync(vm);
            return Ok(err_msg);
        }

        [HttpPost("Category")]
        public async Task<IActionResult> AddCat( [FromBody]AddCategory vm ){

            var (err_msg, result) = await _skillRepo.AddCategoryAsync(vm);
            return Ok(err_msg);
        }

        [HttpPost("Item")]
        public async Task<IActionResult> AddItem( [FromBody]AddLineItem vm ){

            var (err_msg, result) = await _skillRepo.AddLineItemAsync(vm);
            return Ok(err_msg);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete( [FromQuery]String obj, [FromQuery]String id ){

            return Ok(await _skillRepo.DeleteAsync(obj, id));
        }
    }
}