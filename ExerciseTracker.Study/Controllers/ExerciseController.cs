using ExerciseTracker.Study.Models;
using ExerciseTracker.Study.Models.DTO;
using ExerciseTracker.Study.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseTracker.Study.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IService<Exercise> Service;
        public ExerciseController(IService<Exercise> service)
        {
            Service = service;
        }
        [HttpGet]
        public async Task<ActionResult<ResponseDto<Exercise>>> GetAllExercises()
        {
            return await Service.GetAll();
        }
    }
}
