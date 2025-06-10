using ExerciseTracker.Study.Models;
using ExerciseTracker.Study.Models.DTO;
using ExerciseTracker.Study.Repositories;
using ExerciseTracker.Study.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseTracker.Study.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseShiftController : ControllerBase
    {
        private readonly IService<ExerciseShift> ShiftService;
        public ExerciseShiftController(IService<ExerciseShift> service)
        {
            ShiftService = service;
        }
        [HttpGet]
        public async Task<ActionResult<ResponseDto<ExerciseShift>>> GetAllShifts()
        {
            return await ShiftService.GetAll();
        }
        [HttpGet]
        [Route("{Id:int}")]
        public async Task<ActionResult<ResponseDto<ExerciseShift>>> GetById([FromRoute]int Id)
        {
            return await ShiftService.GetById(Id);
        }
    }
}
